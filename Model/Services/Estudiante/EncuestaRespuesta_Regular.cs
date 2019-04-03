using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity;

namespace Model.Services.Estudiante
{
    public class EncuestaRespuesta_Regular
    {
        public int ID_ENCUESTA_RESPUESTA { get; set; }
        public Nullable<int> ID_ENCUESTA_PREGUNTA { get; set; }
        public string ID_ESTUDIANTE { get; set; }
        public string ID_DOCENTE { get; set; }
        public Nullable<int> ID_CARRERA { get; set; }
        public Nullable<int> ID_MATERIA { get; set; }
        public Nullable<int> ID_INTERVALO_DETALLE { get; set; }
        public Nullable<int> ID_PARALELO { get; set; }
        public Nullable<int> VALOR_RESPUESTA { get; set; }


        public void GuardarEncuesta(List<EncuestaRespuesta_Regular> Respuesta)
        {
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    foreach (var item in Respuesta)
                    {
                        CAS_RESPUESTA_ENCUESTA_DOCENTE _respuesta = new CAS_RESPUESTA_ENCUESTA_DOCENTE();
                        _respuesta.ID_ENCUESTA_PREGUNTA = item.ID_ENCUESTA_PREGUNTA;
                        _respuesta.ID_ESTUDIANTE = item.ID_ESTUDIANTE;
                        _respuesta.ID_DOCENTE = item.ID_DOCENTE;
                        _respuesta.ID_CARRERA = item.ID_CARRERA;
                        _respuesta.ID_MATERIA = item.ID_MATERIA;
                        _respuesta.ID_INTERVALO_DETALLE = item.ID_INTERVALO_DETALLE;
                        _respuesta.ID_PARALELO = item.ID_PARALELO;
                        _respuesta.VALOR_RESPUESTA = item.VALOR_RESPUESTA;
                        ctx.Entry(_respuesta).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }
    }
}
