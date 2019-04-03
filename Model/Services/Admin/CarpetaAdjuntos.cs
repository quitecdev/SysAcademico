using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;

namespace Model.Services.Admin
{
    public class CarpetaAdjuntos
    {

        public List<CAS_CARPETA_ADJUNTOS> ObtenerCarpetas()
        {
            List<CAS_CARPETA_ADJUNTOS> carpeta = new List<CAS_CARPETA_ADJUNTOS>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    carpeta = ctx.CAS_CARPETA_ADJUNTOS.ToList();
                }
                return carpeta;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return carpeta;
            }
        }
    }
}
