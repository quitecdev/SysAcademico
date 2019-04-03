using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;


namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class HorarioController : Controller
    {
        IntervaloDetalle _intervaloDetalle = new IntervaloDetalle();
        Intervalo _intervalo = new Intervalo();
        // GET: Horario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearIntervaloDetalle(int id=0)
        {
            return View(_intervaloDetalle.ObtenerIntervalo(id));
        }


        [HttpPost]
        public ActionResult CrearIntervaloDetalle(IntervaloDetalle intervaloDetalle)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _intervaloDetalle.GuardarIntervaloDetalle(intervaloDetalle);
                    return Json(new { success = true, message = "Horario creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(intervaloDetalle);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public JsonResult getTableIntervaloDetalle()
        {
            try
            {
                return Json(new { data = _intervaloDetalle.ObtenerIntervalo() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarHorario(int ID_INTERVALO_DETALLE)
        {
            try
            {
                _intervaloDetalle.EliminarIntervaloDetalle(ID_INTERVALO_DETALLE);
                return Json(new { success = true, message = "Horario eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }




        #region Dias
        Horario _horario = new Horario();
        public ActionResult Dias(int id = 0)
        {
            ViewBag.id_intervalo_detalle = id;
            return View(_horario.ObtenerHorario(id));
        }

        [HttpPost]
        public ActionResult Dias(Horario horario)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _horario.GuardarHorario(horario);
                    return Json(new { success = true, message = "Horario creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(horario);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DetalleHorarioDia(int ID_INTERVALO_DETALLE)
        {
            return PartialView("_DetalleHorarioDia", _horario.ObtenerDetalle(ID_INTERVALO_DETALLE));
        }

        public JsonResult EliminarHorarioDia(int ID_HORARIO)
        {
            try
            {
                _horario.EliminarHorario(ID_HORARIO);
                return Json(new { success = true, message = "Aula eliminada correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion


        public JsonResult getIntervaloDiaLibre(int id_intervalo_detalle,int id_paralelo_materia)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _horario.ObtenerDiasLibres(id_intervalo_detalle,id_paralelo_materia))
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_DIAS, Value = x.ID_DIAS.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
    }
}