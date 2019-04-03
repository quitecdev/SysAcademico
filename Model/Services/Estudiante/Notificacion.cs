using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace Model.Services.Estudiante
{
    public class Notificacion
    {
        public int ID_NOTIFICACION { get; set; }
        public string ID_USUARIO { get; set; }
        public string TXT_NOTIFICACION { get; set; }
        public Nullable<long> ESTADO_NOTIFICACION { get; set; }
        public Nullable<System.DateTime> FECHA_NOTIFICACION { get; set; }
        public string ID_USUARIO_REMITENTE { get; set; }
        public string ASUNTO_NOTIFICACION { get; set; }
        public Nullable<int> ID_PERIODO { get; set; }
        public Nullable<int> PRIORIDAD_NOTIFICACION { get; set; }


        public List<Notificacion> ObterNotificacion(string _ID_USUARIO)
        {
            List<Notificacion> notificacion = new List<Notificacion>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {

                    var list = ctx.CAS_NOTIFICACIONES.Where(x => x.ID_USUARIO == _ID_USUARIO);
                    foreach (var item in list)
                    {
                        notificacion.Add(new Notificacion
                        {
                            ID_NOTIFICACION = item.ID_NOTIFICACION,
                            ID_USUARIO = item.ID_USUARIO,
                            //StripHtml(item.TXT_NOTIFICACION).Length
                            TXT_NOTIFICACION = StripHtml(item.TXT_NOTIFICACION),
                            ESTADO_NOTIFICACION = item.ESTADO_NOTIFICACION,
                            FECHA_NOTIFICACION = item.FECHA_NOTIFICACION,
                            ID_USUARIO_REMITENTE = item.ID_USUARIO_REMITENTE,
                            ASUNTO_NOTIFICACION = item.ASUNTO_NOTIFICACION,
                            ID_PERIODO = item.ID_PERIODO,
                            PRIORIDAD_NOTIFICACION = item.PRIORIDAD_NOTIFICACION
                        });
                    }
                }
                return notificacion;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return notificacion;
            }
        }

        public int Contador(string _ID_USUARIO)
        {
            int contador = 0;
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    contador = ctx.CAS_NOTIFICACIONES.Where(x => x.ID_USUARIO == _ID_USUARIO && x.ESTADO_NOTIFICACION == 0).Count(); 
                }
                return contador;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return contador;
            }
        }

        public Notificacion VerNotificacion(int _ID_NOTIFICACION)
        {
            Notificacion notificacion = new Notificacion();
            CAS_NOTIFICACIONES _notif = new CAS_NOTIFICACIONES();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _notif = ctx.CAS_NOTIFICACIONES.Where(x => x.ID_NOTIFICACION == _ID_NOTIFICACION).AsNoTracking().FirstOrDefault();
                    _notif.ESTADO_NOTIFICACION = 1;
                    ctx.Entry(_notif).State = EntityState.Modified;
                    ctx.SaveChanges();

                    notificacion.ASUNTO_NOTIFICACION = _notif.ASUNTO_NOTIFICACION;
                    notificacion.TXT_NOTIFICACION = _notif.TXT_NOTIFICACION;

                }
                return notificacion;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return notificacion;
            }
        }

        protected string StripHtml(string Txt)
        {
            return Regex.Replace(Txt, "<(.|\\n)*?>", string.Empty);
        }

        public void GuardarNotificacion(Sugerencia sugerencia)
        {
            List<CAS_DESTINATARIO> _destinatario = new List<CAS_DESTINATARIO>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _destinatario = ctx.CAS_DESTINATARIO.ToList();
                    foreach (var item in _destinatario)
                    {
                        CAS_NOTIFICACIONES _notificacion = new CAS_NOTIFICACIONES();
                        _notificacion.ID_USUARIO = item.ID_USUARIO;
                        _notificacion.TXT_NOTIFICACION = "<p>"+ sugerencia.MENSAJE+"</p>";
                        _notificacion.ESTADO_NOTIFICACION = 0;
                        _notificacion.FECHA_NOTIFICACION = DateTime.Now;
                        _notificacion.ID_USUARIO_REMITENTE = sugerencia.ID_USUARIO;
                        _notificacion.ASUNTO_NOTIFICACION = sugerencia.ASUNTO;
                        _notificacion.ID_PERIODO = 5;
                        _notificacion.PRIORIDAD_NOTIFICACION = 3;
                        ctx.Entry(_notificacion).State = EntityState.Added;
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
