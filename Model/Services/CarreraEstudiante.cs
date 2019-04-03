using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services
{
    public class CarreraEstudiante
    {
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string COD_CARRERA { get; set; }
        public int ID_SEDE { get; set; }
        public Nullable<int> ID_TIPO_INTERVALO { get; set; }
        public int ID_PARALELO { get; set; }


        public List<CarreraEstudiante> ObtenerCarreraEstudiante(string ID_ESTUDIANTE)
        {
            List<CarreraEstudiante> carrera = new List<CarreraEstudiante>();

            using (var ctx = new CAS_DataEntities())
            {
                ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                carrera = ctx.SP_EstudianteObtenerCarrera(ID_ESTUDIANTE, null, outMensaje, outID)
                          .Select(x => new CarreraEstudiante {
                              ID_CARRERA = x.ID_CARRERA,
                              DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                              COD_CARRERA = x.COD_CARRERA,
                              ID_SEDE=x.ID_SEDE,
                              ID_TIPO_INTERVALO=x.ID_TIPO_INTERVALO,
                              ID_PARALELO=x.ID_PARALELO
                          }).ToList();
            }
            return carrera;
        }
    }
}
