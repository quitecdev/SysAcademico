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
    public class Cronograma
    {
        public int ID_CRONOGRAMA { get; set; }

        [Required]
        [Display(Name ="Carrera")]
        public Nullable<int> ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public Nullable<int> ID_SEDE { get; set; }
        public string DESCRIPCION_SEDE { get; set; }

        [Required]
        [Display(Name = "Periodo")]
        public Nullable<int> ID_PERIODO { get; set; }
        public string DESCRIPCION_PERIODO { get; set; }

        [Required]
        [Display(Name = "Modalidad")]
        public Nullable<int> ID_TIPO_INTERVALO { get; set; }
        public string DESCRIPCION_TIPO_INVERTALO { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_CRONOGRAMA { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }

        [Required]
        [Display(Name = "Fecha Fin")]
        public Nullable<System.DateTime> FECHA_FIN { get; set; }

        [Required]
        [Display(Name = "Paralelo")]
        public Nullable<int> ID_PARALELO { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }


        public List<Cronograma> ObtenerCronograma()
        {
            List<Cronograma> _cronograma = new List<Cronograma>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    var myInClause = new int[] { 1,2 };

                    _cronograma = (from cronograma in ctx.CAS_CRONOGRAMA
                                   join carrera in ctx.CAS_CARRERA on cronograma.ID_CARRERA equals carrera.ID_CARRERA
                                   join sede in ctx.CAS_SEDE on cronograma.ID_SEDE equals sede.ID_SEDE
                                   join periodo in ctx.CAS_PERIODO on cronograma.ID_PERIODO equals periodo.ID_PERIODO
                                   join tipo_intervalo in ctx.CAS_TIPO_INVERTALO on cronograma.ID_TIPO_INTERVALO equals tipo_intervalo.ID_TIPO_INTERVALO
                                   join paralelo in ctx.CAS_PARALELO on cronograma.ID_PARALELO equals paralelo.ID_PARALELO
                                   where myInClause.Contains(periodo.ESTADO.Value)
                                   select new Cronograma()
                                   {
                                       ID_CRONOGRAMA = cronograma.ID_CRONOGRAMA,
                                       DESCRIPCION_CRONOGRAMA = cronograma.DESCRIPCION_CRONOGRAMA,
                                       FECHA_INICIO = cronograma.FECHA_INICIO,
                                       FECHA_FIN = cronograma.FECHA_FIN,
                                       ID_CARRERA = carrera.ID_CARRERA,
                                       DESCRIPCION_CARRERA = carrera.DESCRIPCION_CARRERA,
                                       ID_SEDE = sede.ID_SEDE,
                                       DESCRIPCION_SEDE = sede.DESCRIPCION_UNIVERSIDAD,
                                       ID_PERIODO = periodo.ID_PERIODO,
                                       DESCRIPCION_PERIODO = periodo.DESCRIPCION_PERIODO,
                                       DESCRIPCION_TIPO_INVERTALO = tipo_intervalo.DESCRIPCION_TIPO_INVERTALO,
                                       ID_PARALELO = paralelo.ID_PARALELO,
                                       DESCRIPCION_PARALELO = paralelo.DESCRIPCION_PARALELO,
                                       ID_TIPO_INTERVALO=tipo_intervalo.ID_TIPO_INTERVALO
                                   }
                             ).ToList();
                }
                return _cronograma;
            }
            catch (Exception)
            {

                return _cronograma;
            }
        }

        Periodo _perido = new Periodo();
        public void GuardarCronograma(Cronograma cronograma)
        {
            CAS_CRONOGRAMA _cronograma = new CAS_CRONOGRAMA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    //var perido= _perido.ObtenerPeriodoActivo();
                    _cronograma.ID_CRONOGRAMA = cronograma.ID_CRONOGRAMA;
                    _cronograma.ID_CARRERA = cronograma.ID_CARRERA;
                    _cronograma.ID_SEDE = cronograma.ID_SEDE;
                    _cronograma.ID_PERIODO = cronograma.ID_PERIODO;
                    _cronograma.ID_TIPO_INTERVALO = cronograma.ID_TIPO_INTERVALO;
                    _cronograma.DESCRIPCION_CRONOGRAMA = cronograma.DESCRIPCION_CRONOGRAMA;
                    _cronograma.FECHA_INICIO = cronograma.FECHA_INICIO;
                    _cronograma.FECHA_FIN = cronograma.FECHA_FIN;
                    _cronograma.ID_PARALELO = cronograma.ID_PARALELO;

                    ctx.Entry(_cronograma).State = EntityState.Added;
                    ctx.SaveChanges();
                    int id = _cronograma.ID_CRONOGRAMA;

                    if (cronograma.ID_TIPO_INTERVALO == 1)
                    {
                        var a = ctx.sp_GenerarDetalleCronograma_Regular(cronograma.FECHA_INICIO, cronograma.FECHA_FIN, id);
                    }
                    else if (cronograma.ID_TIPO_INTERVALO == 2)
                    {
                        var a = ctx.sp_GenerarDetalleCronograma_Intensivo(cronograma.FECHA_INICIO, cronograma.FECHA_FIN, id);
                    }

                }
            }
            catch (Exception ex )
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void EliminarCronograma(int id_cronograma)
        {
            CAS_CRONOGRAMA cronograma = new CAS_CRONOGRAMA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    cronograma = ctx.CAS_CRONOGRAMA.Where(x => x.ID_CRONOGRAMA == id_cronograma).AsNoTracking().FirstOrDefault();
                    ctx.Entry(cronograma).State = EntityState.Deleted;
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
