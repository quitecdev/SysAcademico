using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Data;
using Model.Services.Estudiante;

namespace CAS_ESTUDIANTE.Controllers
{
    public class TareasController : Controller
    {

        Tareas _tareas = new Tareas();
        TareaDetalle _detalle = new TareaDetalle();
        // GET: Tareas
        public ActionResult Index()
        {
            return View(_tareas.ObtenerDetalleTarea(User.Identity.Name));
        }

        public ActionResult Detalle(int id)
        {
            return View(_detalle.ObtenerDetalleTarea(id));
        }

        [HttpPost]
        public ActionResult Detalle(TareaDetalle tarea)
        {
            return View();
        }
    }
}