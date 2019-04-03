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
    public class Materia
    {
        public int ID_MATERIA { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_MATERIA { get; set; }
        [Required]
        [Display(Name = "Código")]
        public string COD_MATERIA { get; set; }
        [Required]
        public Nullable<int> ID_CARRERA { get; set; }

        public List<Materia> ObtenerMaterias(int _ID_CARRERA)
        {
            List<Materia> _materia = new List<Materia>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _materia = (from carrea in ctx.CAS_CARRERA.Where(x => x.ID_CARRERA == _ID_CARRERA)
                                join materia in ctx.CAS_MATERIA on carrea.ID_CARRERA equals materia.ID_CARRERA
                                select new Materia()
                                {
                                    ID_MATERIA = materia.ID_MATERIA,
                                    DESCRIPCION_MATERIA = materia.DESCRIPCION_MATERIA,
                                    COD_MATERIA = materia.COD_MATERIA,
                                    ID_CARRERA=materia.ID_CARRERA
                                }
                                ).ToList();
                }
                return _materia;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _materia;
            }
        }

        public Materia ObtenerMateria(int ID_MATERIA)
        {
            Materia _materia = new Materia();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _materia = (from carrea in ctx.CAS_CARRERA
                                join materia in ctx.CAS_MATERIA.Where(x=>x.ID_MATERIA==ID_MATERIA) on carrea.ID_CARRERA equals materia.ID_CARRERA
                                select new Materia()
                                {
                                    ID_MATERIA = materia.ID_MATERIA,
                                    DESCRIPCION_MATERIA = materia.DESCRIPCION_MATERIA,
                                    COD_MATERIA = materia.COD_MATERIA,
                                    ID_CARRERA = materia.ID_CARRERA
                                }
                                ).FirstOrDefault();
                }
                return _materia;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _materia;
            }
        }

        public void GuardarMateria(Materia materia)
        {
            CAS_MATERIA _materia = new CAS_MATERIA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    if (materia.ID_MATERIA==0)
                    {
                        _materia.ID_MATERIA = materia.ID_MATERIA;
                        _materia.DESCRIPCION_MATERIA = materia.DESCRIPCION_MATERIA;
                        _materia.COD_MATERIA = materia.COD_MATERIA;
                        _materia.ID_CARRERA = materia.ID_CARRERA;
                        ctx.Entry(_materia).State = EntityState.Added;
                    }
                    else
                    {
                        _materia.ID_MATERIA = materia.ID_MATERIA;
                        _materia.DESCRIPCION_MATERIA = materia.DESCRIPCION_MATERIA;
                        _materia.COD_MATERIA = materia.COD_MATERIA;
                        _materia.ID_CARRERA = materia.ID_CARRERA;
                        ctx.Entry(_materia).State = EntityState.Modified;
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
