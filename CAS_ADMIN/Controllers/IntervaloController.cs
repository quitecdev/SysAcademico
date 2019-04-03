using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class IntervaloController : Controller
    {
        Intervalo _intervalo = new Intervalo();
        public ActionResult AdminIntervalo(int id=0)
        {
            return View(_intervalo.ObtenerIntervalo(id));
        }

        [HttpPost]
        public ActionResult AdminIntervalo(Intervalo intervalo)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _intervalo.Guardar(intervalo);
                    return Json(new { success = true, message = "Intervalo creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(_intervalo);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarIntervalo(int ID_INTERVALO)
        {
            try
            {
                _intervalo.EliminarIntervalo(ID_INTERVALO);
                return Json(new { success = true, message = "Intervalo eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Detalle()
        {
            return PartialView("_DetalleIntervalo", _intervalo.ObtenerIntervalo());
        }

        #region Intervalo
        public JsonResult getIntervaloSedeCarrera(int id_carrera, int id_sede)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _intervalo.ObtenerIntervaloSedeCarera(id_sede, id_carrera))
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_INTERVALO, Value = x.ID_INTERVALO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        #region IntervaloDetalle
        IntervaloDetalle _intervaloDetalle = new IntervaloDetalle();
        public JsonResult getIntervaloDetalleSedeCarrera(int id_carrera, int id_sede, string id_inscrip, int id_intervalo)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _intervaloDetalle.ObtenerIntervaloCarreraSedeCarera(id_sede, id_carrera, id_inscrip, id_intervalo))
            {
                licities.Add(new SelectListItem { Text = x.INTERVALO, Value = x.ID_INTERVALO_DETALLE.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public JsonResult getIntervaloDetallePorIntervalo(int id_intervalo)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _intervaloDetalle.ObtenerIntervaloDetallePorInvertalo( id_intervalo))
            {
                licities.Add(new SelectListItem { Text = x.INTERVALO, Value = x.ID_INTERVALO_DETALLE.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        #region TipoIntervalo
        public JsonResult getTipoIntervalo()
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _intervalo.tipoIntervalo())
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_TIPO_INVERTALO, Value = x.ID_TIPO_INTERVALO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion
    }
}