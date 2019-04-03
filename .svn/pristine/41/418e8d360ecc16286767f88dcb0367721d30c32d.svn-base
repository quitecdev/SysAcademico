using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services;
using Model.Services.Docente;
using CAS_DOCENTE.Models;

namespace CAS_DOCENTE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "INICIO"));
                this.AddToastMessage("Asistencia", "Estimados docentes se ha realizado cambios en la plataforma de tal manera que se tomara asistencia 15 minutos antes de finalizar la clase y hasta máximo 15 minutos después de terminada la clase. Con esto es indispensable completar dicha acción ya que las faltas afectaran directamente a los estudiantes, muchas gracias contamos con su apoyo.", ToastType.Info);
                return View();
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }
    }
}