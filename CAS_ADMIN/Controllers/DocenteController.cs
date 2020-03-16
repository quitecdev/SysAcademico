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
    public class DocenteController : Controller
    {
        Docente _docente = new Docente();
        // GET: Docente
        #region Docente
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getTableDocente()
        {
            try
            {
                return Json(new { data = _docente.ObtenerDocentes() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarDocente(string ID_DOCENTE)
        {
            try
            {
                _docente.EliminarDocente(ID_DOCENTE);
                return Json(new { success = true, message = "Horario eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region AgregarDocente
        public ActionResult AgregarDocente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarDocente(Docente docente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _docente.GuardarDocente(docente);
                    return Json(new { success = true, message = "Docente añadido exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(docente);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region EditarDocente
        public ActionResult EditarDocente(string id)
        {
            return View(_docente.ObtenerDocente(id));
        }

        [HttpPost]
        public ActionResult EditarDocente(Docente docente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _docente.GuardarDocente(docente);
                    return Json(new { success = true, message = "Docente actualizado exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(docente);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region HorarioDocente
        Model.Services.Docente.HorarioDocente horarioDocente = new Model.Services.Docente.HorarioDocente();
        public ActionResult HorarioDocente(string id)
        {
            return View(horarioDocente.ObtenerHorario(id));
        }
        DocenteHorarioMateria docenteMateria = new DocenteHorarioMateria();
        public ActionResult HorarioDocenteDetalle(string id)
        {
            return View(docenteMateria.ObtenerHorarioMateria(id));
        }

        [HttpPost]
        public ActionResult HorarioDocenteDetalle(DocenteHorarioMateria docenteHorario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    docenteMateria.GuardarHorario(docenteHorario);
                    return Json(new { success = true, message = "Docente añadido exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(docenteHorario);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult DetalleHorario(string ID_DOCENTE)
        {
            return PartialView("_DetalleHorario", docenteMateria.ObtenerHorarioMateria(ID_DOCENTE).ListaDocente);
        }

        public JsonResult EliminarHorario(int ID_ID_DOCENTE_MATERIA_PARALELO)
        {
            try
            {
                docenteMateria.EliminarHorario(ID_ID_DOCENTE_MATERIA_PARALELO);
                return Json(new { success = true, message = "Horario eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public FileContentResult ImprimirHorarioDocente(string id)
        {
            PrintPDF print = new PrintPDF();
            Helper helper = new Helper();
            byte[] bytes = print.ImprimirHorarioDocente(id);
            return File(bytes, "application/pdf", helper.CrearAlfaNumerico(10).ToString()+ ".pdf");
        }

        #endregion

        #region RepositorioDocente
        Model.Services.Docente.CarreraIntervalo carrera = new Model.Services.Docente.CarreraIntervalo();
        public ActionResult RepositorioDocente(string id)
        {
            TempData["ID_DOCENTE"] = id;
            return View(carrera.ObtenerCarreras(id));
        }

        Model.Services.Docente.RepositorioDocente repositorio = new Model.Services.Docente.RepositorioDocente();
        public ActionResult RepositorioDocenteVista(int ID_SEDE, int ID_CARRERA, int ID_TIPO_INTERVALO,int ID_PARALELO)
        {
            try
            {
                var ID_DOCENTE = TempData["ID_DOCENTE"];
                TempData["ID_DOCENTE"] = ID_DOCENTE;
                //ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "REPOSITORIO_DOCENTE"));
                return View(repositorio.ObtenerRepositorioDocente(ID_SEDE, ID_CARRERA, ID_TIPO_INTERVALO, ID_PARALELO));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }
        #endregion

        #region NotasDocentes
        Model.Services.Docente.NotasAsignadas notasAsiganadas = new Model.Services.Docente.NotasAsignadas();
        public ActionResult NotasDocente(string id)
        {
            var data = _docente.ObtenerDocente(id);
            TempData["ID_DOCENTE"] = id;
            TempData["NOMBRE"] = data.APELLIDO_PATERNO_DOCENTE+" "+ data.PRIMER_NOMBRE_DOCENTE;
            return View(notasAsiganadas.Obtener(id));
        }

        Model.Services.Docente.Notas _notas = new Model.Services.Docente.Notas();
        Model.Services.Docente.Calificar _calificar = new Model.Services.Docente.Calificar();
        public ActionResult NotasDocenteVista(int ID_PERIODO,int ID_SEDE, int ID_CARRERA, int ID_NOTA, int ID_INTERVALO_DETALLE,string ID_DOCENTE)
        {
            try
            {
                TempData["ID_SEDE"] = ID_SEDE;
                TempData["ID_CARRERA"] = ID_CARRERA;
                TempData["ID_NOTA"] = ID_NOTA;
                TempData["ID_INTERVALO_DETALLE"] = ID_INTERVALO_DETALLE;
                TempData["ID_DOCENTE"] = ID_DOCENTE;
                return View(_calificar.ObtenerLibreta(ID_PERIODO,ID_SEDE, ID_CARRERA, ID_NOTA, ID_INTERVALO_DETALLE, ID_DOCENTE));
            }
            catch (Exception ex)
            {

                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }

        public FileContentResult ImprimirNotaDocente(int ID_PERIODO,int ID_SEDE, int ID_CARRERA, int ID_NOTA, int ID_INTERVALO_DETALLE, string ID_DOCENTE)
        {
            PrintPDF print = new PrintPDF();
            Helper helper = new Helper();
            byte[] bytes = print.ImprimirNotaDocente(ID_PERIODO,ID_SEDE, ID_CARRERA, ID_NOTA, ID_INTERVALO_DETALLE, ID_DOCENTE);
            return File(bytes, "application/pdf", helper.CrearAlfaNumerico(10).ToString() + ".pdf");
        }
        #endregion

        #region AsistenciaDocente
        DocenteAsistencia asistencia = new DocenteAsistencia();
        // GET: Asistencia
        public ActionResult AsistenciaDocente(string id)
        {
            try
            {
                TempData["ID_DOCENTE"] = id;
                //ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "ASISTENCIA_DOCENTE"));
                //return View(asistencia.ObtenerAsistencia(id));
                return View();
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }

        }

        [HttpGet]
        public JsonResult getTableDocenteAsistencia(string ID_DOCENTE)
        {
            try
            {
                return Json(new { data = asistencia.ObtenerAsistencia(ID_DOCENTE) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public FileContentResult ImprimirAsistenciaDocente(string id)
        {
            PrintPDF print = new PrintPDF();
            Helper helper = new Helper();
            byte[] bytes = print.ImprimirAsistenciaDocente(id);
            return File(bytes, "application/pdf", helper.CrearAlfaNumerico(10).ToString() + ".pdf");
        }
        #endregion

        #region getCarreraSede
        public JsonResult getDocentes()
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _docente.ObtenerDocentes())
            {
                //licities.Add(new SelectListItem { Text = x.DESCRIPCION_INTERVALO, Value = x.ID_INTERVALO.ToString() });
                licities.Add(new SelectListItem { Text = x.APELLIDO_PATERNO_DOCENTE+" "+x.APELLIDO_MATERNO_DOCENTE+" "+x.PRIMER_NOMBRE_DOCENTE+" "+x.PRIMER_NOMBRE_DOCENTE, Value = x.ID_DOCENTE.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

    }
}