using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    public class SedeController : Controller
    {
        Sede _sede = new Sede();
        // GET: Sede
        public ActionResult Index(int id =0)
        {
            return View(_sede.ObtenerSede(id));
        }

        [HttpPost]
        public ActionResult Index(Sede sede)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _sede.GuardarSede(sede);
                    return Json(new { success = true, message = "Sede creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(_sede);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarSede(int ID_SEDE)
        {
            try
            {
                _sede.EliminarSede(ID_SEDE);
                return Json(new { success = true, message = "Sede eliminada correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detalle()
        {
            return PartialView("_DetalleSede", _sede.ObtenerSede());
        }
    }
}