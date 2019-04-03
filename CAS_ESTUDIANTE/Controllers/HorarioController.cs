using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Estudiante;
using Model.Services;

namespace CAS_ESTUDIANTE.Controllers
{
    public class HorarioController : Controller
    {
        HorarioEstudiante horario = new HorarioEstudiante();
        // GET: Horario
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "HORARIO_ESTUDIANTE"));
                return View(horario.ObtenerHorario(User.Identity.Name));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }
    }
}