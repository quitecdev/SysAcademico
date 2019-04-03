using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;
using CAS_ADMIN.Models;

namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class EstudianteController : Controller
    {
        Estudiante _estudiante = new Estudiante();
        InscripcionDetallleCarrera detalle = new InscripcionDetallleCarrera();
        Inscipcion _inscripcion = new Inscipcion();
        InscripcionDetalle _inscripcionDetalle = new InscripcionDetalle();
        EstudianteNotaCarrera notaEstudiante = new EstudianteNotaCarrera();
        Model.Services.Docente.Calificar _calificar = new Model.Services.Docente.Calificar();

        #region Estudiantes
        // GET: Estudiante
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getTableEstudiante()
        {
            try
            {
                return Json(new { data = _estudiante.ObtenerEstudiantes() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region EditarEstudiante
        public ActionResult EditarEstudiante(string id)
        {
            return View(_estudiante.ObtenerEstudiante(id));
        }
        [HttpPost]
        public ActionResult EditarEstudiante(Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _estudiante.GuardarEstudiante(estudiante);
                    return Json(new { success = true, message = "Estudiante actualizado exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(estudiante);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region DatosCarrera
        public ActionResult DatosCarrera(string id)
        {
            TempData["ID_INSCRIP"] = id;
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

        #region EliminarDetalle
        public JsonResult EliminarDetalle(string ID_INSCRIP_DETALLE_CARRERA)
        {
            try
            {
                detalle.EliminarDetalleCarrera(Convert.ToInt32(ID_INSCRIP_DETALLE_CARRERA));
                return Json(new { success = true, message = "Detalle eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region NotaCarrera
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

        #region EditarNotas
        public ActionResult EditarNotas(int id)
        {
            return View(notaEstudiante.ObtenerNotaCarrera(id));
        }


        [HttpPost]
        public JsonResult ActualizarNota(string ID_NOTA, string VALOR)
        {
            try
            {
                _calificar.ActulizarNota(Convert.ToInt32(ID_NOTA), Convert.ToDecimal(VALOR));
                //ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR_NOTA_ESTUDIANTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "NOTA_ESTUDIANTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ID_ESTUDIANTE_NOTA", ID_NOTA), ServicesAuditoria.audit().CrearTag("VALOR_NOTA", VALOR), ServicesAuditoria.audit().CrearTag("ESTADO", "GUARDADO"));
                return Json(new { success = true, message = "Guardado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
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
                var a = asistenciaCarrera.ObtenerAsistenciaCarrera(Convert.ToInt32(ID_INSCRIP_DETALLE_CARRERA));
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

        [HttpPost]
        public ActionResult JustificarFalta(int id)
        {
            try
            {
                asistenciaCarrera.JustificarFalta(id);
                return Json(new { success = true, message = "Justificación exitosa" }, JsonRequestBehavior.AllowGet);
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