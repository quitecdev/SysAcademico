using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Docente
{
    public class TareaDetalle
    {
        public int ID_TAREA { get; set; }
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
        public string TEMA_TAREA { get; set; }
        public string DESCRIPCION_TAREA { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION_TAREA { get; set; }
        public Nullable<System.DateTime> FECHA_FIN_TAREA { get; set; }
        public Nullable<int> ID_PERIODO { get; set; }

        public List<TareaDetalle> ObtenerDetalleTarea(string ID_DOCENTE,int ID_SEDE,int ID_CARRERA,int ID_MATERIA, int ID_PARALELO,int ID_INTERALO_DETALLE)
        {
            List<TareaDetalle> detalle = new List<TareaDetalle>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    detalle = ctx.SP_DocenteObtenerDetalleTarea(ID_DOCENTE,ID_SEDE,ID_CARRERA,ID_MATERIA,ID_PARALELO,ID_INTERALO_DETALLE, outMensaje, outID)
                                       .Select(x => new TareaDetalle
                                       {
                                           ID_TAREA=x.ID_TAREA,
                                           ID_SEDE = x.ID_SEDE,
                                           DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                           ID_CARRERA = x.ID_CARRERA,
                                           DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                           ID_MATERIA = x.ID_MATERIA,
                                           DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                           ID_PARALELO = x.ID_PARALELO,
                                           DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                           ID_INTERVALO_DETALLE = x.ID_INTERVALO_DETALLE,
                                           HORARIO = x.HORARIO,
                                           TEMA_TAREA=x.TEMA_TAREA,
                                           DESCRIPCION_TAREA=x.DESCRIPCION_TAREA,
                                           FECHA_CREACION_TAREA=x.FECHA_CREACION_TAREA,
                                           FECHA_FIN_TAREA=x.FECHA_FIN_TAREA,
                                       }).ToList();
                }

                return detalle;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return detalle;
            }
        }

    }
}
