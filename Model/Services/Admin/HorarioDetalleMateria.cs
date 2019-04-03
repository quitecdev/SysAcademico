using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class HorarioDetalleMateria
    {
        /*DETALLE*/
        public int ID_HORARIO_DETALLE { get; set; }
        public int ID_SEDE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public int ID_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public int ID_PARALELO { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public string DESCRIPCION_INTERVALO { get; set; }
        public Nullable<System.TimeSpan> INICIO_INTERVALO { get; set; }
        public Nullable<System.TimeSpan> FIN_INTERVALO { get; set; }
        public string HORARIO { get; set; }
        public int ID_DIAS { get; set; }
        public string DESCRIPCION_DIAS { get; set; }

        public List<HorarioDetalleMateria> ObtenerDetalleHorario(int id_paralelo_materia)
        {
            List<HorarioDetalleMateria> horario = new List<HorarioDetalleMateria>();
            try
            {
                using (var ctx=new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    horario = ctx.SP_ObtenerHorarioDetalle(id_paralelo_materia, outMensaje, outID)
                             .Select(x => new HorarioDetalleMateria {

                                 ID_HORARIO_DETALLE = x.ID_HORARIO_DETALLE,
                                 ID_SEDE = x.ID_SEDE,
                                 DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                 ID_CARRERA = x.ID_CARRERA,
                                 DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                 ID_MATERIA = x.ID_MATERIA,
                                 DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                 ID_PARALELO = x.ID_PARALELO,
                                 DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                 DESCRIPCION_INTERVALO = x.DESCRIPCION_INTERVALO,
                                 INICIO_INTERVALO = x.INICIO_INTERVALO,
                                 FIN_INTERVALO = x.FIN_INTERVALO,
                                 HORARIO=x.HORARIO,
                                 ID_DIAS = x.ID_DIAS,
                                 DESCRIPCION_DIAS = x.DESCRIPCION_DIAS
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

    public class ModelHorario
    {
        public int ID_PARALELO_MATERIA { get; set; }
        public int ID_SEDE { get; set; }

        [Required]
        [Display(Name = "Horario")]
        public int ID_INTERVALO { get; set; }
        public string DESCRIPCION_INTERVALO { get; set; }

        [Required]
        [Display(Name = "Hora")]
        public int ID_INTERVALO_DETALLE { get; set; }
        public string INTERVALO { get; set; }

        [Required]
        [Display(Name = "Día")]
        public int ID_DIAS { get; set; }
        public string DESCRIPCION_DIAS { get; set; }



        public void GuadarHorario(ModelHorario horario)
        {
            CAS_HORARIO_DETALLE horarioDetalle = new CAS_HORARIO_DETALLE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    horarioDetalle.ID_HORARIO = horario.ID_DIAS;
                    horarioDetalle.ID_PARALELO_MATERIA = horario.ID_PARALELO_MATERIA;
                    ctx.Entry(horarioDetalle).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void EliminarHorarioDetalle(int id_horario_detalle)
        {
            CAS_HORARIO_DETALLE _horario = new CAS_HORARIO_DETALLE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _horario = ctx.CAS_HORARIO_DETALLE.Where(x => x.ID_HORARIO_DETALLE == id_horario_detalle).AsNoTracking().FirstOrDefault();
                    ctx.Entry(_horario).State = EntityState.Deleted;
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
