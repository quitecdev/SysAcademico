using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Admin
{
    public class RutaAdjunto
    {

        public ObtenerRutaAdjunto_Result ObtenerRuta(int id_cronograma_detalle)
        {
            ObtenerRutaAdjunto_Result ruta = new ObtenerRutaAdjunto_Result();
            try
            {
                using (var ctx= new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    ruta = ctx.SP_ObtenerRutaAdjunto(id_cronograma_detalle, outMensaje, outID).FirstOrDefault();
                }
                return ruta;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return ruta;
            }
        }

    }
}
