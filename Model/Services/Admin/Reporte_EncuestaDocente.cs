using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Admin
{
    public class Reporte_EncuestaDocente
    {
        [Display(Name = "Selecione un Docente")]
        [Required]
        public string ID_DOCENTE { get; set; }
        public List<DatosCarreraMaterio> DatosCarrera { get; set; }

        public Reporte_EncuestaDocente ObtenerDatos(string id_docente)
        {
            Reporte_EncuestaDocente _encuesta = new Reporte_EncuestaDocente();
            using (var ctx = new CAS_DataEntities())
            {
                ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                _encuesta.ID_DOCENTE = id_docente;
                _encuesta.DatosCarrera = ctx.SP_DocenteDatosCarreraMateria(id_docente, outMensaje, outID)
                                        .Select(x => new DatosCarreraMaterio()
                                        {
                                            ID_SEDE = x.ID_SEDE,
                                            DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                            ID_CARRERA = x.ID_CARRERA,
                                            DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                            ID_MATERIA = x.ID_MATERIA,
                                            DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                            ID_INTERVALO_DETALLE = x.ID_INTERVALO_DETALLE,
                                            HORA = x.HORA,
                                            ID_PARALELO = x.ID_PARALELO,
                                            DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                            DatosEncuesta = ctx.SP_DocenteDatosEncuestaRespuesta(id_docente, x.ID_CARRERA, x.ID_MATERIA, x.ID_INTERVALO_DETALLE, x.ID_PARALELO, outMensaje, outID)
                                                          .Select(a => new DatosEncuesta() {
                                                              DESCRIPCION_PREGUNTA=a.DESCRIPCION_PREGUNTA,
                                                              Muy_Malo = a.Muy_Malo.Value,
                                                              Malo=a.Malo.Value,
                                                              Regular=a.Regular.Value,
                                                              Bueno=a.Bueno.Value,
                                                              Muy_Bueno=a.Muy_Bueno.Value,
                                                          }).ToList()
                                        }).ToList();

                //docenteMateria.ListaDocente = ctx.SP_DocenteHorarioMateria(_ID_DOCENTE, outMensaje, outID)
            }

            return _encuesta;
        }
    }


    public class DatosCarreraMaterio
    {
        public int ID_SEDE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public int ID_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public int ID_INTERVALO_DETALLE { get; set; }
        public string HORA { get; set; }
        public int ID_PARALELO { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public List<DatosEncuesta> DatosEncuesta { get; set; }

    }

    public class DatosEncuesta
    {
        public string DESCRIPCION_PREGUNTA { get; set; }
        public int Muy_Malo { get; set; }
        public int Malo { get; set; }
        public int Regular { get; set; }
        public int Bueno { get; set; }
        public int Muy_Bueno { get; set; }
    }
}
