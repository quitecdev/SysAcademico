using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Text.RegularExpressions;
using System.Data.Entity;
using System.Xml;

namespace Model.Services.Admin
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

                    var list = ctx.CAS_NOTIFICACIONES.Where(x => x.ID_USUARIO == _ID_USUARIO).OrderByDescending(x => x.ID_NOTIFICACION); ;
                    foreach (var item in list)
                    {
                        notificacion.Add(new Notificacion
                        {
                            ID_NOTIFICACION = item.ID_NOTIFICACION,
                            ID_USUARIO = item.ID_USUARIO,
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

        public Notificacion ObterNotificacion(int _ID_NOTIFICACION)
        {
            Notificacion notificacion = new Notificacion();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {

                    notificacion = ctx.CAS_NOTIFICACIONES.Where(x => x.ID_NOTIFICACION == _ID_NOTIFICACION)
                                   .Select(x => new Notificacion
                                   {
                                       ID_NOTIFICACION = x.ID_NOTIFICACION,
                                       ID_USUARIO = x.ID_USUARIO,
                                       TXT_NOTIFICACION = x.TXT_NOTIFICACION,
                                       ESTADO_NOTIFICACION = x.ESTADO_NOTIFICACION,
                                       FECHA_NOTIFICACION = x.FECHA_NOTIFICACION,
                                       ID_USUARIO_REMITENTE = x.ID_USUARIO_REMITENTE,
                                       ASUNTO_NOTIFICACION = x.ASUNTO_NOTIFICACION,
                                       ID_PERIODO = x.ID_PERIODO,
                                       PRIORIDAD_NOTIFICACION = x.PRIORIDAD_NOTIFICACION
                                   }).FirstOrDefault();
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


        public void EnviarRespuest(Sugerencia sugerencia)
        {
            CAS_NOTIFICACIONES _notificacion = new CAS_NOTIFICACIONES();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _notificacion = ctx.CAS_NOTIFICACIONES.Where(x => x.ID_NOTIFICACION == sugerencia.Notificacion.ID_NOTIFICACION).AsNoTracking().FirstOrDefault();

                    _notificacion.ID_USUARIO = _notificacion.ID_USUARIO_REMITENTE;
                    _notificacion.TXT_NOTIFICACION = "<p>" + sugerencia.RESPUESTA + "</p>";
                    _notificacion.ESTADO_NOTIFICACION = 0;
                    _notificacion.FECHA_NOTIFICACION = DateTime.Now;
                    _notificacion.ID_USUARIO_REMITENTE = null;
                    _notificacion.ASUNTO_NOTIFICACION = _notificacion.ASUNTO_NOTIFICACION;
                    _notificacion.ID_PERIODO = 5;
                    _notificacion.PRIORIDAD_NOTIFICACION = 3;
                    ctx.Entry(_notificacion).State = EntityState.Added;
                    ctx.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }
    }
}
