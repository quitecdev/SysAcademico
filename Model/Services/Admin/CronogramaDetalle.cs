using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class CronogramaDetalle
    {

        public int ID_CRONOGRAMA_DETALLE { get; set; }
        public Nullable<int> ID_CRONOGRAMA { get; set; }
        public Nullable<int> SEMANA_CRONOGRAMA { get; set; }
        public Nullable<System.DateTime> FECHA_CRONOGRAMA { get; set; }

        //[Required]
        [Display(Name ="Tema")]
        public string TEMA { get; set; }
        [Display(Name = "Temática")]
        [DataType(DataType.MultilineText)]
        public string TEMATICA { get; set; }
        [Display(Name = "Requerimiento")]
        [DataType(DataType.MultilineText)]
        public string REQUERIMIENTO { get; set; }
        [Display(Name = "Feriado")]
        public bool FERIADO { get; set; }


        public List<ObtenerCronogramaDetalle_Result> ObtenerCronogramaDetalle(int id_cronograma)
        {
            List<ObtenerCronogramaDetalle_Result> cronograma = new List<ObtenerCronogramaDetalle_Result>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    cronograma = ctx.SP_ObtenerCronogramaDetalle(id_cronograma, outMensaje, outID).ToList();
                }
                return cronograma;
            }
            catch (Exception ex )
            {
                ServicesTrackError.RegistrarError(ex);
                return cronograma;
            }
        }


        public CronogramaDetalle CronogramaDetalleObtener(int id_cronograma_detalle)
        {
            CronogramaDetalle cronograma = new CronogramaDetalle();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    cronograma = ctx.CAS_CRONOGRAMA_DETALLE.Where(x => x.ID_CRONOGRAMA_DETALLE == id_cronograma_detalle)
                                 .Select(x => new CronogramaDetalle {
                                     ID_CRONOGRAMA_DETALLE = x.ID_CRONOGRAMA_DETALLE,
                                     ID_CRONOGRAMA = x.ID_CRONOGRAMA,
                                     SEMANA_CRONOGRAMA = x.SEMANA_CRONOGRAMA,
                                     FECHA_CRONOGRAMA = x.FECHA_CRONOGRAMA,
                                     TEMA = x.TEMA,
                                     TEMATICA = x.TEMATICA,
                                     REQUERIMIENTO = x.REQUERIMIENTO,
                                     FERIADO = x.FERIADO ?? false
                                 })
                                 .FirstOrDefault();
                }
                return cronograma;
            }
            catch (Exception ex)
            {

                ServicesTrackError.RegistrarError(ex);
                return cronograma;
            }
        }

        public void GuardarCronogramaDetalle(CronogramaDetalle crononograma)
        {
            CAS_CRONOGRAMA_DETALLE _cronograma = new CAS_CRONOGRAMA_DETALLE();
            List<CAS_CRONOGRAMA_DETALLE> list = new List<CAS_CRONOGRAMA_DETALLE>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _cronograma = ctx.CAS_CRONOGRAMA_DETALLE.Where(x => x.ID_CRONOGRAMA_DETALLE == crononograma.ID_CRONOGRAMA_DETALLE).AsNoTracking().FirstOrDefault();
                    _cronograma.TEMA = crononograma.TEMA;
                    _cronograma.TEMATICA = crononograma.TEMATICA;
                    _cronograma.REQUERIMIENTO = crononograma.REQUERIMIENTO;
                    _cronograma.FERIADO = crononograma.FERIADO;
                    ctx.Entry(_cronograma).State = EntityState.Modified;
                    ctx.SaveChanges();

                    list = ctx.CAS_CRONOGRAMA_DETALLE.Where(x => x.ID_CRONOGRAMA == crononograma.ID_CRONOGRAMA && x.SEMANA_CRONOGRAMA == crononograma.SEMANA_CRONOGRAMA).AsNoTracking().ToList();
                    foreach (var item in list)
                    {
                        if (crononograma.ID_CRONOGRAMA_DETALLE != item.ID_CRONOGRAMA_DETALLE)
                        {
                            _cronograma = new CAS_CRONOGRAMA_DETALLE();
                            _cronograma = ctx.CAS_CRONOGRAMA_DETALLE.Where(x => x.ID_CRONOGRAMA_DETALLE == item.ID_CRONOGRAMA_DETALLE).AsNoTracking().FirstOrDefault();
                            _cronograma.TEMA = crononograma.TEMA;
                            ctx.Entry(_cronograma).State = EntityState.Modified;
                            ctx.SaveChanges();
                        }
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
