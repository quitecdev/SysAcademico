using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class NotaDocente
    {
        [Required]
        [Display(Name = "Periodo")]
        public int ID_PERIODO { get; set; }
        [Required]
        [Display(Name = "Sede")]
        public int ID_SEDE { get; set; }
        [Required]
        [Display(Name = "Carrera")]
        public int ID_CARRERA { get; set; }
        [Required]
        [Display(Name = "Nota")]
        public int ID_NOTA { get; set; }
        [Required]
        [Display(Name = "Nota Detalle")]
        public int ID_NOTA_DETALLE { get; set; }
        [Required]
        [Display(Name = "Nota Ponderación")]
        public int ID_PONDERACION { get; set; }
        [Required]
        [Display(Name = "Docente")]
        public string ID_DOCENTE { get; set; }

        public List<ObtenerNotaDocente_Result> NotaAsignada { get; set; }

        public NotaDocente ObtenerNotaDocente()
        {
            NotaDocente nota = new NotaDocente();
            List<ObtenerNotaDocente_Result> asignacion = new List<ObtenerNotaDocente_Result>();
            try
            {
                nota.NotaAsignada = asignacion;
                return nota;
            }
            catch (Exception ex)
            {
                return nota;
            }
        }

        public void ActualizarFechaInicio(int ID_DOCENTE_NOTA, string FECHA_INICIO)
        {
            CAS_DOCENTE_NOTAS nota = new CAS_DOCENTE_NOTAS();
            try
            {
                DateTime oDate = Convert.ToDateTime(FECHA_INICIO);
                TimeSpan ts = new TimeSpan(0, 0, 0);
                oDate = oDate.Date + ts;

                using (var ctx= new CAS_DataEntities())
                {
                    nota=ctx.CAS_DOCENTE_NOTAS.Where(v => v.ID_DOCENTE_NOTA == ID_DOCENTE_NOTA).AsNoTracking().FirstOrDefault();
                    nota.FECHA_INICIO = oDate;
                    ctx.Entry(nota).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void ActualizarFechaFin(int ID_DOCENTE_NOTA, string FECHA_FIN)
        {
            CAS_DOCENTE_NOTAS nota = new CAS_DOCENTE_NOTAS();
            try
            {
                DateTime oDate = Convert.ToDateTime(FECHA_FIN);
                TimeSpan ts = new TimeSpan(23, 59, 59);
                oDate = oDate.Date + ts;

                using (var ctx = new CAS_DataEntities())
                {
                    nota = ctx.CAS_DOCENTE_NOTAS.Where(v => v.ID_DOCENTE_NOTA == ID_DOCENTE_NOTA).AsNoTracking().FirstOrDefault();
                    nota.FECHA_FIN = oDate;
                    ctx.Entry(nota).State = EntityState.Modified;
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
