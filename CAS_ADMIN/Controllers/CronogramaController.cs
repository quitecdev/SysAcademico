using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;
using CAS_ADMIN.Models;
using System.IO;

namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class CronogramaController : Controller
    {
        Cronograma _cronograma = new Cronograma();
        // GET: Cronograma
        #region Cronograma
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getTableCronograma()
        {
            try
            {
                return Json(new { data = _cronograma.ObtenerCronograma() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region CrearCronograma
        public ActionResult CrearCronograma(int id = 0)
        {
            return View(_cronograma);
        }
        [HttpPost]
        public ActionResult CrearCronograma(Cronograma cronograma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cronograma.GuardarCronograma(cronograma);
                    return Json(new { success = true, message = "Cronograma creado exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = true, message = "Error" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        public JsonResult EliminarCronograma(int ID_CRONOGRAMA)
        {
            try
            {
                _cronograma.EliminarCronograma(ID_CRONOGRAMA);
                return Json(new { success = true, message = "Cronograma eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #region CronogramaDetalle
        CronogramaDetalle _cronogramaDetalle = new CronogramaDetalle();
        public ActionResult CronogramaDetalle(int id)
        {
            ViewData["ID_CRONOGRAMA"] = id;
            return View();
        }

        [HttpGet]
        public JsonResult getTableCronogramaDetalle(int id_cronograma)
        {
            try
            {
                return Json(new { data = _cronogramaDetalle.ObtenerCronogramaDetalle(id_cronograma) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region EditarCronogramaDetalle
        public ActionResult EditarCronogramaDetalle(int id)
        {
            return View(_cronogramaDetalle.CronogramaDetalleObtener(id));
        }

        [HttpPost]
        public ActionResult EditarCronogramaDetalle(CronogramaDetalle cronograma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cronogramaDetalle.GuardarCronogramaDetalle(cronograma);
                    return Json(new { success = true, message = "Carrera creada exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(_cronogramaDetalle.CronogramaDetalleObtener(cronograma.ID_CRONOGRAMA_DETALLE));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region AdjuntoCronograma
        CronogramaAdjunto _adjunto = new CronogramaAdjunto();
        public ActionResult AdjuntoCronograma(int id)
        {
            ViewData["ID_CRONOGRAMA_DETALLE"] = id;
            _adjunto.ID_CRONOGRAMA_DETALLE = id;
            return View(_adjunto);
        }


        FileUpload upload = new FileUpload();
        [HttpPost]
        public ActionResult AdjuntoCronograma(CronogramaAdjunto adjunto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var archivo in adjunto.Files)
                    {
                        upload.GuardarArchivoRepositorio(archivo,adjunto.ID_CARPETA.Value,adjunto.ID_CRONOGRAMA_DETALLE.Value);
                    }

                    return Json(new { success = true, message = "Adjunto subido exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(_adjunto);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DetalleAdjunto(int id)
        {
            return PartialView("_DetalleAdjunto", _adjunto.ObtenerAdjunto(id));
        }

        public JsonResult EliminarAdjunto(int ID_CRONOGRAMA_ADJUNTO)
        {
            try
            {
                _adjunto.EliminarAdjunto(ID_CRONOGRAMA_ADJUNTO);
                return Json(new { success = true, message = "Adjunto eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}