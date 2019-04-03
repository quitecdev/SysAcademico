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
    public class Paralelo
    {
        public int ID_PARALELO { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_PARALELO { get; set; }

        public void GuardarParalelo(Paralelo paralelo)
        {
            CAS_PARALELO _paralelo = new CAS_PARALELO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    if (paralelo.ID_PARALELO != 0)
                    {
                        _paralelo.ID_PARALELO = paralelo.ID_PARALELO;
                        _paralelo.DESCRIPCION_PARALELO = paralelo.DESCRIPCION_PARALELO;
                        ctx.Entry(_paralelo).State = EntityState.Modified;
                    }
                    else
                    {
                        _paralelo.ID_PARALELO = paralelo.ID_PARALELO;
                        _paralelo.DESCRIPCION_PARALELO = paralelo.DESCRIPCION_PARALELO;
                        ctx.Entry(_paralelo).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public List<Paralelo> ObtenerParalelo()
        {
            List<Paralelo> paralelo = new List<Paralelo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    paralelo = ctx.CAS_PARALELO
                                .Select(x => new Paralelo
                                {
                                    ID_PARALELO = x.ID_PARALELO,
                                    DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO
                                }).ToList();
                }
                return paralelo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return paralelo;
            }
        }

        public List<Paralelo> ObtenerParalelo(int ID_SEDE, int ID_MATERIA, bool ESTADO = false)
        {
            List<CAS_PARALELO_MATERIA> aula = new List<CAS_PARALELO_MATERIA>();
            List<Paralelo> _paralelo = new List<Paralelo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    if (ESTADO == false)
                    {
                        aula = ctx.CAS_PARALELO_MATERIA.Where(x => x.ID_SEDE == ID_SEDE && x.ID_MATERIA == ID_MATERIA).ToList();
                        var excludedIDs = new HashSet<int>(aula.Where(x => x.ID_SEDE == ID_SEDE && x.ID_MATERIA == ID_MATERIA).Select(p => p.ID_PARALELO.Value));
                        _paralelo = ctx.CAS_PARALELO
                                    .Where(x => !excludedIDs.Contains(x.ID_PARALELO))
                                    .Select(x => new Paralelo
                                    {
                                        ID_PARALELO = x.ID_PARALELO,
                                        DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO
                                    }).ToList();
                    }
                    else
                    {
                        _paralelo = (from paraleloMateria in ctx.CAS_PARALELO_MATERIA
                                     join materia in ctx.CAS_MATERIA on paraleloMateria.ID_MATERIA equals materia.ID_MATERIA
                                     join carrera in ctx.CAS_CARRERA on materia.ID_CARRERA equals carrera.ID_CARRERA
                                     join paralelo in ctx.CAS_PARALELO on paraleloMateria.ID_PARALELO equals paralelo.ID_PARALELO
                                     where paraleloMateria.ID_SEDE == ID_SEDE && materia.ID_MATERIA == ID_MATERIA
                                     select new Paralelo()
                                     {
                                         ID_PARALELO = paralelo.ID_PARALELO,
                                         DESCRIPCION_PARALELO = paralelo.DESCRIPCION_PARALELO
                                     }
                                     ).Distinct().ToList();
                    }
                }
                return _paralelo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _paralelo;
            }
        }

        public Paralelo ObtenerParalelo(int _ID_PARALELO)
        {
            Paralelo paralelo = new Paralelo();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    paralelo = ctx.CAS_PARALELO.Where(x => x.ID_PARALELO == _ID_PARALELO)
                                .Select(x => new Paralelo
                                {
                                    ID_PARALELO = x.ID_PARALELO,
                                    DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO
                                }).FirstOrDefault();
                }
                return paralelo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return paralelo;
            }
        }

        public List<Paralelo> ObtenerParaleloCarreraSedeCarera(int _ID_SEDE, int _ID_CARRERA, int _ID_INTERVALO, int _ID_INTERVALO_DETALLE)
        {
            List<Paralelo> carrera = new List<Paralelo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_ObtenerParaleloSedeCarrera(_ID_CARRERA, _ID_SEDE, _ID_INTERVALO, _ID_INTERVALO_DETALLE, outMensaje, outID)
                            .Select(x => new Paralelo
                            {
                                ID_PARALELO = x.ID_PARALELO,
                                DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
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

        public List<Paralelo> ObtenerParaleloMateria(int _ID_SEDE, int _ID_MATERIA)
        {
            List<Paralelo> _paralelo = new List<Paralelo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _paralelo = (from carrea in ctx.CAS_CARRERA
                                 join materia in ctx.CAS_MATERIA.Where(x => x.ID_MATERIA == _ID_MATERIA) on carrea.ID_CARRERA equals materia.ID_CARRERA
                                 join paraleloMateria in ctx.CAS_PARALELO_MATERIA on materia.ID_MATERIA equals paraleloMateria.ID_MATERIA
                                 join paralelo in ctx.CAS_PARALELO on paraleloMateria.ID_PARALELO equals paralelo.ID_PARALELO
                                 join sede in ctx.CAS_SEDE.Where(x => x.ID_SEDE == _ID_SEDE) on paraleloMateria.ID_SEDE equals sede.ID_SEDE
                                 select new Paralelo()
                                 {
                                     ID_PARALELO = paraleloMateria.ID_PARALELO_MATERIA,
                                     DESCRIPCION_PARALELO = paralelo.DESCRIPCION_PARALELO
                                 }
                              ).ToList();
                }
                return _paralelo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _paralelo;
            }
        }

        public void EliminarParalelo(int id_paralelo)
        {
            CAS_PARALELO paralelo = new CAS_PARALELO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    paralelo = ctx.CAS_PARALELO.Where(x => x.ID_PARALELO == id_paralelo).AsNoTracking().FirstOrDefault();
                    ctx.Entry(paralelo).State = EntityState.Deleted;
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
