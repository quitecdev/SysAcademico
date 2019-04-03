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
    public class HorarioMateria
    {
        [Required]
        [Display(Name ="Sede")]
        public int ID_SEDE { get; set; }
        [Required]
        [Display(Name = "Carrera")]
        public int ID_CARRERA { get; set; }
        [Required]
        [Display(Name = "Tipo Horario")]
        public int ID_INTERVALO { get; set; }
        [Required]
        [Display(Name = "Materia")]
        public int ID_MATERIA { get; set; }
        [Required]
        [Display(Name = "Paralelo")]
        public int ID_PARALELO { get; set; }


        public List<ObtenerHorarioMateria_Result> ObtenerDetalle(int id_sede,int id_carrera,int id_materia,int id_paralelo, int id_intervalo)
        {
            List<ObtenerHorarioMateria_Result> _horario = new List<ObtenerHorarioMateria_Result>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    _horario= ctx.SP_ObtenerHorarioMateria(id_sede, id_carrera, id_materia, id_paralelo, id_intervalo, outMensaje, outID).ToList();
                    return _horario;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _horario;
            }
        }


        public List<ObtenerDocenteAsignadoHorarioMateria_Result> DocenteAsiganado(int id_horario_detalle)
        {
            List<ObtenerDocenteAsignadoHorarioMateria_Result> docente = new List<ObtenerDocenteAsignadoHorarioMateria_Result>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    docente = ctx.SP_ObtenerDocenteAsignadoHorarioMateria(id_horario_detalle, outMensaje, outID).ToList();
                    return docente;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return docente;
            }
        }


        public void EliminarDocenteAsignado(int id)
        {
            CAS_DOCENTE_MATERIA_PARALELO docente = new CAS_DOCENTE_MATERIA_PARALELO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    docente = ctx.CAS_DOCENTE_MATERIA_PARALELO.Where(x => x.ID_DOCENTE_MATERIA_PARALELO == id).AsNoTracking().FirstOrDefault();
                    ctx.Entry(docente).State = EntityState.Deleted;
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
