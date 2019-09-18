using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Estudiante
{
    public class EncustaEvalucionDocente_Regular
    {
        public List<DatosEncuesta_Estudiante> Datos { get; set; }

        public bool ValidarEncuesta(string ID_ESTUDIANTE)
        {
            bool validar = false;
            using (var ctx = new CAS_DataEntities())
            {
                validar = ctx.CAS_RESPUESTA_ENCUESTA_DOCENTE.Where(x => x.ID_ESTUDIANTE == ID_ESTUDIANTE).Any();
            }
            return validar;
        }

        public EncustaEvalucionDocente_Regular ObtenerEncuesta(string ID_ESTUDIANTE)
        {
            EncustaEvalucionDocente_Regular _encuesta = new EncustaEvalucionDocente_Regular();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    List<DatosEncuesta_Docente> Infra = new List<DatosEncuesta_Docente>();

                    Infra.Add(new DatosEncuesta_Docente() {
                        ID_DOCENTE = "",
                        NOMBRE = "",
                        ID_CARRERA = 0,
                        ID_MATERIA = 0,
                        DESCRIPCION_MATERIA = "",
                        ID_INTERVALO_DETALLE =0,
                        ID_PARALELO =0,
                        PREGUNTAS = (from encuesta in ctx.CAS_ENCUESTA
                                     join pregunta in ctx.CAS_ENCUESTA_PREGUNTAS on encuesta.ID_ENCUESTA equals pregunta.ID_ENCUESTA
                                     where encuesta.ID_ENCUESTA == 3
                                     select new
                                     {
                                         ID_ENCUESTA_PREGUNTA = pregunta.ID_ENCUESTA_PREGUNTA,
                                         ID_ENCUESTA = pregunta.ID_ENCUESTA,
                                         DESCRIPCION_PREGUNTA = pregunta.DESCRIPCION_PREGUNTA,
                                         Opciones = ctx.CAS_ENCUESTA_OPCION.Where(z => z.ID_ENCUESTA_PREGUNTA == pregunta.ID_ENCUESTA_PREGUNTA).ToList()
                                     }).ToList().Select(g => new CAS_ENCUESTA_PREGUNTAS()
                                     {
                                         ID_ENCUESTA_PREGUNTA = g.ID_ENCUESTA_PREGUNTA,
                                         ID_ENCUESTA = g.ID_ENCUESTA,
                                         DESCRIPCION_PREGUNTA = g.DESCRIPCION_PREGUNTA,
                                         //Opciones = ctx.CAS_ENCUESTA_OPCION.Where(n => n.ID_ENCUESTA_PREGUNTA == g.ID_ENCUESTA_PREGUNTA).ToList()
                                     }).ToList()
                    });

                    _encuesta.Datos = ctx.SP_EstudianteObtenerCarreraReporteDocente(ID_ESTUDIANTE, null, outMensaje, outID)
                                     .Select(x => new DatosEncuesta_Estudiante()
                                     {
                                         ID_ESTUDIANTE = x.ID_ESTUDIANTE,
                                         ID_SEDE = x.ID_SEDE,
                                         ID_CARRERA = x.ID_CARRERA,
                                         DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                         ID_PARALELO = x.ID_PARALELO,
                                         ID_INTERVALO_DETALLE = x.ID_INTERVALO_DETALLE,
                                         ID_TIPO_INTERVALO = x.ID_TIPO_INTERVALO,
                                         DOCENTE = ctx.SP_DocenteObtenerDatosReporteDocente(x.ID_SEDE, x.ID_CARRERA, null, x.ID_PARALELO, x.ID_INTERVALO_DETALLE, outMensaje, outID)
                                                   .Select(y => new DatosEncuesta_Docente()
                                                   {
                                                       ID_DOCENTE = y.ID_DOCENTE,
                                                       NOMBRE = y.NOMBRE,
                                                       ID_CARRERA = y.ID_CARRERA,
                                                       ID_MATERIA = y.ID_MATERIA,
                                                       DESCRIPCION_MATERIA = y.DESCRIPCION_MATERIA,
                                                       ID_INTERVALO_DETALLE = y.ID_INTERVALO_DETALLE,
                                                       ID_PARALELO = y.ID_PARALELO,
                                                       PREGUNTAS = (from encuesta in ctx.CAS_ENCUESTA
                                                                    join pregunta in ctx.CAS_ENCUESTA_PREGUNTAS on encuesta.ID_ENCUESTA equals pregunta.ID_ENCUESTA
                                                                    where encuesta.ID_TIPO_INTERVALO == x.ID_TIPO_INTERVALO
                                                                    select new 
                                                                    {
                                                                        ID_ENCUESTA_PREGUNTA = pregunta.ID_ENCUESTA_PREGUNTA,
                                                                        ID_ENCUESTA = pregunta.ID_ENCUESTA,
                                                                        DESCRIPCION_PREGUNTA = pregunta.DESCRIPCION_PREGUNTA,
                                                                        Opciones = ctx.CAS_ENCUESTA_OPCION.Where(z => z.ID_ENCUESTA_PREGUNTA == pregunta.ID_ENCUESTA_PREGUNTA).ToList()
                                                                    }).ToList().Select( g => new CAS_ENCUESTA_PREGUNTAS() {
                                                                        ID_ENCUESTA_PREGUNTA = g.ID_ENCUESTA_PREGUNTA,
                                                                        ID_ENCUESTA = g.ID_ENCUESTA,
                                                                        DESCRIPCION_PREGUNTA = g.DESCRIPCION_PREGUNTA,
                                                                        //Opciones=ctx.CAS_ENCUESTA_OPCION.Where(n=>n.ID_ENCUESTA_PREGUNTA==g.ID_ENCUESTA_PREGUNTA).ToList()
                                                                    }).ToList()

                                                   }).ToList(),
                                         INFRAESTRUCTURA = Infra
                                     }).ToList();
                }
                return _encuesta;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _encuesta;
            }
        }

    }

    public class DatosEncuesta_Estudiante
    {
        public string ID_ESTUDIANTE { get; set; }
        public Nullable<int> ID_SEDE { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public Nullable<int> ID_PARALELO { get; set; }
        public Nullable<int> ID_INTERVALO_DETALLE { get; set; }
        public Nullable<int> ID_TIPO_INTERVALO { get; set; }
        public List<DatosEncuesta_Docente> DOCENTE { get; set; }
        public List<DatosEncuesta_Docente> INFRAESTRUCTURA { get; set; }

    }

    public class DatosEncuesta_Docente
    {
        public string ID_DOCENTE { get; set; }
        public string NOMBRE { get; set; }
        public int ID_CARRERA { get; set; }
        public int ID_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public int ID_INTERVALO_DETALLE { get; set; }
        public int ID_PARALELO { get; set; }
        public List<CAS_ENCUESTA_PREGUNTAS> PREGUNTAS { get; set; }

    }
}
