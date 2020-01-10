using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Docente
{
    public class NotasAsignadas
    {
        public Nullable<int> ID_PERIODO { get; set; }
        public string DESCRIPCION_PERIODO { get; set; }
        public int ID_SEDE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public int ID_NOTA { get; set; }
        public string DESCRIPCION_NOTA { get; set; }
        public int ID_INTERVALO_DETALLE { get; set; }
        public string HORA { get; set; }
        public string ID_DOCENTE { get; set; }
        public string NOMBRE { get; set; }


        public List<NotasAsignadas> Obtener(string ID_DOCENTE)
        {
            List<NotasAsignadas> notas = new List<NotasAsignadas>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    notas = ctx.SP_DocenteObtenerNotas(ID_DOCENTE, null, outMensaje, outID)
                            .Select(x => new NotasAsignadas {
                                ID_PERIODO=x.ID_PERIODO,
                                DESCRIPCION_PERIODO=x.DESCRIPCION_PERIODO,
                                ID_DOCENTE = ID_DOCENTE,
                                NOMBRE=x.NOMBRE,
                                ID_SEDE =x.ID_SEDE,
                                DESCRIPCION_UNIVERSIDAD=x.DESCRIPCION_UNIVERSIDAD,
                                ID_CARRERA=x.ID_CARRERA,
                                DESCRIPCION_CARRERA=x.DESCRIPCION_CARRERA,
                                ID_NOTA=x.ID_NOTA,
                                DESCRIPCION_NOTA=x.DESCRIPCION_NOTA,
                                ID_INTERVALO_DETALLE=x.ID_INTERVALO_DETALLE,
                                HORA=x.HORA
                            }).ToList();
                }
                return notas;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return notas;
            }
        }
    }
}
