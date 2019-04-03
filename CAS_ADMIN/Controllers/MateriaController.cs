using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class MateriaController : Controller
    {
        Materia _materia = new Materia();
        #region CreraMateria
        public ActionResult CrearMateria(int id = 0)
        {
            _materia.ID_CARRERA = id;
            TempData["ID_CARRERA"] = id;
            return View(_materia);
        }

        [HttpPost]
        public ActionResult CrearMateria(Materia materia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _materia.GuardarMateria(materia);
                    return Json(new { success = true, message = "Materia creada exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(materia);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region EditarMateria
        public ActionResult EditarMateria(int id)
        {
            TempData["ID_CARRERA"] = _materia.ObtenerMateria(id).ID_CARRERA;
            return View(_materia.ObtenerMateria(id));
        }

        [HttpPost]
        public ActionResult EditarMateria(Materia materia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _materia.GuardarMateria(materia);
                    return Json(new { success = true, message = "Materia actualizada exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(materia);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        public ActionResult Detalle(int ID_CARRERA)
        {
            return PartialView("_DetalleMateria", _materia.ObtenerMaterias(ID_CARRERA));
        }


        #region Intervalo
        public JsonResult getMateria(int id_carrera)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _materia.ObtenerMaterias(id_carrera))
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_MATERIA, Value = x.ID_MATERIA.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion
    }
}