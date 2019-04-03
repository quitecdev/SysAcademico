using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Admin
{
     public class Horario
    {
        public int ID_HORARIO { get; set; }
        public Nullable<int> ID_INTERVALO_DETALLE { get; set; }
        [Required]
        [Display (Name ="Día")]
        public Nullable<int> ID_DIA { get; set; }

        public string DESCRIPCION_DIA { get; set; }

        public Horario ObtenerHorario(int id_intervalo_detalle)
        {
            Horario horario = new Horario();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    horario.ID_INTERVALO_DETALLE = id_intervalo_detalle;
                }
                return horario;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return horario;
            }
        }

        public void GuardarHorario( Horario horario)
        {
            CAS_HORARIO _horario = new CAS_HORARIO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    if (horario.ID_HORARIO != 0)
                    {
                        _horario.ID_HORARIO = horario.ID_HORARIO;
                        _horario.ID_INTERVALO_DETALLE = horario.ID_INTERVALO_DETALLE;
                        _horario.ID_DIA = horario.ID_DIA;
                        ctx.Entry(_horario).State = EntityState.Modified;
                    }
                    else
                    {
                        _horario.ID_HORARIO = horario.ID_HORARIO;
                        _horario.ID_INTERVALO_DETALLE = horario.ID_INTERVALO_DETALLE;
                        _horario.ID_DIA = horario.ID_DIA;
                        ctx.Entry(_horario).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void EliminarHorario(int id_horario)
        {
            CAS_HORARIO horario = new CAS_HORARIO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    horario = ctx.CAS_HORARIO.Where(x => x.ID_HORARIO == id_horario).AsNoTracking().FirstOrDefault();
                    ctx.Entry(horario).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public List<Horario> ObtenerDetalle(int id_intervalo_detalle)
        {
            List<Horario> _horario = new List<Horario>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _horario = (from dia in ctx.CAS_DIAS
                               join  horario in ctx.CAS_HORARIO on dia.ID_DIAS equals horario.ID_DIA
                               where horario.ID_INTERVALO_DETALLE==id_intervalo_detalle
                              select new Horario()
                              {
                                  ID_HORARIO=horario.ID_HORARIO,
                                  ID_INTERVALO_DETALLE=horario.ID_INTERVALO_DETALLE,
                                  ID_DIA=dia.ID_DIAS,
                                  DESCRIPCION_DIA=dia.DESCRIPCION_DIAS
                              }
                         ).ToList();
                }
                return _horario;
            }
            catch (Exception ex )
            {
                ServicesTrackError.RegistrarError(ex);
                return _horario;
            }
        }

        public List<CAS_DIAS> ObtenerDias()
        {
            List<CAS_DIAS> _dia = new List<CAS_DIAS>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _dia = ctx.CAS_DIAS.ToList();
                }
                return _dia;
            }
            catch (Exception ex )
            {
                ServicesTrackError.RegistrarError(ex);
                return _dia;
            }
        }

        public List<CAS_DIAS> ObtenerDiasLibres(int ID_INTERVALO_DETALLE, int ID_PARALELO_MATERIA)
        {
            List<CAS_DIAS> _dia = new List<CAS_DIAS>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    _dia = ctx.SP_ObtenerDiaLibreHorario(ID_INTERVALO_DETALLE, ID_PARALELO_MATERIA, outMensaje, outID)
                          .Select(x => new CAS_DIAS() {
                              ID_DIAS=x.ID_HORARIO,
                              DESCRIPCION_DIAS=x.DESCRIPCION_DIAS
                          }).ToList();
                }
                return _dia;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _dia;
            }
        }


    }
}
