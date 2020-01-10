using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class CronogramaAdjunto
    {
        public int ID_CRONOGRAMA_ADJUNTO { get; set; }
        public Nullable<int> ID_CRONOGRAMA_DETALLE { get; set; }
        public string RUTA_ADJUNTO { get; set; }
        public string ICONO_ADJUNTO { get; set; }
        public string PESO_ADJUNTO { get; set; }
        public string NOMBRE_ADJUNTO { get; set; }
        [Required]
        [Display (Name ="Carpeta")]
        public Nullable<int> ID_CARPETA { get; set; }

        public List<HttpPostedFileBase> Files { get; set; }


        public CronogramaAdjunto()
        {
            Files = new List<HttpPostedFileBase>();
        }

        public List<CronogramaAdjunto> ObtenerAdjunto(int id_cronograma)
        {
            List<CronogramaAdjunto> adjunto = new List<CronogramaAdjunto>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    adjunto = ctx.CAS_CRONOGRAMA_ADJUNTO.Where(x => x.ID_CRONOGRAMA_DETALLE == id_cronograma)
                             .Select(x => new CronogramaAdjunto {
                                 ID_CRONOGRAMA_ADJUNTO = x.ID_CRONOGRAMA_ADJUNTO,
                                 ID_CRONOGRAMA_DETALLE = x.ID_CRONOGRAMA_DETALLE,
                                 RUTA_ADJUNTO = x.RUTA_ADJUNTO.Replace(@"_ \",@"_\").ToString(),
                                 ICONO_ADJUNTO = x.ICONO_ADJUNTO,
                                 PESO_ADJUNTO = x.PESO_ADJUNTO,
                                 NOMBRE_ADJUNTO = x.NOMBRE_ADJUNTO,
                                 ID_CARPETA = ID_CARPETA,
                             })
                             .ToList();
                }
                return adjunto;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return adjunto;
            }
        }

        public void GuardarAdjunto(CronogramaAdjunto adjunto)
        {
            CAS_CRONOGRAMA_ADJUNTO _adjunto = new CAS_CRONOGRAMA_ADJUNTO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _adjunto.ID_CRONOGRAMA_ADJUNTO = adjunto.ID_CRONOGRAMA_ADJUNTO;
                    _adjunto.ID_CRONOGRAMA_DETALLE = adjunto.ID_CRONOGRAMA_DETALLE;
                    _adjunto.RUTA_ADJUNTO = adjunto.RUTA_ADJUNTO;
                    _adjunto.ICONO_ADJUNTO = adjunto.ICONO_ADJUNTO;
                    _adjunto.PESO_ADJUNTO = adjunto.PESO_ADJUNTO;
                    _adjunto.NOMBRE_ADJUNTO = adjunto.NOMBRE_ADJUNTO;
                    _adjunto.ID_CARPETA = adjunto.ID_CARPETA;
                    ctx.Entry(_adjunto).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex )
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void GuardarAdjuntoLink(CronogramaAdjunto adjunto)
        {
            CAS_CRONOGRAMA_ADJUNTO _adjunto = new CAS_CRONOGRAMA_ADJUNTO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _adjunto.ID_CRONOGRAMA_ADJUNTO = adjunto.ID_CRONOGRAMA_ADJUNTO;
                    _adjunto.ID_CRONOGRAMA_DETALLE = adjunto.ID_CRONOGRAMA_DETALLE;
                    _adjunto.RUTA_ADJUNTO = adjunto.RUTA_ADJUNTO;
                    _adjunto.ICONO_ADJUNTO = "zmdi zmdi-link";
                    _adjunto.NOMBRE_ADJUNTO = adjunto.NOMBRE_ADJUNTO;
                    _adjunto.PESO_ADJUNTO = "0 MB";
                    _adjunto.ID_CARPETA = adjunto.ID_CARPETA;
                    ctx.Entry(_adjunto).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void EliminarAdjunto(int id_cronograma_adjunto)
        {
            CAS_CRONOGRAMA_ADJUNTO _adjunto = new CAS_CRONOGRAMA_ADJUNTO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _adjunto= ctx.CAS_CRONOGRAMA_ADJUNTO.Where(x => x.ID_CRONOGRAMA_ADJUNTO == id_cronograma_adjunto).AsNoTracking().FirstOrDefault() ;
                    ctx.Entry(_adjunto).State = EntityState.Deleted;
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
