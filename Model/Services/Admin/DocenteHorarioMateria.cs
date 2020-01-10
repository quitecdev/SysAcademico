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
    public class DocenteHorarioMateria
    {
        public string AUX_REDIRECT { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public Nullable<int> ID_SEDE { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public Nullable<int> ID_CARRERA { get; set; }

        [Required]
        [Display(Name = "Materia")]
        public Nullable<int> ID_MATERIA { get; set; }

        [Required]
        [Display(Name = "Paralelo")]
        public Nullable<int> ID_PARALELO { get; set; }

        [Required]
        [Display(Name = "Horario")]
        public Nullable<int> ID_HORARIO_DETALLE { get; set; }


        public List<ListaHorarioDocente> ListaDocente { get; set; }

        public void GuardarHorario(DocenteHorarioMateria horario)
        {
            CAS_DOCENTE_MATERIA_PARALELO docente = new CAS_DOCENTE_MATERIA_PARALELO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    docente.ID_DOCENTE = horario.AUX_REDIRECT;
                    docente.ID_HORARIO_DETALLE = horario.ID_HORARIO_DETALLE;
                    ctx.Entry(docente).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void EliminarHorario(int _ID_DOCENTE_MATERIA_PARALELO)
        {
            CAS_DOCENTE_MATERIA_PARALELO docente = new CAS_DOCENTE_MATERIA_PARALELO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    docente = ctx.CAS_DOCENTE_MATERIA_PARALELO.Where(x => x.ID_DOCENTE_MATERIA_PARALELO == _ID_DOCENTE_MATERIA_PARALELO).AsNoTracking().FirstOrDefault();
                    ctx.Entry(docente).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public DocenteHorarioMateria ObtenerHorarioMateria(string _ID_DOCENTE)
        {
            DocenteHorarioMateria docenteMateria = new DocenteHorarioMateria();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    docenteMateria.ListaDocente = ctx.SP_DocenteHorarioMateria(_ID_DOCENTE, outMensaje, outID)
                                     .Select(x => new ListaHorarioDocente
                                     {
                                         ID_HORARIO_DETALLE = x.ID_HORARIO_DETALLE,
                                         DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                         DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                         DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                         DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                         DESCRIPCION_DIAS = x.DESCRIPCION_DIAS,
                                         HORA = x.HORA,
                                         DESDESCRIPCION_PERIODO=x.DESCRIPCION_PERIODO
                                     }).ToList();
                    docenteMateria.AUX_REDIRECT = _ID_DOCENTE;
                }
                return docenteMateria;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return docenteMateria;
            }
        }
    }

    public class ListaHorarioDocente
    {
        public string AUX_REDIRECT { get; set; }
        public int ID_HORARIO_DETALLE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public string DESCRIPCION_DIAS { get; set; }
        public string HORA { get; set; }
        public string DESDESCRIPCION_PERIODO { get; set; }
    }
}
