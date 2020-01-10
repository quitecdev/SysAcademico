using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Admin
{
    public class NotaDetalle
    {
        public int ID_NOTA { get; set; }
        public string DESCRIPCION_NOTA { get; set; }
        public int ID_NOTA_DETALLE { get; set; }
        public string DESCRIPCION_NOTA_DETALLE { get; set; }
        public Nullable<int> VALOR_DETALLE { get; set; }

        public List<NotaDetalle> ObtenerNotasDetalle(int ID_NOTA)
        {
            List<NotaDetalle> nota = new List<NotaDetalle>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    nota = ctx.SP_ObtenerNotaDetalle(ID_NOTA,outMensaje, outID)
                             .Select(x => new NotaDetalle
                             {
                                 ID_NOTA = x.ID_NOTA,
                                 DESCRIPCION_NOTA = x.DESCRIPCION_NOTA,
                                 ID_NOTA_DETALLE=x.ID_NOTA_DETALLE,
                                 DESCRIPCION_NOTA_DETALLE=x.DESCRIPCION_NOTA_DETALLE,
                                 VALOR_DETALLE=x.VALOR_DETALLE

                             }).ToList();

                }
                return nota;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return nota;

            }
        }


    }
}