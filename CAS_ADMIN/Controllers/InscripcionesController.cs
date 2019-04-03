using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;
using Newtonsoft.Json;
using CAS_ADMIN.Models;
using Model.Services;

namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class InscripcionesController : Controller
    {
        Inscipcion _inscripcion = new Inscipcion();
        InscripcionDetalle _inscripcionDetalle = new InscripcionDetalle();
        InscripcionDetallleCarrera detalle = new InscripcionDetallleCarrera();
        ListaInscripcion _list = new ListaInscripcion();
        InscripcionFecha fechaInscripcion = new InscripcionFecha();

        // GET: Inscripciones
        #region DatosPersonales
        public ActionResult DatosPersonales(string id)
        {

            ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "INSCRIPCION_DATOS_PERSONALES"), ServicesAuditoria.audit().CrearTag("ID_INSCRIP", id));
            return View(_inscripcion.ObtenerInscripcion(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatosPersonales(Inscipcion inscripcion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inscripcion.GuardarInscripcion(inscripcion);
                    string json = JsonConvert.SerializeObject(inscripcion);
                    ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR", ServicesAuditoria.audit().CrearTag("FORMULARIO", "INSCRIPCION_DATOS_PERSONALES"), ServicesAuditoria.audit().CrearTag("DATA", json));
                    this.AddToastMessage("Guardado", "Datos personales guardado exitosamente.", ToastType.Success);
                    return RedirectToAction("DatosCarrera", "Inscripciones", new { id = inscripcion.ID_INSCRIP });
                }
                return View(inscripcion);

            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                this.AddToastMessage("Eror", ex.Message.ToString(), ToastType.Error);
                return View(_inscripcion.ObtenerInscripcion(inscripcion.ID_INSCRIP));
            }
        }

        [HttpGet]
        public JsonResult getTableInscripciones()
        {
            try
            {
                return Json(new { data = _list.ObtenerInscripciones() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AutoComInscipcion(string Prefix)
        {
            return Json(_inscripcion.BuscarInscripciones(Prefix), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerInscripcion(string ID_INSCRIP)
        {
            return Json(_inscripcion.ObtenerInscripcion(ID_INSCRIP), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region DatosCarrera
        public ActionResult DatosCarrera(string id)
        {
            TempData["ID_INSCRIP"] = id;
            ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "DATOS_CARRERA"), ServicesAuditoria.audit().CrearTag("ID_INSCRIP", id));
            return View(detalle.ObtenerDetalle(id));
        }
        #endregion

        #region DetalleCarrera

        [Authorize]
        [HttpPost]
        public ActionResult DetalleCarrera(string ID_INSCRIP)
        {
            return PartialView("_DetalleCarrera", detalle.ObtenerDetalle(ID_INSCRIP));
        }

        #endregion

        #region AgregarCarrera
        [HttpGet]
        public ActionResult AgregarCarrera(string id = null)
        {
            try
            {
                _inscripcionDetalle.ID_INSCRIP = id;
                return View(_inscripcionDetalle);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }

        [HttpPost]
        public ActionResult AgregarCarrera(InscripcionDetalle detalle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inscripcionDetalle.GuardarDetalle(detalle);
                    string json = JsonConvert.SerializeObject(detalle);
                    ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR", ServicesAuditoria.audit().CrearTag("FORMULARIO", "DATOS_CARRERA"), ServicesAuditoria.audit().CrearTag("DATA", json));
                    return Json(new { success = true, message = "Carrera añadida exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(detalle);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region EditarCarrera
        [HttpGet]
        public ActionResult EditarCarrera(int id = 0)
        {
            try
            {
                return View(_inscripcionDetalle.ObtenerDetalle(id));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditarCarrera(InscripcionDetalle detalle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inscripcionDetalle.ActualizarDetalle(detalle);
                    string json = JsonConvert.SerializeObject(detalle);
                    ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR", ServicesAuditoria.audit().CrearTag("FORMULARIO", "DATOS_CARRERA"), ServicesAuditoria.audit().CrearTag("DATA", json));
                    return Json(new { success = true, message = "Actualizado exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(detalle);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region ImprimirInscripcion
        public FileContentResult ImprimirInscripcion(int id)
        {
            PrintPDF print = new PrintPDF();
            Helper helper = new Helper();
            byte[] bytes = print.ImprimirInscripcion(id);
            return File(bytes, "application/pdf", helper.CrearAlfaNumerico(10).ToString() + ".pdf");
        }
        #endregion

        #region NotaCarrera
        EstudianteNotaCarrera notaEstudiante = new EstudianteNotaCarrera();
        public ActionResult NotaCarrera(int id)
        {
            TempData["ID_INSCRIP_DETALLE_CARRERA"] = id;
            return View(notaEstudiante.ObtenerNotaCarrera(id));
        }

        public FileContentResult ImprimirNotaCarrera(int id)
        {
            PrintPDF print = new PrintPDF();
            Helper helper = new Helper();
            byte[] bytes = print.ImprimirNotaEstudianteCarrera(id);
            return File(bytes, "application/pdf", helper.CrearAlfaNumerico(10).ToString() + ".pdf");
        }
        #endregion

        #region AsistenciaCarrera
        EstudianteAsistenciaCarrera asistenciaCarrera = new EstudianteAsistenciaCarrera();
        public ActionResult AsistenciaCarrera(int id)
        {
            TempData["ID_INSCRIP_DETALLE_CARRERA"] = id;
            return View();
        }

        [HttpGet]
        public JsonResult getTableAsistenciaCarrera(string ID_INSCRIP_DETALLE_CARRERA)
        {
            try
            {
                return Json(new { data = asistenciaCarrera.ObtenerAsistenciaCarrera(Convert.ToInt32(ID_INSCRIP_DETALLE_CARRERA)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public FileContentResult ImprimirAsistenciaCarrera(int id)
        {
            PrintPDF print = new PrintPDF();
            Helper helper = new Helper();
            byte[] bytes = print.ImprimirAsistenciaEstudianteCarrera(id);
            return File(bytes, "application/pdf", helper.CrearAlfaNumerico(10).ToString() + ".pdf");
        }
        #endregion
    }
}