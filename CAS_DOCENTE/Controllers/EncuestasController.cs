using Model.Services.Docente;
using Model.Services.Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAS_DOCENTE.Controllers
{
    [Authorize]
    public class EncuestasController : Controller
    {

        EncuestaDocente _encuesta = new EncuestaDocente();
        EncuestaRespuesta_Regular _respuesta = new EncuestaRespuesta_Regular();
        // GET: Encuestas
        public ActionResult evalucionDocentes()
        {
            bool isExist = false;
            isExist = _encuesta.ValidarEncuesta(User.Identity.Name);
            if (isExist)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_encuesta.ObtenerEncuesta(User.Identity.Name));
        }

        public JsonResult GuardarEncuesta(List<EncuestaRespuesta_Regular> opciones, string texto)
        {
            _respuesta.GuardarEncuesta(opciones);
            if (!string.IsNullOrEmpty(texto))
            {
                _respuesta.GuardarObservacion(texto);
            }
            
            return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
        }
    }
}