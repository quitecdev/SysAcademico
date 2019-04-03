using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Docente;
using Model.Services;
using CAS_DOCENTE.Models;
namespace CAS_DOCENTE.Controllers
{
    [Authorize]
    public class AsistenciaController : Controller
    {
        AsistenciaDocente asistencia = new AsistenciaDocente();
        // GET: Asistencia
        public ActionResult Index()
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "ASISTENCIA_DOCENTE"));
                return View(asistencia.ObtenerAsistencia(User.Identity.Name));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Index(AsistenciaDocente _datos)
        {
            try
            {
                asistencia.GuardarAsistencia(_datos);
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR_ASISTENCIA_DOCENTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "ASISTENCIA_DOCENTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ESTADO", "GUARDADO"));
                this.AddToastMessage("Asistencia", "Su asistencia se ha guardado correctamente.", ToastType.Success);
                return View(asistencia.ObtenerAsistencia(User.Identity.Name));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                this.AddToastMessage("Asistencia", "Error al guardar su asistencia.", ToastType.Error);
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR_ASISTENCIA_DOCENTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "ASISTENCIA_DOCENTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ESTADO", "ERROR"));
                return View();
            }
        }
    }
}