using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Estudiante
{
    public class Tareas
    {
        public int ID_ESTUDIANTE_TAREA { get; set; }
        public int ID_TAREA { get; set; }
        public int ID_SEDE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public int ID_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string TEMA_TAREA { get; set; }
        public Nullable<System.DateTime> FECHA_FIN_TAREA { get; set; }
        public Nullable<decimal> NOTA_TAREA { get; set; }

        public List<Tareas> ObtenerDetalleTarea(string ID_ESTUDIANTE)
        {
            List<Tareas> detalle = new List<Tareas>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    detalle = ctx.SP_EstudianteObtenerTareasDetalle(ID_ESTUDIANTE, outMensaje, outID)
                                       .Select(x => new Tareas
                                       {
                                           ID_ESTUDIANTE_TAREA=x.ID_ESTUDIANTE_TAREA,
                                           ID_TAREA = x.ID_TAREA,
                                           ID_SEDE = x.ID_SEDE,
                                           DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                           ID_CARRERA = x.ID_CARRERA,
                                           DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                           ID_MATERIA = x.ID_MATERIA,
                                           DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                           TEMA_TAREA = x.TEMA_TAREA,
                                           FECHA_FIN_TAREA = x.FECHA_FIN_TAREA,
                                           NOTA_TAREA=x.NOTA_TAREA
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
