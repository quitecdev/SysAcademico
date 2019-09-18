using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Docente;
using Model.Services;

namespace CAS_DOCENTE.Controllers
{
    public class TareasController : Controller
    {
        HorarioTarea tarea = new HorarioTarea();
        // GET: Tareas
        public ActionResult Index()
        {
            return View(tarea.ObtenerHorarioTarea(User.Identity.Name));
        }

        public ActionResult Crear(int ID_SEDE, int ID_CARRERA, int ID_MATERIA, int ID_PARALELO,int ID_INTERVALO_DETALLE)
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CREAR_TAREA"));
                //return View(repositorio.ObtenerRepositorioDocente(ID_SEDE, ID_CARRERA, ID_TIPO_INTERVALO, ID_PARALELO));
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