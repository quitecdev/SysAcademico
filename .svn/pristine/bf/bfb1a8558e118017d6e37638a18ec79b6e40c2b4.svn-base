using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Estudiante;

namespace CAS_ESTUDIANTE.Controllers
{
    [Authorize]
    public class RepositorioEstudianteController : Controller
    {
        #region RepositorioEstudiante
        // GET: RepositorioEstudiante
        RepositorioEstudiante repositorioEstudiante = new RepositorioEstudiante();
        public ActionResult Index()
        {
            return View(repositorioEstudiante.ObtenerRepositorioEstudiante(User.Identity.Name));
        }
        #endregion
    }
}