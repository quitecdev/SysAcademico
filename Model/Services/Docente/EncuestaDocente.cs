using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;


namespace Model.Services.Docente
{
    public class EncuestaDocente
    {
        public List<CAS_ENCUESTA_PREGUNTAS> Preguntas { get; set; }
        public string ID_DOCENTE { get; set; }
        public bool ValidarEncuesta(string ID_DOCENTE)
        {
            bool validar = false;
            using (var ctx = new CAS_DataEntities())
            {
                validar = ctx.CAS_RESPUESTA_ENCUESTA_DOCENTE.Where(x => x.ID_ESTUDIANTE == ID_DOCENTE).Any();
            }
            return validar;
        }


        public EncuestaDocente ObtenerEncuesta(string ID_DOCENTE)
        {
            EncuestaDocente _encuesta = new EncuestaDocente();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _encuesta.ID_DOCENTE = ID_DOCENTE;
                    _encuesta.Preguntas = (from encuesta in ctx.CAS_ENCUESTA
                                           join pregunta in ctx.CAS_ENCUESTA_PREGUNTAS on encuesta.ID_ENCUESTA equals pregunta.ID_ENCUESTA
                                           where encuesta.ID_ENCUESTA==4
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
}
