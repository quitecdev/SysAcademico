using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Docente
{
    public class TareaCalificacion
    {
        public int ID_ESTUDIANTE_TAREA { get; set; }
        public string ID_ESTUDIANTE { get; set; }
        public string APELLIDOS { get; set; }
        public string NOMBRES { get; set; }
        public string ADJUNTO_TAREA { get; set; }
        public Nullable<decimal> NOTA_TAREA { get; set; }


        public List<TareaCalificacion> ObtenerTareaCalificar(int ID_TAREA)
        {
            List<TareaCalificacion> detalle = new List<TareaCalificacion>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    detalle = ctx.SP_DocenteCalificacionTarea(ID_TAREA, outMensaje, outID)
                                       .Select(x => new TareaCalificacion
                                       {
                                           ID_ESTUDIANTE_TAREA = x.ID_ESTUDIANTE_TAREA,
                                           ID_ESTUDIANTE = x.ID_ESTUDIANTE,
                                           APELLIDOS = x.APELLIDOS,
                                           NOMBRES = x.NOMBRES,
                                           ADJUNTO_TAREA = x.ADJUNTO_TAREA,
                                           NOTA_TAREA = x.NOTA_TAREA
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

        public void ActulizarNota(int ID_ESTUDIANTE_TAREA, decimal _VALOR_NOTA)
        {
            try
            {
                CAS_ESTUDIANTE_TAREA nota = new CAS_ESTUDIANTE_TAREA();
                using (var ctx = new CAS_DataEntities())
                {
                    nota = ctx.CAS_ESTUDIANTE_TAREA.Where(x => x.ID_ESTUDIANTE_TAREA == ID_ESTUDIANTE_TAREA).AsNoTracking().FirstOrDefault();
                    nota.NOTA_TAREA = _VALOR_NOTA;
                    ctx.Entry(nota).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }


    }
}
