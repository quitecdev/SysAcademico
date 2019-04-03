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
    public class Aulas
    {
        public int ID_PARALELO_MATERIA { get; set; }
        [Required]
        [Display(Name = "Paralelo")]
        public Nullable<int> ID_PARALELO { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        [Required]
        [Display(Name = "Carrera")]
        public Nullable<int> ID_CARRERA { get; set; }
        [Required]
        [Display(Name = "Materia")]
        public Nullable<int> ID_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        [Required]
        [Display(Name = "Sede")]
        public Nullable<int> ID_SEDE { get; set; }
        public string DESCRIPCION_SEDE { get; set; }
        public Nullable<bool> ESTADO_ASIGANACION { get; set; }
        public Nullable<int> MAX_ASIGANDO { get; set; }
        public Nullable<bool> PARALELO_UNIFICADO { get; set; }

        public void GuardarAula(Aulas aula)
        {
            CAS_PARALELO_MATERIA _aula = new CAS_PARALELO_MATERIA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _aula.ID_PARALELO_MATERIA = aula.ID_PARALELO_MATERIA;
                    _aula.ID_PARALELO = aula.ID_PARALELO;
                    _aula.ID_MATERIA = aula.ID_MATERIA;
                    _aula.ID_SEDE = aula.ID_SEDE;
                    _aula.ESTADO_ASIGANACION = false;
                    _aula.MAX_ASIGANDO = 25;
                    _aula.PARALELO_UNIFICADO = false;
                    ctx.Entry(_aula).State = EntityState.Added;

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public List<Aulas> ObtenerAulas(int ID_MATERIA, int ID_SEDE)
        {
            List<Aulas> _aulas = new List<Aulas>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _aulas = (from aula in ctx.CAS_PARALELO_MATERIA
                              join paralelo in ctx.CAS_PARALELO on aula.ID_PARALELO equals paralelo.ID_PARALELO
                              join sede in ctx.CAS_SEDE on aula.ID_SEDE equals sede.ID_SEDE
                              join materia in ctx.CAS_MATERIA on aula.ID_MATERIA equals materia.ID_MATERIA
                              where aula.ID_MATERIA == ID_MATERIA
                              && sede.ID_SEDE == ID_SEDE
                              select new Aulas
                              {
                                  ID_PARALELO_MATERIA = aula.ID_PARALELO_MATERIA,
                                  ID_PARALELO = paralelo.ID_PARALELO,
                                  DESCRIPCION_PARALELO = paralelo.DESCRIPCION_PARALELO,
                                  ID_MATERIA = aula.ID_MATERIA,
                                  DESCRIPCION_MATERIA = materia.DESCRIPCION_MATERIA,
                                  ID_SEDE = sede.ID_SEDE,
                                  DESCRIPCION_SEDE = sede.DESCRIPCION_UNIVERSIDAD,
                                  ESTADO_ASIGANACION = aula.ESTADO_ASIGANACION,
                                  MAX_ASIGANDO = aula.MAX_ASIGANDO,
                                  PARALELO_UNIFICADO = aula.PARALELO_UNIFICADO
                              }
                              ).ToList();
                }
                return _aulas;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _aulas;
            }
        }

        public void EliminarAula(int id_paralelo_materia)
        {
            CAS_PARALELO_MATERIA aula = new CAS_PARALELO_MATERIA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    aula = ctx.CAS_PARALELO_MATERIA.Where(x => x.ID_PARALELO_MATERIA == id_paralelo_materia).AsNoTracking().FirstOrDefault();
                    ctx.Entry(aula).State = EntityState.Deleted;
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
