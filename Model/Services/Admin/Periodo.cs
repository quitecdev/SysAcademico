using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;

namespace Model.Services.Admin
{
    public class Periodo
    {
        public int ID_PERIODO { get; set; }
        public string DESCRIPCION_PERIODO { get; set; }
        public System.DateTime FECHA_INICIO { get; set; }
        public System.DateTime FECHA_FIN { get; set; }
        public Nullable<int> ESTADO { get; set; }

        public Periodo ObtenerPeriodoActivo()
        {
            Periodo periodo = new Periodo();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    periodo = ctx.CAS_PERIODO.Where(x => x.ESTADO == 1)
                              .Select(x => new Periodo
                              {
                                  ID_PERIODO = x.ID_PERIODO,
                                  DESCRIPCION_PERIODO = x.DESCRIPCION_PERIODO,
                                  FECHA_INICIO = x.FECHA_INICIO,
                                  FECHA_FIN = x.FECHA_FIN,
                                  ESTADO = x.ESTADO
                              }).FirstOrDefault();

                }
                return periodo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return periodo;
            }
        }

        public List<Periodo> ListPeriodo()
        {
            List<Periodo> _periodo = new List<Periodo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _periodo = ctx.CAS_PERIODO.Where(x => x.ESTADO == 1 || x.ESTADO == 2)
                               .Select(x => new Periodo {
                                   ID_PERIODO = x.ID_PERIODO,
                                   DESCRIPCION_PERIODO = x.DESCRIPCION_PERIODO,
                                   FECHA_INICIO = x.FECHA_INICIO,
                                   FECHA_FIN = x.FECHA_FIN,
                                   ESTADO = x.ESTADO
                               }).ToList();
                }
                return _periodo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _periodo;
            }
        }
    }
}
