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
    public class NotaPonderacion
    {
        public int ID_PONDERACION { get; set; }
        public int ID_NOTA_DETALLE { get; set; }
        [Display(Name = "Descripcion")]
        [Required]
        public string DESCRIPCION_PONDERACION { get; set; }
        [Display(Name = "Valor")]
        [Required]
        public Nullable<decimal> VALOR_PONDERACION { get; set; }

        public List<NotaPonderacion> ObtenerNotasPonderacion(int ID_NOTA_DETALLE)
        {
            List<NotaPonderacion> nota = new List<NotaPonderacion>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    nota = ctx.SP_ObtenerNotaPonderacion(ID_NOTA_DETALLE, outMensaje, outID)
                             .Select(x => new NotaPonderacion
                             {
                                 ID_PONDERACION=x.ID_PONDERACION,
                                 ID_NOTA_DETALLE=x.ID_NOTA_DETALLE,
                                 DESCRIPCION_PONDERACION=x.DESCRIPCION_PONDERACION,
                                 VALOR_PONDERACION=x.VALOR_PONDERACION

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

        public List<NotaPonderacion> ObtenerNotasPonderacionNoAsignadas(int ID_NOTA_DETALLE,int ID_SEDE)
        {
            List<NotaPonderacion> nota = new List<NotaPonderacion>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    nota = ctx.SP_ObtenerNotaPonderacionNoAsignada(ID_NOTA_DETALLE,ID_SEDE, outMensaje, outID)
                             .Select(x => new NotaPonderacion
                             {
                                 ID_PONDERACION = x.ID_PONDERACION,
                                 ID_NOTA_DETALLE = x.ID_NOTA_DETALLE,
                                 DESCRIPCION_PONDERACION = x.DESCRIPCION_PONDERACION,
                                 VALOR_PONDERACION = x.VALOR_PONDERACION
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

        public NotaPonderacion ObtenerNotaPonderacion(int ID_NOTA_DETALLE, int ID_PONDERACION)
        {
            NotaPonderacion notaDetalle = new NotaPonderacion();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    notaDetalle = (from nota in ctx.CAS_NOTA
                                   join detalle in ctx.CAS_NOTA_DETALLE on nota.ID_NOTA equals detalle.ID_NOTA
                                   join ponderacion in ctx.CAS_NOTA_PONDERACION on detalle.ID_NOTA_DETALLE equals ponderacion.ID_NOTA_DETALLE
                                   where ponderacion.ID_PONDERACION== ID_PONDERACION
                                   select new NotaPonderacion
                                   {
                                       ID_PONDERACION=ponderacion.ID_PONDERACION,
                                       ID_NOTA_DETALLE=detalle.ID_NOTA_DETALLE,
                                       DESCRIPCION_PONDERACION=ponderacion.DESCRIPCION_PONDERACION,
                                       VALOR_PONDERACION=ponderacion.VALOR_PONDERACION
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

        public void GuardarNotaPonderacion(NotaPonderacion notaPonderacion)
        {
            try
            {
                CAS_NOTA_PONDERACION _notaPonderacion = new CAS_NOTA_PONDERACION();
                using (var ctx = new CAS_DataEntities())
                {
                    var foo = ctx.CAS_NOTA_PONDERACION.Where(v => v.ID_PONDERACION == notaPonderacion.ID_PONDERACION).AsNoTracking().ToList();
                    var fooCount = foo.Count();
                    if (fooCount > 0)
                    {
                        _notaPonderacion.ID_NOTA_DETALLE = notaPonderacion.ID_NOTA_DETALLE;
                        _notaPonderacion.ID_PONDERACION = notaPonderacion.ID_PONDERACION;
                        _notaPonderacion.DESCRIPCION_PONDERACION = notaPonderacion.DESCRIPCION_PONDERACION;
                        _notaPonderacion.VALOR_PONDERACION = notaPonderacion.VALOR_PONDERACION;
                        ctx.Entry(_notaPonderacion).State = EntityState.Modified;
                    }
                    else
                    {
                        _notaPonderacion.ID_NOTA_DETALLE = notaPonderacion.ID_NOTA_DETALLE;
                        _notaPonderacion.ID_PONDERACION = notaPonderacion.ID_PONDERACION;
                        _notaPonderacion.DESCRIPCION_PONDERACION = notaPonderacion.DESCRIPCION_PONDERACION;
                        _notaPonderacion.VALOR_PONDERACION = notaPonderacion.VALOR_PONDERACION;
                        ctx.Entry(_notaPonderacion).State = EntityState.Added;
                    }
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
