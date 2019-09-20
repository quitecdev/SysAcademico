using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Services.Docente;
using Model.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Model.Services.Admin;
using System.Web.Mvc;
using System.Web;
using System.IO;
using AfsEncripta;

namespace Model.Services.Docente
{
    public class Tarea
    {
        public int ID_TAREA { get; set; }
        public int ID_SEDE { get; set; }
        public int ID_CARRERA { get; set; }
        public int ID_MATERIA { get; set; }
        public int ID_PARALELO { get; set; }
        public int ID_INTERVALO_DETALLE { get; set; }
        public string ID_DOCENTE { get; set; }

        public List<HttpPostedFileBase> Files { get; set; }

        [Display(Name = "Tema")]
        [Required]
        public string TEMA_TAREA { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        [AllowHtml]
        public string DESCRIPCION_TAREA { get; set; }
        public System.DateTime FECHA_CREACION_TAREA { get; set; }
        [Display(Name = "Fecha Entrega")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime FECHA_FIN_TAREA { get; set; }
        public Nullable<int> ID_PERIODO { get; set; }

        Periodo _periodo = new Periodo();
        readonly Encripta _enc = new Encripta();
        public void GuardarTarea(Tarea tarea)
        {
            CAS_TAREAS _tarea = new CAS_TAREAS();
            try
            {
                int? id_periodo = _periodo.ObtenerPeriodoActivo().ID_PERIODO;
                using (var ctx = new CAS_DataEntities())
                {

                    _tarea.ID_TAREA = tarea.ID_TAREA;
                    _tarea.ID_SEDE = tarea.ID_SEDE;
                    _tarea.ID_CARRERA = tarea.ID_CARRERA;
                    _tarea.ID_MATERIA = tarea.ID_MATERIA;
                    _tarea.ID_PARALELO = tarea.ID_PARALELO;
                    _tarea.ID_INTERVALO_DETALLE = tarea.ID_INTERVALO_DETALLE;
                    _tarea.ID_DOCENTE = tarea.ID_DOCENTE;
                    _tarea.TEMA_TAREA = tarea.TEMA_TAREA;
                    _tarea.DESCRIPCION_TAREA = tarea.DESCRIPCION_TAREA;
                    _tarea.FECHA_CREACION_TAREA = DateTime.Now;

                    var nuevaFecha = tarea.FECHA_FIN_TAREA.AddHours(23).AddMinutes(59).AddSeconds(59);
                    _tarea.FECHA_FIN_TAREA = nuevaFecha;

                    _tarea.ID_PERIODO = id_periodo;
                    ctx.Entry(_tarea).State = EntityState.Added;
                    ctx.SaveChanges();

                    int id = _tarea.ID_TAREA;
                    GenerarTareaEstudiante(id);
                    foreach (var item in tarea.Files)
                    {
                        GuardarAdjunto(item, id, tarea.ID_DOCENTE);
                    }
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }


        public void GuardarAdjunto(HttpPostedFileBase file, int id, string ID_DOCENTE)
        {
            try
            {

                if (file != null && file.ContentLength > 0)
                {
                    string directorio = "~/Docente/Tareas/" + _enc.HashString(ID_DOCENTE);

                    string verificar = HttpContext.Current.Server.MapPath(directorio);
                    if (!Directory.Exists(verificar))
                    {
                        Directory.CreateDirectory(verificar);
                    }

                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(HttpContext.Current.Server.MapPath(directorio), fileName);
                    file.SaveAs(path);
                    using (var ctx = new CAS_DataEntities())
                    {
                        CAS_TAREA_ADJUNTO adjunto = new CAS_TAREA_ADJUNTO();

                        adjunto.ID_TAREA = id;
                        adjunto.PATH_ADJUNTO = directorio + "/" + fileName;
                        adjunto.NOMBRE_ADJUNTO = fileName;
                        ctx.Entry(adjunto).State = EntityState.Added;
                        ctx.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }


        }

        public void GenerarTareaEstudiante(int ID_TAREA)
        {
            try
            {
                using (var ctx = new CAS_DataEntities())
                {

                    ctx.SP_GenerarTareaEstudiante(ID_TAREA);
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }
    }
}
