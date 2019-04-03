using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Estudiante;

namespace CAS_ESTUDIANTE.Controllers
{
    [Authorize]
    public class NotaEstudianteController : Controller
    {
        #region Nota
        EstudianteNota nota = new EstudianteNota();
        // GET: NotaEstudiante
        public ActionResult Index()
        {
            return View(nota.ObtenerNota(User.Identity.Name));
        }
        #endregion
    }
}