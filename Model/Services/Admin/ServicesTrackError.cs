using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Admin
{
    public static class ServicesTrackError
    {
        public static string RegistrarError(Exception ex)
        {
            TrackError.reg regerror = new TrackError.reg();
            string outMensaje = null;
            regerror.RegistrarError(ex, ref outMensaje);
            return outMensaje;
        }
    }
}
