using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Estudiante;

namespace CAS_ESTUDIANTE.Controllers
{
    [Authorize]
    public class EncuestasController : Controller
    {

        EncustaEvalucionDocente_Regular _encuesta = new EncustaEvalucionDocente_Regular();
        EncuestaRespuesta_Regular _respuesta = new EncuestaRespuesta_Regular();
        // GET: Encuestas
        public ActionResult evalucionDocentes()
        {
            bool isExist = false;
            isExist = _encuesta.ValidarEncuesta(User.Identity.Name);
            if(isExist)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_encuesta.ObtenerEncuesta(User.Identity.Name));
        }

        public JsonResult GuardarEncuesta(List<EncuestaRespuesta_Regular> opciones)
        {
            _respuesta.GuardarEncuesta(opciones);
            return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
        }
    }
}