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
    public class Intervalo
    {
        public int ID_INTERVALO { get; set; }

        [Required]
        [Display(Name = "Modalidad")]
        public Nullable<int> ID_TIPO_INTERVALO { get; set; }
        public string DESCRIPCION_TIPO_INVERTALO { get; set; }

        [Required]
        [Display(Name = "Tipo Horario")]
        public Nullable<int> ID_HORARIO_TIPO { get; set; }
        public string DESCRIPCION_HORARIO_TIPO { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public Nullable<int> ID_SEDE { get; set; }
        public string DESCRIPCION_SEDE { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_INTERVALO { get; set; }

        public void Guardar(Intervalo intervalo)
        {
            CAS_INTERVALO _intervalo = new CAS_INTERVALO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    if (intervalo.ID_INTERVALO != 0)
                    {
                        _intervalo.ID_INTERVALO = intervalo.ID_INTERVALO;
                        _intervalo.ID_TIPO_INTERVALO = intervalo.ID_TIPO_INTERVALO;
                        _intervalo.ID_HORARIO_TIPO = intervalo.ID_HORARIO_TIPO;
                        _intervalo.ID_SEDE = intervalo.ID_SEDE;
                        _intervalo.DESCRIPCION_INTERVALO = intervalo.DESCRIPCION_INTERVALO;
                        ctx.Entry(_intervalo).State = EntityState.Modified;
                    }
                    else
                    {
                        _intervalo.ID_INTERVALO = intervalo.ID_INTERVALO;
                        _intervalo.ID_TIPO_INTERVALO = intervalo.ID_TIPO_INTERVALO;
                        _intervalo.ID_HORARIO_TIPO = intervalo.ID_HORARIO_TIPO;
                        _intervalo.ID_SEDE = intervalo.ID_SEDE;
                        _intervalo.DESCRIPCION_INTERVALO = intervalo.DESCRIPCION_INTERVALO;
                        ctx.Entry(_intervalo).State = EntityState.Added;
                    }

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public Intervalo ObtenerIntervalo(int id_intervalo)
        {
            Intervalo intervalo = new Intervalo();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    intervalo = ctx.CAS_INTERVALO.Where(x => x.ID_INTERVALO == id_intervalo)
                                .Select(x => new Intervalo
                                {
                                    ID_INTERVALO = x.ID_INTERVALO,
                                    ID_TIPO_INTERVALO = x.ID_TIPO_INTERVALO,
                                    ID_HORARIO_TIPO = x.ID_HORARIO_TIPO,
                                    ID_SEDE = x.ID_SEDE,
                                    DESCRIPCION_INTERVALO = x.DESCRIPCION_INTERVALO
                                }).FirstOrDefault();
                }
                return intervalo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return intervalo;
            }
        }

        public List<Intervalo> ObtenerIntervalo()
        {
            List<Intervalo> _intervalo = new List<Intervalo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _intervalo = (from intervalo in ctx.CAS_INTERVALO
                                  join sede in ctx.CAS_SEDE on intervalo.ID_SEDE equals sede.ID_SEDE
                                  join tipo in ctx.CAS_TIPO_INVERTALO on intervalo.ID_TIPO_INTERVALO equals tipo.ID_TIPO_INTERVALO
                                  join horario in ctx.CAS_HORARIO_TIPO on intervalo.ID_HORARIO_TIPO equals horario.ID_HORARIO_TIPO
                                  orderby sede.ID_SEDE,tipo.ID_TIPO_INTERVALO,horario.ID_HORARIO_TIPO,intervalo.DESCRIPCION_INTERVALO
                                  select new Intervalo()
                                  {
                                      ID_INTERVALO = intervalo.ID_INTERVALO,
                                      ID_SEDE = sede.ID_SEDE,
                                      DESCRIPCION_SEDE = sede.DESCRIPCION_UNIVERSIDAD,
                                      ID_TIPO_INTERVALO = tipo.ID_TIPO_INTERVALO,
                                      DESCRIPCION_TIPO_INVERTALO = tipo.DESCRIPCION_TIPO_INVERTALO,
                                      ID_HORARIO_TIPO = horario.ID_HORARIO_TIPO,
                                      DESCRIPCION_HORARIO_TIPO = horario.DESCRIPCION_HORARIO_TIPO,
                                      DESCRIPCION_INTERVALO = intervalo.DESCRIPCION_INTERVALO
                                  }
                                  ).ToList();
                }
                return _intervalo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _intervalo;
            }
        }

        public List<Intervalo> ObtenerIntervaloSedeCarera(int ID_SEDE, int ID_CARRERA)
        {
            List<Intervalo> carrera = new List<Intervalo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_ObtenerIntervaloSedeCarrera(ID_CARRERA, ID_SEDE, outMensaje, outID)
                            .Select(x => new Intervalo
                            {
                                ID_INTERVALO = x.ID_INTERVALO,
                                ID_TIPO_INTERVALO = x.ID_TIPO_INTERVALO,
                                ID_HORARIO_TIPO = x.ID_HORARIO_TIPO,
                                ID_SEDE = x.ID_SEDE,
                                DESCRIPCION_INTERVALO = x.DESCRIPCION_INTERVALO
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

        public List<Intervalo> ObtenerIntervaloPorSede(int ID_SEDE)
        {
            List<Intervalo> carrera = new List<Intervalo>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_ObtenerIntervaloPorSede(ID_SEDE, outMensaje, outID)
                            .Select(x => new Intervalo
                            {
                                ID_INTERVALO = x.ID_INTERVALO,
                                ID_TIPO_INTERVALO = x.ID_TIPO_INTERVALO,
                                ID_HORARIO_TIPO = x.ID_HORARIO_TIPO,
                                ID_SEDE = x.ID_SEDE,
                                DESCRIPCION_INTERVALO = x.DESCRIPCION_INTERVALO
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

        public List<CAS_TIPO_INVERTALO> tipoIntervalo()
        {
            List<CAS_TIPO_INVERTALO> tipo = new List<CAS_TIPO_INVERTALO>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    tipo = ctx.CAS_TIPO_INVERTALO.ToList();
                    return tipo;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return tipo;
            }
        }

        public List<CAS_HORARIO_TIPO> horarioTipo()
        {
            List<CAS_HORARIO_TIPO> tipo = new List<CAS_HORARIO_TIPO>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    tipo = ctx.CAS_HORARIO_TIPO.ToList();
                    return tipo;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return tipo;
            }

        }

        public void EliminarIntervalo(int id_intervalo)
        {
            CAS_INTERVALO intervalo = new CAS_INTERVALO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    intervalo = ctx.CAS_INTERVALO.Where(x => x.ID_INTERVALO == id_intervalo).AsNoTracking().FirstOrDefault();
                    ctx.Entry(intervalo).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public List<CAS_TIPO_INVERTALO> ObtenerTipoIntervalo()
        {
            List<CAS_TIPO_INVERTALO> intervalo = new List<CAS_TIPO_INVERTALO>();
            using (var ctx = new CAS_DataEntities())
            {
                intervalo = ctx.CAS_TIPO_INVERTALO.ToList();
            }
                return intervalo;
        }

    }
}
