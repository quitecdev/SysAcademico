using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    public class NotasController : Controller
    {
        Nota _nota = new Nota();
        NotaDetalle _notaDetalle = new NotaDetalle();
        NotaPonderacion _notaPonderacion = new NotaPonderacion();
        // GET: Notas
        #region Notas
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region CrearNota
        public ActionResult CreaNotas(int id = 0)
        {
            return View(_nota.ObtenerNota(id));
        }
        [HttpPost]
        public ActionResult CreaNotas(Nota nota)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _nota.GuardarNota(nota);
                return Json(new { success = true, message = "Nota creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(carrera);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion

        #region NotaDetalle
        public ActionResult NotaDetalle(int id)
        {
            TempData["ID_NOTA"] = id;
            TempData["DESCRIPCION_NOTA"] = _nota.ObtenerNota(id).DESCRIPCION_NOTA;
            return View(_notaDetalle.ObtenerNotasDetalle(id));
        }
        #endregion

        #region DetalleNota
        [Authorize]
        [HttpPost]
        public ActionResult DetalleNota(int ID_NOTA)
        {
            return PartialView("_DetalleNota", _notaDetalle.ObtenerNotasDetalle(ID_NOTA));
        }
        #endregion

        #region CrearNotaDetalle
        public ActionResult CrearNotaDetalle(int ID_NOTA,int ID_NOTA_DETALLE)
        {
            return View(_notaDetalle.ObtenerNotaDetalle(ID_NOTA_DETALLE, ID_NOTA));
        }

        [HttpPost]
        public ActionResult CrearNotaDetalle(NotaDetalle notaDetalle)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _notaDetalle.GuardarNotaDetalle(notaDetalle);
                return Json(new { success = true, message = "Nota creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(carrera);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region NotaPonderacion
        public ActionResult NotaPonderacion(int id)
        {
            TempData["ID_NOTA_DETALLE"] = id;
            TempData["DESCRIPCION_NOTA"] = _nota.ObtenerNotaPorPonderacion(id).DESCRIPCION_NOTA;
            TempData["DESCRIPCION_NOTA_DETALLE"] = _notaDetalle.ObtenerNotaDetallePorPonderacion(id).DESCRIPCION_NOTA_DETALLE;
            
           return View(_notaPonderacion.ObtenerNotasPonderacion(id));
        }
        #endregion

        #region DetalleNota
        [Authorize]
        [HttpPost]
        public ActionResult DetallePonderacion(int ID_NOTA_DETALLE)
        {
            return PartialView("_DetallePonderacion", _notaPonderacion.ObtenerNotasPonderacion(ID_NOTA_DETALLE));
        }
        #endregion

        #region CrearNotaPonderacion
        public ActionResult CrearNotaPonderacion(int ID_NOTA_DETALLE, int ID_PONDERACION)
        {
            return View(_notaPonderacion.ObtenerNotaPonderacion(ID_NOTA_DETALLE, ID_PONDERACION));
        }

        [HttpPost]
        public ActionResult CrearNotaPonderacion(NotaPonderacion notaPonderacion)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _notaPonderacion.GuardarNotaPonderacion(notaPonderacion);
                return Json(new { success = true, message = "Nota creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(carrera);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        NotaDocente _notaDocente = new NotaDocente();
        #region Asiganacion
        public ActionResult Asignacion()
        {
            return View(_notaDocente.ObtenerNotaDocente());
        }
        #endregion

        #region  getTableNota
        [HttpGet]
        public JsonResult getTableNota()
        {
            try
            {
                return Json(new { data = _nota.ObtenerNotas() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region getNota
        public JsonResult getNota(int id_carrera, int id_periodo)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _nota.ObtenerNotaCarreraPeriodo(id_carrera,id_periodo))
            {
                //licities.Add(new SelectListItem { Text = x.DESCRIPCION_INTERVALO, Value = x.ID_INTERVALO.ToString() });
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_NOTA, Value = x.ID_NOTA.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        #region getNotaDetalle
        public JsonResult getNotaDetalle(int id_nota)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _nota.ObtenerNotaDetalle(id_nota))
            {
                //licities.Add(new SelectListItem { Text = x.DESCRIPCION_INTERVALO, Value = x.ID_INTERVALO.ToString() });
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_NOTA_DETALLE, Value = x.ID_NOTA_DETALLE.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        #region getNotaPonderacion
        public JsonResult getNotaPonderacion(int id_notaDetalle,int id_sede)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _notaPonderacion.ObtenerNotasPonderacionNoAsignadas(id_notaDetalle, id_sede))
            {
                //licities.Add(new SelectListItem { Text = x.DESCRIPCION_INTERVALO, Value = x.ID_INTERVALO.ToString() });
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_PONDERACION, Value = x.ID_PONDERACION.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        //#region ObtenerDocenteNota
        //[HttpPost]
        //public JsonResult ObtenerDocenteNota(int id_periodo, int id_sede, int id_carrera, int id_nota, int id_notaDetalle)
        //{
        //    try
        //    {
        //        return Json(new { data = _nota.ObtenerDetalle(id_periodo, id_sede, id_carrera, id_nota, id_notaDetalle) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServicesTrackError.RegistrarError(ex);
        //        return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //#endregion

        #region DetalleAsignacion
        [Authorize]
        [HttpPost]
        public ActionResult DetalleAsignacion(int id_periodo, int id_sede, int id_carrera, int id_nota, int id_notaDetalle)
        {
            return PartialView("_DetalleAsignacion", _nota.ObtenerDetalle(id_periodo, id_sede, id_carrera, id_nota, id_notaDetalle));
        }
        #endregion

        #region ActualizarFechaInicio
        [HttpPost]
        public JsonResult ActualizarFechaInicio(int ID_DOCENTE_NOTA, string FECHA_INICIO)
        {
            try
            {
                _notaDocente.ActualizarFechaInicio(ID_DOCENTE_NOTA, FECHA_INICIO);
                return Json(new { success = true, message = "Guardado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region ActualizarFechaFin
        [HttpPost]
        public JsonResult ActualizarFechaFin(int ID_DOCENTE_NOTA, string FECHA_FIN)
        {
            try
            {
                _notaDocente.ActualizarFechaFin(ID_DOCENTE_NOTA, FECHA_FIN);
                return Json(new { success = true, message = "Guardado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region CrearNota
        public ActionResult CrearAsignacion(int id = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearAsignacion(NotaDocente nota)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _nota.GuardarAsiganacion(nota);
                return Json(new { success = true, message = "Nota asignada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(carrera);
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