using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using Model.Services.Estudiante;

namespace Model.Services.Estudiante
{  
    public class TareaDetalle
    {
        public int ID_ESTUDIANTE_TAREA { get; set; }
        public Nullable<int> ID_TAREA { get; set; }
        public string ID_ESTUDIANTE { get; set; }
        public string ADJUNTO_TAREA { get; set; }
        public Nullable<System.DateTime> FECHA_TAREA { get; set; }
        public Nullable<decimal> NOTA_TAREA { get; set; }
        public string ADJUNTO_NOMBRE { get; set; }
        public string OBSERVACION_TAREA { get; set; }
        public string TEMA_TAREA { get; set; }
        public string DESCRIPCION_TAREA { get; set; }

        public TareaDetalle ObtenerDetalleTarea(int ID_ESTUDIANTE_TAREA)
        {
            TareaDetalle detalle = new TareaDetalle();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    detalle = (from tareaDetalle in ctx.CAS_ESTUDIANTE_TAREA
                               join tarea in ctx.CAS_TAREAS on tareaDetalle.ID_TAREA equals tarea.ID_TAREA
                               where tareaDetalle.ID_ESTUDIANTE_TAREA == ID_ESTUDIANTE_TAREA
                               select new TareaDetalle()
                               {
                                   ID_ESTUDIANTE_TAREA= tareaDetalle.ID_ESTUDIANTE_TAREA,
                                   ID_TAREA = tarea.ID_TAREA,
                                   TEMA_TAREA = tarea.TEMA_TAREA,
                                   DESCRIPCION_TAREA = tarea.DESCRIPCION_TAREA
                               }
                             ).FirstOrDefault();
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
