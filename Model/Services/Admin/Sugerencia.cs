using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;

namespace Model.Services.Admin
{
    public class Sugerencia
    {
        public Estudiante Estudiante { get; set; }
        public Notificacion Notificacion { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string RESPUESTA { get; set; }


        Notificacion _notificacion = new Notificacion();
        Estudiante _estudiante = new Estudiante();
        public Sugerencia ObtenerNotificacion(int ID_NOTIFICACION)
        {
            Sugerencia _sugerencia = new Sugerencia();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _sugerencia.Notificacion = _notificacion.ObterNotificacion(ID_NOTIFICACION);
                    _sugerencia.Estudiante = _estudiante.ObtenerEstudiante(_sugerencia.Notificacion.ID_USUARIO_REMITENTE);
                }
                return _sugerencia;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _sugerencia;
            }
        }
    }
}
