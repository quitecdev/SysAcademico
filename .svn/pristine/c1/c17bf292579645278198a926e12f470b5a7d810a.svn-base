using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Admin
{
    public class EstudianteNotaCarrera
    {
        public int ID_NOTA_DETALLE { get; set; }
        public string DESCRIPCION_NOTA_DETALLE { get; set; }
        public Nullable<decimal> PROMEDIO { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public Nullable<int> CONTADOR { get; set; }
        public List<EstudianteNotaDetalleCarrera> Detalle { get; set; }


        public List<EstudianteNotaCarrera> ObtenerNotaCarrera(int ID_INSCRIP_DETALLE_CARRERA)
        {
            List<EstudianteNotaCarrera> notas = new List<EstudianteNotaCarrera>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    notas = ctx.SP_ObtenerEstudianteNotaCarrera(ID_INSCRIP_DETALLE_CARRERA, outMensaje, outID)
                            .Select(x => new EstudianteNotaCarrera
                            {
                                ID_NOTA_DETALLE = x.ID_NOTA_DETALLE,
                                DESCRIPCION_NOTA_DETALLE = x.DESCRIPCION_NOTA_DETALLE,
                                PROMEDIO = x.PROMEDIO,
                                TOTAL = x.TOTAL,
                                CONTADOR = x.CONTADOR,
                                Detalle = ctx.SP_ObtenerEstudianteNotaDetalleCarrera(ID_INSCRIP_DETALLE_CARRERA, x.ID_NOTA_DETALLE, outMensaje, outID)
                                         .Select(y => new EstudianteNotaDetalleCarrera {
                                             ID_ESTUDIANTE_NOTA = y.ID_ESTUDIANTE_NOTA,
                                             DESCRIPCION_PONDERACION = y.DESCRIPCION_PONDERACION,
                                             VALOR_NOTA = y.VALOR_NOTA,
                                             NOTA=y.NOTA
                                         }).ToList()
                            }).ToList();
                }
                return notas;
            }
            catch (Exception ex )
            {
                ServicesTrackError.RegistrarError(ex);
                return notas;
            }
        }
    }

    public class EstudianteNotaDetalleCarrera
    {
        public int ID_ESTUDIANTE_NOTA { get; set; }
        public string DESCRIPCION_PONDERACION { get; set; }
        public Nullable<decimal> VALOR_NOTA { get; set; }
        public Nullable<decimal> NOTA { get; set; }
    }
}
