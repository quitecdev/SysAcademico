using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;

namespace Model.Services.Admin
{
    public class InscripcionFecha
    {
        public int ID_INSCRIPCION_FECHA { get; set; }
        public Nullable<int> ID_PERIODO { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public Nullable<System.DateTime> FECHA_FIN { get; set; }

        Periodo periodo = new Periodo();
        public bool VerificarEstado()
        {
            CAS_INSCRIPCION_FECHA fecha = new CAS_INSCRIPCION_FECHA();
            bool estado = false;
            int periodoActual = 0;
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    periodoActual = periodo.ObtenerPeriodoActivo().ID_PERIODO;
                    fecha = ctx.CAS_INSCRIPCION_FECHA.Where(x => x.ID_PERIODO == periodoActual).FirstOrDefault();
                    int result = DateTime.Compare(DateTime.Now, fecha.FECHA_FIN.Value);
                    if (result!=1)
                    {
                        estado = true;
                    }
                }
                return estado;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return estado;
            }
        }
    }
}
