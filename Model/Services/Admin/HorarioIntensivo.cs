using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Admin
{
    public class HorarioIntensivo
    {
        public int ID_DOCENTE_MATERIA_PARALELO { get; set; }
        public string DESCRIPCION_PERIODO { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string HORA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public string ID_DOCENTE { get; set; }
        public string NOMBRE { get; set; }

        public List<ObtenerHorarioIntensivos_Result> ObtenerHorarioIntensivo()
        {
            List<ObtenerHorarioIntensivos_Result> _horario = new List<ObtenerHorarioIntensivos_Result>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {

                    _horario = ctx.SP_ObtenerHorarioIntensivos().ToList();
                    return _horario;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _horario;
            }
        }

        public void EliminarDocenteHorario(int ID_DOCENTE_MATERIA_PARALELO)
        {
            CAS_DOCENTE_MATERIA_PARALELO _docente = new CAS_DOCENTE_MATERIA_PARALELO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _docente = ctx.CAS_DOCENTE_MATERIA_PARALELO.Where(v => v.ID_DOCENTE_MATERIA_PARALELO == ID_DOCENTE_MATERIA_PARALELO).AsNoTracking().FirstOrDefault();
                    ctx.Entry(_docente).State = EntityState.Deleted;
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
