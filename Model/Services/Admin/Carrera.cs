using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class Carrera
    {
        public int ID_CARRERA { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_CARRERA { get; set; }
        [Required]
        [Display(Name = "Nombre Técnico")]
        public string NOMBRE_TECNICO_CARRERA { get; set; }
        [Required]
        [Display(Name = "Código")]
        public string COD_CARRERA { get; set; }
        public Nullable<int> ID_GRUPO { get; set; }

        public void GuardarCarrera(Carrera carrera)
        {
            CAS_CARRERA _carrera = new CAS_CARRERA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    if (carrera.ID_CARRERA != 0)
                    {
                        _carrera.ID_CARRERA = carrera.ID_CARRERA;
                        _carrera.DESCRIPCION_CARRERA = carrera.DESCRIPCION_CARRERA;
                        _carrera.NOMBRE_TECNICO_CARRERA = carrera.NOMBRE_TECNICO_CARRERA;
                        _carrera.COD_CARRERA = carrera.COD_CARRERA;
                        _carrera.ID_GRUPO = carrera.ID_GRUPO;
                        ctx.Entry(_carrera).State = EntityState.Modified;
                    }
                    else
                    {
                        _carrera.ID_CARRERA = carrera.ID_CARRERA;
                        _carrera.DESCRIPCION_CARRERA = carrera.DESCRIPCION_CARRERA;
                        _carrera.NOMBRE_TECNICO_CARRERA = carrera.NOMBRE_TECNICO_CARRERA;
                        _carrera.COD_CARRERA = carrera.COD_CARRERA;
                        _carrera.ID_GRUPO = 1;
                        ctx.Entry(_carrera).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public List<Carrera> ObtenerCarreraValidaEstudiante(string ID_INSCRIP)
        {
            List<Carrera> carrera = new List<Carrera>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_ObtenerCarreraValida(ID_INSCRIP, null, outMensaje, outID)
                            .Select(x => new Carrera
                            {
                                ID_CARRERA = x.ID_CARRERA,
                                DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                NOMBRE_TECNICO_CARRERA = x.NOMBRE_TECNICO_CARRERA,
                                COD_CARRERA = x.COD_CARRERA,
                                ID_GRUPO = x.ID_GRUPO
                            }).ToList();
                }
                return carrera;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return carrera;
            }
        }

        public List<Carrera> ObtenerCarrera()
        {
            List<Carrera> carrera = new List<Carrera>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.CAS_CARRERA
                            .Select(x => new Carrera
                            {
                                ID_CARRERA = x.ID_CARRERA,
                                DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                NOMBRE_TECNICO_CARRERA = x.NOMBRE_TECNICO_CARRERA,
                                COD_CARRERA = x.COD_CARRERA,
                                ID_GRUPO = x.ID_GRUPO
                            }).ToList();
                }
                return carrera;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return carrera;
            }
        }

        public List<Carrera> ObtenerCarreraSede(int id_sede)
        {
            List<Carrera> _carrera = new List<Carrera>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {

                    _carrera = (from paraleloMateria in ctx.CAS_PARALELO_MATERIA
                               join materia in ctx.CAS_MATERIA on paraleloMateria.ID_MATERIA equals materia.ID_MATERIA
                               join carrera in ctx.CAS_CARRERA on materia.ID_CARRERA equals carrera.ID_CARRERA
                               where paraleloMateria.ID_SEDE==id_sede
                               select new Carrera ()
                               {
                                   ID_CARRERA = carrera.ID_CARRERA,
                                   DESCRIPCION_CARRERA = carrera.DESCRIPCION_CARRERA,
                                   NOMBRE_TECNICO_CARRERA = carrera.NOMBRE_TECNICO_CARRERA,
                                   COD_CARRERA = carrera.COD_CARRERA,
                                   ID_GRUPO = carrera.ID_GRUPO
                               }
                              ).Distinct().ToList();
                }
                return _carrera;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _carrera;
            }
        }

        public Carrera ObtenerCarrera(int ID_CARRERA)
        {
            Carrera carrera = new Carrera();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    carrera = ctx.CAS_CARRERA.Where(x => x.ID_CARRERA == ID_CARRERA)
                            .Select(x => new Carrera
                            {
                                ID_CARRERA = x.ID_CARRERA,
                                DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                NOMBRE_TECNICO_CARRERA = x.NOMBRE_TECNICO_CARRERA,
                                COD_CARRERA = x.COD_CARRERA,
                                ID_GRUPO = x.ID_GRUPO
                            }).FirstOrDefault();
                }
                return carrera;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return carrera;
            }
        }

        public void EliminarCarrera(int id_carrera)
        {
            CAS_CARRERA carrera = new CAS_CARRERA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    carrera = ctx.CAS_CARRERA.Where(x => x.ID_CARRERA == id_carrera).AsNoTracking().FirstOrDefault();
                    ctx.Entry(carrera).State = EntityState.Deleted;
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
