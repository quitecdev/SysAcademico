using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    public class ParaleloController : Controller
    {
        Paralelo _paralelo = new Paralelo();
        #region Paralelo
        // GET: Paralelo
        public ActionResult Index(int id = 0)
        {
            return View(_paralelo.ObtenerParalelo(id));
        }

        [HttpPost]
        public ActionResult Index(Paralelo paralelo)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _paralelo.GuardarParalelo(paralelo);
                    return Json(new { success = true, message = "Paralelo creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(paralelo);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarParalelo(int ID_PARALELO)
        {
            try
            {
                _paralelo.EliminarParalelo(ID_PARALELO);
                return Json(new { success = true, message = "Paralelo eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Detalle()
        {
            return PartialView("_DetalleParalelo", _paralelo.ObtenerParalelo());
        }

        public JsonResult getParalelo()
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _paralelo.ObtenerParalelo())
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_PARALELO, Value = x.ID_PARALELO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public JsonResult getParaleloSedeCarrera(int id_carrera, int id_sede, int id_intervalo, int id_intervaloDetalle)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _paralelo.ObtenerParaleloCarreraSedeCarera(id_sede, id_carrera, id_intervalo, id_intervaloDetalle))
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_PARALELO, Value = x.ID_PARALELO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public JsonResult getParaleloSedeMateria (int id_sede, int id_materia,bool estado=false)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _paralelo.ObtenerParalelo(id_sede,id_materia, estado))
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_PARALELO, Value = x.ID_PARALELO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion
    }
}