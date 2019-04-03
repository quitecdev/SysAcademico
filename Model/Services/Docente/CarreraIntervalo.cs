using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Docente
{
   public class CarreraIntervalo
    {
        public int ID_SEDE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public int ID_PARALELO { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public int ID_TIPO_INTERVALO { get; set; }
        public string DESCRIPCION_TIPO_INVERTALO { get; set; }

        public List<CarreraIntervalo> ObtenerCarreras(string ID_DOCENTE)
        {
            List<CarreraIntervalo> carrera = new List<CarreraIntervalo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_DocenteCarreraIntervalo(ID_DOCENTE, null, outMensaje, outID)
                                       .Select(x => new CarreraIntervalo
                                       {
                                           ID_SEDE = x.ID_SEDE,
                                           DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                           ID_CARRERA = x.ID_CARRERA,
                                           DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                           ID_PARALELO = x.ID_PARALELO,
                                           DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                           ID_TIPO_INTERVALO =x.ID_TIPO_INTERVALO,
                                           DESCRIPCION_TIPO_INVERTALO=x.DESCRIPCION_TIPO_INVERTALO
                                       }).ToList();
                }

                return carrera;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return carrera;
            }
        }

    }
}
