using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;

namespace Model.Services.Admin
{
    public class ContadorWeb
    {

        public int Visitas { get; set; }
        public int Estudiante { get; set; }
        public int Docentes { get; set; }
        public int Personale { get; set; }


        public ContadorWeb ObtenerContador()
        {
            ContadorWeb contador = new ContadorWeb();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    contador.Visitas = ctx.CAS_VISITA.Count();
                    contador.Estudiante = ctx.CAS_ESTUDIANTE.Count();
                    contador.Docentes = ctx.CAS_DOCENTE.Count();
                    contador.Personale = ctx.CAS_PERSONAL.Count();
                }
                return contador;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return contador;
            }
        }
    }
}
