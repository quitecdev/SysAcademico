using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;

namespace Model.Services.Admin
{
    public class TipoPago
    {
        public int ID_TIPO_PAGO { get; set; }
        public string DESCRIPCION_TIPO_PAGO { get; set; }

        public List<TipoPago> ObtenerTipoPago()
        {
            List<TipoPago> sede = new List<TipoPago>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    sede = ctx.CAS_TIPO_PAGO
                           .Select(x => new TipoPago
                           {
                               ID_TIPO_PAGO = x.ID_TIPO_PAGO,
                               DESCRIPCION_TIPO_PAGO = x.DESCRIPCION_TIPO_PAGO,
                           }).ToList();
                }
                return sede;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return sede;
            }
        }
    }
}
