using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Admin
{
    public class DocenteAsistencia
    {
        public int ID_DOCENTE_ASISTENCIA { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public System.DateTime FECHA_ASISTENCIA { get; set; }
        public string HORA { get; set; }
        public Nullable<int> ESTADO_ASISTENCIA { get; set; }
        public string OBSERVACION_ASISTENCIA { get; set; }

        public List<DocenteAsistencia> ObtenerAsistencia(string ID_DOCENTE)
        {
            List<DocenteAsistencia> asistencia = new List<DocenteAsistencia>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    asistencia = ctx.SP_ObtenerDocenteAsistencia(ID_DOCENTE, null, outMensaje, outID)
                                         .Select(x => new DocenteAsistencia
                                         {
                                             ID_DOCENTE_ASISTENCIA = x.ID_DOCENTE_ASISTENCIA,
                                             DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                             DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                             DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                             DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                             FECHA_ASISTENCIA = x.FECHA_ASISTENCIA,
                                             HORA = x.HORA,
                                             ESTADO_ASISTENCIA = x.ESTADO_ASISTENCIA,
                                             OBSERVACION_ASISTENCIA=x.OBSERVACION_ASISTENCIA
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
    }
}
