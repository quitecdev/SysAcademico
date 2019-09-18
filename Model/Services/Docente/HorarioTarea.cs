using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Services.Docente
{
    public class HorarioTarea
    {
        public int ID_SEDE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public int ID_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public int ID_PARALELO { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public int ID_INTERVALO_DETALLE { get; set; }
        public string HORARIO { get; set; }

        public List<HorarioTarea> ObtenerHorarioTarea(string ID_DOCENTE)
        {
            List<HorarioTarea> carrera = new List<HorarioTarea>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_DocenteHorarioTarea(ID_DOCENTE, outMensaje, outID)
                                       .Select(x => new HorarioTarea
                                       {
                                           ID_SEDE = x.ID_SEDE,
                                           DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                           ID_CARRERA = x.ID_CARRERA,
                                           DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                           ID_MATERIA=x.ID_MATERIA,
                                           DESCRIPCION_MATERIA=x.DESCRIPCION_MATERIA,
                                           ID_PARALELO = x.ID_PARALELO,
                                           DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                           ID_INTERVALO_DETALLE = x.ID_INTERVALO_DETALLE,
                                           HORARIO = x.HORARIO
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
