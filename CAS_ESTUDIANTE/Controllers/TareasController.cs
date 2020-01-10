using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Data;
using Model.Services.Estudiante;
using CAS_ESTUDIANTE.Models;

namespace CAS_ESTUDIANTE.Controllers
{
    public class TareasController : Controller
    {

        Tareas _tareas = new Tareas();
        TareaDetalle _detalle = new TareaDetalle();
        // GET: Tareas
        public ActionResult Index()
        {
            try
            {
                return View(_tareas.ObtenerDetalleTarea(User.Identity.Name));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }

        public ActionResult Detalle(int id)
        {
            try
            {
                return View(_detalle.ObtenerDetalleTarea(id));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Detalle(TareaDetalle tarea)
        {
            if (ModelState.IsValid)
            {
                _detalle.GuardarDetalle(tarea);
                this.AddToastMessage("Tarea", "Su tarea a sido enviada exitosamente.", ToastType.Success);
                return RedirectToAction("Index","Tareas");
            }
            return View(tarea);
        }
    }
}