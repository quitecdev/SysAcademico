using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Estudiante;
using Model.Services;

namespace CAS_ESTUDIANTE.Controllers
{
    [Authorize]
    public class AsistenciaController : Controller
    {
        EstudianteAsistencia asistencia = new EstudianteAsistencia();
        // GET: Asistencia
        public ActionResult Index()
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "HORARIO_ESTUDIANTE"));
                return View(asistencia.ObtenerAsistencia(User.Identity.Name));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }
    }
}