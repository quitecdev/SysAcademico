using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class EstudianteAsistenciaCarrera
    {
        public int ID_ASISTENCIA { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string HORA { get; set; }
        public Nullable<bool> ESTADO { get; set; }
        public int ID_ASISTENCIA_JUSTIFICADA { get; set; }

        public List<EstudianteAsistenciaCarrera> ObtenerAsistenciaCarrera(int ID_INSCRIP_DETALLE_CARRERA)
        {
            List<EstudianteAsistenciaCarrera> asistencia = new List<EstudianteAsistenciaCarrera>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    asistencia = ctx.SP_ObtenerEstudianteAsistenciaCarrera(ID_INSCRIP_DETALLE_CARRERA, outMensaje, outID)
                               .Select(x => new EstudianteAsistenciaCarrera {
                                   ID_ASISTENCIA = x.ID_ASISTENCIA,
                                   DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                   DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                   DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                   DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                   FECHA = x.FECHA,
                                   HORA = x.HORA,
                                   ESTADO = x.ESTADO,
                                   ID_ASISTENCIA_JUSTIFICADA=x.ID_ASISTENCIA_JUSTIFICADA.Value
                               }).ToList();
                }
                return asistencia;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return asistencia; 
            }
        }

        public void JustificarFalta(int ID_ASISTENCIA)
        {
            CAS_ESTUDIANTE_ASISTENCIA _asistencia = new CAS_ESTUDIANTE_ASISTENCIA();
            CAS_ESTUDIANTE_ASISTENCIA_JUSTIFICACION _justificar = new CAS_ESTUDIANTE_ASISTENCIA_JUSTIFICACION();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _asistencia = ctx.CAS_ESTUDIANTE_ASISTENCIA.Where(x => x.ID_ASISTENCIA == ID_ASISTENCIA).AsNoTracking().FirstOrDefault();
                    _asistencia.ESTADO = true;
                    ctx.Entry(_asistencia).State = EntityState.Modified;
                    ctx.SaveChanges();

                    _justificar.ID_ASISTENCIA = ID_ASISTENCIA;
                    ctx.Entry(_justificar).State = EntityState.Added;
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
