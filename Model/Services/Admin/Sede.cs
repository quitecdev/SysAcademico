using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class Sede
    {
        public int ID_SEDE { get; set; }
        public Nullable<int> ID_UNIVERSIDAD { get; set; }

        [Required]
        [Display(Name ="Descripción")]
        public string DESCRIPCION_UNIVERSIDAD { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string COD_SEDE { get; set; }

        public void GuardarSede(Sede sede)
        {
            CAS_SEDE _sede = new CAS_SEDE();
            try
            {
                using (var ctx=new CAS_DataEntities())
                {
                    if (sede.ID_SEDE!=0)
                    {
                        _sede.ID_SEDE = sede.ID_SEDE;
                        _sede.ID_UNIVERSIDAD = 1;
                        _sede.DESCRIPCION_UNIVERSIDAD = sede.DESCRIPCION_UNIVERSIDAD;
                        _sede.COD_SEDE = sede.COD_SEDE;
                        ctx.Entry(_sede).State = EntityState.Modified;
                    }
                    else
                    {
                        _sede.ID_SEDE = sede.ID_SEDE;
                        _sede.ID_UNIVERSIDAD = 1;
                        _sede.DESCRIPCION_UNIVERSIDAD = sede.DESCRIPCION_UNIVERSIDAD;
                        _sede.COD_SEDE = sede.COD_SEDE;
                        ctx.Entry(_sede).State = EntityState.Added;
                    }

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public List<Sede> ObtenerSede()
        {
            List<Sede> sede = new List<Sede>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    sede = ctx.CAS_SEDE
                           .Select(x => new Sede {
                               ID_SEDE = x.ID_SEDE,
                               ID_UNIVERSIDAD = x.ID_UNIVERSIDAD,
                               DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                               COD_SEDE = x.COD_SEDE
                           }).ToList();
                }
                return sede;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return sede;
            }
        }

        public Sede ObtenerSede(int ID_SEDE)
        {
            Sede sede = new Sede();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    sede= ctx.CAS_SEDE.Where(x=>x.ID_SEDE==ID_SEDE)
                           .Select(x => new Sede
                           {
                               ID_SEDE = x.ID_SEDE,
                               ID_UNIVERSIDAD = x.ID_UNIVERSIDAD,
                               DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                               COD_SEDE = x.COD_SEDE
                           }).FirstOrDefault();
                }
                return sede;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return sede;
            }
        }

        public void EliminarSede(int id_sede)
        {
            CAS_SEDE sede = new CAS_SEDE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    sede = ctx.CAS_SEDE.Where(x => x.ID_SEDE == id_sede).AsNoTracking().FirstOrDefault();
                    ctx.Entry(sede).State = EntityState.Deleted;
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
