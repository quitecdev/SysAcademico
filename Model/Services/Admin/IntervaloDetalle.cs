using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class IntervaloDetalle
    {
        public int ID_INTERVALO_DETALLE { get; set; }

        [Required]
        [Display(Name ="Tipo Intervalo")]
        public Nullable<int> ID_INTERVALO { get; set; }

        [Required]
        [Display(Name = "Inicio")]
        public Nullable<System.TimeSpan> INICIO_INTERVALO { get; set; }

        [Required]
        [Display(Name = "Fin")]
        public Nullable<System.TimeSpan> FIN_INTERVALO { get; set; }
        public string INTERVALO { get; set; }


        public void GuardarIntervaloDetalle(IntervaloDetalle invertaloDetalle)
        {
            CAS_INTERVALO_DETALLE _intervalo = new CAS_INTERVALO_DETALLE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    if (invertaloDetalle.ID_INTERVALO_DETALLE != 0)
                    {
                        _intervalo.ID_INTERVALO_DETALLE = invertaloDetalle.ID_INTERVALO_DETALLE;
                        _intervalo.ID_INTERVALO = invertaloDetalle.ID_INTERVALO;
                        _intervalo.INICIO_INTERVALO = invertaloDetalle.INICIO_INTERVALO;
                        _intervalo.FIN_INTERVALO = invertaloDetalle.FIN_INTERVALO;
                        ctx.Entry(_intervalo).State = EntityState.Modified;
                    }
                    else
                    {
                        _intervalo.ID_INTERVALO_DETALLE = invertaloDetalle.ID_INTERVALO_DETALLE;
                        _intervalo.ID_INTERVALO = invertaloDetalle.ID_INTERVALO;
                        _intervalo.INICIO_INTERVALO = invertaloDetalle.INICIO_INTERVALO;
                        _intervalo.FIN_INTERVALO = invertaloDetalle.FIN_INTERVALO;
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


        public IntervaloDetalle ObtenerIntervalo(int ID_INTERVALO_DETALLE)
        {
            IntervaloDetalle intervalo = new IntervaloDetalle();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    intervalo = ctx.CAS_INTERVALO_DETALLE.Where(x => x.ID_INTERVALO_DETALLE==ID_INTERVALO_DETALLE)
                    .Select(x => new IntervaloDetalle
                    {
                        ID_INTERVALO_DETALLE = x.ID_INTERVALO_DETALLE,
                        ID_INTERVALO = x.ID_INTERVALO,
                        INICIO_INTERVALO = x.INICIO_INTERVALO,
                        FIN_INTERVALO = x.FIN_INTERVALO
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

        public void EliminarIntervaloDetalle(int id_intervalo_detall)
        {
            CAS_INTERVALO_DETALLE intervalo = new CAS_INTERVALO_DETALLE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    intervalo = ctx.CAS_INTERVALO_DETALLE.Where(x => x.ID_INTERVALO_DETALLE == id_intervalo_detall).AsNoTracking().FirstOrDefault();
                    ctx.Entry(intervalo).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }


        public List<InvervaloDetalleModel> ObtenerIntervalo()
        {
            List<InvervaloDetalleModel> _intervalo = new List<InvervaloDetalleModel>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _intervalo = (from intervalo in ctx.CAS_INTERVALO
                                  join sede in ctx.CAS_SEDE on intervalo.ID_SEDE equals sede.ID_SEDE
                                  join tipo in ctx.CAS_TIPO_INVERTALO on intervalo.ID_TIPO_INTERVALO equals tipo.ID_TIPO_INTERVALO
                                  join horario in ctx.CAS_HORARIO_TIPO on intervalo.ID_HORARIO_TIPO equals horario.ID_HORARIO_TIPO
                                  join intervalo_detalle in ctx.CAS_INTERVALO_DETALLE on intervalo.ID_INTERVALO equals intervalo_detalle.ID_INTERVALO
                                  select new InvervaloDetalleModel()
                                  {
                                      ID_INTERVALO = intervalo.ID_INTERVALO,
                                      SEDE_DESCRIPCION = sede.DESCRIPCION_UNIVERSIDAD,
                                      DESCRIPCION_TIPO_INVERTALO = tipo.DESCRIPCION_TIPO_INVERTALO,
                                      DESCRIPCION_HORARIO_TIPO = horario.DESCRIPCION_HORARIO_TIPO,
                                      DESCRIPCION_INTERVALO = intervalo.DESCRIPCION_INTERVALO,
                                      ID_INTERVALO_DETALLE = intervalo_detalle.ID_INTERVALO_DETALLE,
                                      INICIO_INTERVALO = intervalo_detalle.INICIO_INTERVALO.Value.ToString(),
                                      FIN_INTERVALO = intervalo_detalle.FIN_INTERVALO.Value.ToString()
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


        public InvervaloDetalleModel ObtenerIntervaloDetalle(int id_intervaloDetall)
        {
            InvervaloDetalleModel _intervalo = new InvervaloDetalleModel();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _intervalo = (from intervalo in ctx.CAS_INTERVALO
                                  join sede in ctx.CAS_SEDE on intervalo.ID_SEDE equals sede.ID_SEDE
                                  join tipo in ctx.CAS_TIPO_INVERTALO on intervalo.ID_TIPO_INTERVALO equals tipo.ID_TIPO_INTERVALO
                                  join horario in ctx.CAS_HORARIO_TIPO on intervalo.ID_HORARIO_TIPO equals horario.ID_HORARIO_TIPO
                                  join intervalo_detalle in ctx.CAS_INTERVALO_DETALLE on intervalo.ID_INTERVALO equals intervalo_detalle.ID_INTERVALO
                                  where intervalo_detalle.ID_INTERVALO_DETALLE== id_intervaloDetall
                                  select new InvervaloDetalleModel()
                                  {
                                      ID_INTERVALO = intervalo.ID_INTERVALO,
                                      SEDE_DESCRIPCION = sede.DESCRIPCION_UNIVERSIDAD,
                                      DESCRIPCION_TIPO_INVERTALO = tipo.DESCRIPCION_TIPO_INVERTALO,
                                      DESCRIPCION_HORARIO_TIPO = horario.DESCRIPCION_HORARIO_TIPO,
                                      DESCRIPCION_INTERVALO = intervalo.DESCRIPCION_INTERVALO,
                                      ID_INTERVALO_DETALLE = intervalo_detalle.ID_INTERVALO_DETALLE,
                                      INICIO_INTERVALO = intervalo_detalle.INICIO_INTERVALO.Value.ToString(),
                                      FIN_INTERVALO = intervalo_detalle.FIN_INTERVALO.Value.ToString()
                                  }
                                  ).FirstOrDefault();
                }
                return _intervalo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _intervalo;
            }
        }



        public List<IntervaloDetalle> ObtenerIntervaloCarreraSedeCarera(int _ID_SEDE, int _ID_CARRERA, string _ID_INSCRIP, int _ID_INTERVALO)
        {
            List<IntervaloDetalle> carrera = new List<IntervaloDetalle>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_ObtenerIntervaloDetalleSedeCarrera(_ID_CARRERA, _ID_SEDE, _ID_INSCRIP, _ID_INTERVALO, outMensaje, outID)
                            .Select(x => new IntervaloDetalle
                            {
                                ID_INTERVALO_DETALLE = x.ID_INTERVALO_DETALLE,
                                ID_INTERVALO = x.ID_INTERVALO,
                                INICIO_INTERVALO = x.INICIO_INTERVALO,
                                FIN_INTERVALO = x.FIN_INTERVALO,
                                INTERVALO = x.INTERVALO
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

        public List<IntervaloDetalle> ObtenerIntervaloDetallePorInvertalo(int _ID_INTERVALO)
        {
            List<IntervaloDetalle> carrera = new List<IntervaloDetalle>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    carrera = ctx.SP_ObtenerIntervaloDetalle(_ID_INTERVALO, outMensaje, outID)
                            .Select(x => new IntervaloDetalle
                            {
                                ID_INTERVALO_DETALLE = x.ID_INTERVALO_DETALLE,
                                ID_INTERVALO = x.ID_INTERVALO,
                                INICIO_INTERVALO = x.INICIO_INTERVALO,
                                FIN_INTERVALO = x.FIN_INTERVALO,
                                INTERVALO = x.HORA
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

        public List<ObtenerHorarioParalelo_Result> ObtenerHorarioParalelo(int ID_PARALELO_MATERIA)
        {
            List<ObtenerHorarioParalelo_Result> horario = new List<ObtenerHorarioParalelo_Result>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    horario = ctx.SP_ObtenerHorarioParalelo(ID_PARALELO_MATERIA, outMensaje, outID)
                            .Select(x => new ObtenerHorarioParalelo_Result
                            {
                                ID_HORARIO_DETALLE = x.ID_HORARIO_DETALLE,
                                DETALLE = x.DETALLE
                            }).ToList();
                }
                return horario;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return horario;
            }
        }
    }


    public class InvervaloDetalleModel
    {
        public int ID_INTERVALO { get; set; }
        public string SEDE_DESCRIPCION { get; set; }
        public string DESCRIPCION_TIPO_INVERTALO { get; set; }
        public string DESCRIPCION_HORARIO_TIPO { get; set; }
        public string DESCRIPCION_INTERVALO { get; set; }
        public int ID_INTERVALO_DETALLE { get; set; }
        public string INICIO_INTERVALO { get; set; }
        public string FIN_INTERVALO { get; set; }
    }
}
