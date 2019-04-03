using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Estudiante
{
    public class EstudianteAsistencia
    {
        public int ID_ASISTENCIA { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<bool> ESTADO { get; set; }

        public List<EstudianteAsistencia> ObtenerAsistencia(string ID_ESTUDIANTE)
        {
            List<EstudianteAsistencia> horario = new List<EstudianteAsistencia>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    horario = ctx.SP_EstudianteObtenerAsistencia(ID_ESTUDIANTE, null, outMensaje, outID)
                            .Select(x => new EstudianteAsistencia
                            {
                                ID_ASISTENCIA = x.ID_ASISTENCIA,
                                DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                FECHA = x.FECHA,
                                ESTADO = x.ESTADO

                            }).ToList();
                }
                return horario;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return horario;
            }
        }

    }
}
