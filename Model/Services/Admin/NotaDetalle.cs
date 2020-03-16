using Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
        [Display(Name = "Descripcion")]
        [Required]
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

        public NotaDetalle ObtenerNotaDetalle(int ID_NOTA_DETALLE, int ID_NOTA)
        {
            NotaDetalle notaDetalle = new NotaDetalle();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    notaDetalle = (from nota in ctx.CAS_NOTA
                               join detalle in ctx.CAS_NOTA_DETALLE on nota.ID_NOTA equals detalle.ID_NOTA
                               where detalle.ID_NOTA_DETALLE == ID_NOTA_DETALLE
                               select new NotaDetalle
                               {
                                   ID_NOTA_DETALLE=detalle.ID_NOTA_DETALLE,
                                   ID_NOTA= ID_NOTA,
                                   DESCRIPCION_NOTA_DETALLE=detalle.DESCRIPCION_NOTA_DETALLE
                               }).FirstOrDefault();
                }
                return notaDetalle;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return notaDetalle;

            }
        }


        public void GuardarNotaDetalle(NotaDetalle notaDetalle)
        {
            try
            {
                CAS_NOTA_DETALLE _notaDetalle = new CAS_NOTA_DETALLE();
                using (var ctx = new CAS_DataEntities())
                {
                    var foo = ctx.CAS_NOTA_DETALLE.Where(v => v.ID_NOTA_DETALLE == notaDetalle.ID_NOTA_DETALLE).AsNoTracking().ToList();
                    var fooCount = foo.Count();
                    if (fooCount > 0)
                    {
                        _notaDetalle.ID_NOTA_DETALLE = notaDetalle.ID_NOTA_DETALLE;
                        _notaDetalle.ID_NOTA = notaDetalle.ID_NOTA;
                        _notaDetalle.DESCRIPCION_NOTA_DETALLE = notaDetalle.DESCRIPCION_NOTA_DETALLE;
                        ctx.Entry(_notaDetalle).State = EntityState.Modified;
                    }
                    else
                    {
                        _notaDetalle.ID_NOTA_DETALLE = notaDetalle.ID_NOTA_DETALLE;
                        _notaDetalle.ID_NOTA = notaDetalle.ID_NOTA;
                        _notaDetalle.DESCRIPCION_NOTA_DETALLE = notaDetalle.DESCRIPCION_NOTA_DETALLE;
                        ctx.Entry(_notaDetalle).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public CAS_NOTA_DETALLE ObtenerNotaDetallePorPonderacion(int ID_NOTA_DETALLE)
        {
            CAS_NOTA_DETALLE _nota = new CAS_NOTA_DETALLE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _nota = (from nota in ctx.CAS_NOTA
                             join detalle in ctx.CAS_NOTA_DETALLE on nota.ID_NOTA equals detalle.ID_NOTA
                             where detalle.ID_NOTA_DETALLE == ID_NOTA_DETALLE
                             select detalle).FirstOrDefault();

                }
                return _nota;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _nota;
            }
        }


    }
}