using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    public class NotificacionesController : Controller
    {
        Notificacion _notificacion = new Notificacion();

        [Authorize]
        [HttpPost]
        public ActionResult Notificacion()
        {

            return PartialView("_Notificacion", _notificacion.ObterNotificacion(User.Identity.Name));
        }

        [Authorize]
        [HttpPost]
        public JsonResult ContadorNotificacion()
        {
            var output = _notificacion.Contador(User.Identity.Name);
            return Json(output, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult NotificacionVer(string ID_NOTIFICACION)
        {
            int id = Convert.ToInt32(ID_NOTIFICACION);
            return View(_notificacion.VerNotificacion(id));
        }

        Sugerencia _sugerencia = new Sugerencia();
        [Authorize]
        [HttpGet]
        public ActionResult SugerenciaVer(int ID_NOTIFICACION)
        {
            
            return View(_sugerencia.ObtenerNotificacion(ID_NOTIFICACION));
        }

        [HttpPost]
        public ActionResult SugerenciaVer(Sugerencia sugerencia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _notificacion.EnviarRespuest(sugerencia);
                    return Json(new { success = true, message = "Notificacion enviada exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(sugerencia);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}