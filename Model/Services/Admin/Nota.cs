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
    public class Nota
    {
        public int ID_NOTA { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_NOTA { get; set; }
        [Required]
        [Display(Name = "Tipo. Intervalo")]
        public int ID_TIPO_INTERVALO { get; set; }
        public string DESCRIPCION_TIPO_INVERTALO { get; set; }
        [Required]
        [Display(Name = "Carrera")]
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        [Required]
        [Display(Name = "Periodo")]
        public int ID_PERIODO { get; set; }
        public string DESCRIPCION_PERIODO { get; set; }

        public List<Nota> ObtenerNotas()
        {
            List<Nota> nota = new List<Nota>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    nota = ctx.SP_ObtenerNota( outMensaje, outID)
                             .Select(x => new Nota
                             {
                                 ID_NOTA=x.ID_NOTA,
                                 DESCRIPCION_NOTA=x.DESCRIPCION_NOTA,
                                 ID_TIPO_INTERVALO=x.ID_TIPO_INTERVALO,
                                 DESCRIPCION_TIPO_INVERTALO=x.DESCRIPCION_TIPO_INVERTALO,
                                 ID_CARRERA=x.ID_CARRERA,
                                 DESCRIPCION_CARRERA=x.DESCRIPCION_CARRERA,
                                 ID_PERIODO=x.ID_PERIODO,
                                 DESCRIPCION_PERIODO=x.DESCRIPCION_PERIODO,

                             }).ToList();

                }
                return nota;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return nota;

            }
        }

        public Nota ObtenerNota(int ID_NOTA)
        {
            List<Nota> notas = new List<Nota>();
            Nota nota = new Nota();
            using (var ctx = new CAS_DataEntities())
            {
                ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                notas = ctx.SP_ObtenerNota(outMensaje, outID)
                         .Select(x => new Nota
                         {
                             ID_NOTA = x.ID_NOTA,
                             DESCRIPCION_NOTA = x.DESCRIPCION_NOTA,
                             ID_TIPO_INTERVALO = x.ID_TIPO_INTERVALO,
                             DESCRIPCION_TIPO_INVERTALO = x.DESCRIPCION_TIPO_INVERTALO,
                             ID_CARRERA = x.ID_CARRERA,
                             DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                             ID_PERIODO = x.ID_PERIODO,
                             DESCRIPCION_PERIODO = x.DESCRIPCION_PERIODO,

                         }).ToList();
                nota = notas.Where(x => x.ID_NOTA == ID_NOTA).FirstOrDefault();
            }
            return nota;
        }

        public void GuardarNota(Nota nota)
        {
            CAS_NOTA _nota = new CAS_NOTA();
            try
            {

                using (var ctx = new CAS_DataEntities())
                {
                    if (nota.ID_NOTA!= 0)
                    {

                        _nota.ID_NOTA = nota.ID_NOTA;
                        _nota.DESCRIPCION_NOTA = nota.DESCRIPCION_NOTA;
                        _nota.ID_TIPO_INTERVALO = nota.ID_TIPO_INTERVALO;
                        _nota.ID_CARRERA = nota.ID_CARRERA;
                        _nota.ID_PERIODO = nota.ID_PERIODO;
                        ctx.Entry(_nota).State = EntityState.Modified;
                    }
                    else
                    {
                        _nota.ID_NOTA = nota.ID_NOTA;
                        _nota.DESCRIPCION_NOTA = nota.DESCRIPCION_NOTA;
                        _nota.ID_TIPO_INTERVALO = nota.ID_TIPO_INTERVALO;
                        _nota.ID_CARRERA = nota.ID_CARRERA;
                        _nota.ID_PERIODO = nota.ID_PERIODO;
                        ctx.Entry(_nota).State = EntityState.Added;
                    }
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
