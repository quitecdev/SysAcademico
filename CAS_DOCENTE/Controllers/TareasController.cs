using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Docente;
using Model.Services;
using Newtonsoft.Json;

namespace CAS_DOCENTE.Controllers
{
    public class TareasController : Controller
    {
        HorarioTarea _horarioTarea = new HorarioTarea();
        Tarea _tarea = new Tarea();
        TareaDetalle _datelle = new TareaDetalle();
        TareaCalificacion _calificar = new TareaCalificacion();
        #region HorarioTarea
        // GET: Tareas
        public ActionResult Index()
        {
            return View(_horarioTarea.ObtenerHorarioTarea(User.Identity.Name));
        }

        #endregion

        #region CreaTarea
        public ActionResult Crear(int ID_SEDE, int ID_CARRERA, int ID_MATERIA, int ID_PARALELO, int ID_INTERVALO_DETALLE)
        {
            try
            {
                Tarea tarea = new Tarea();
                tarea.ID_SEDE = ID_SEDE;
                tarea.ID_CARRERA = ID_CARRERA;
                tarea.ID_MATERIA = ID_MATERIA;
                tarea.ID_PARALELO = ID_PARALELO;
                tarea.ID_INTERVALO_DETALLE = ID_INTERVALO_DETALLE;
                tarea.ID_DOCENTE = User.Identity.Name;
                tarea.FECHA_FIN_TAREA = DateTime.Now;
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CREAR_TAREA"));
                return View(tarea);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Crear(Tarea tarea)
        {
            try
            {
                _tarea.GuardarTarea(tarea);
                string json = JsonConvert.SerializeObject(tarea);
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CREAR_TAREA"), ServicesAuditoria.audit().CrearTag("DATA", json));
                return Redirect("DetalleTareas/" + tarea.ID_SEDE+"/"+tarea.ID_CARRERA+"/"+tarea.ID_MATERIA+"/"+tarea.ID_PARALELO+"/"+tarea.ID_INTERVALO_DETALLE);
                //return RedirectToAction("Index","Tareas");
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Redirect("DetalleTareas/" + tarea.ID_SEDE + "/" + tarea.ID_CARRERA + "/" + tarea.ID_MATERIA + "/" + tarea.ID_PARALELO + "/" + tarea.ID_INTERVALO_DETALLE);
            }
        }
        #endregion

        #region DetalleTareas
        public ActionResult DetalleTareas(int ID_SEDE, int ID_CARRERA, int ID_MATERIA, int ID_PARALELO, int ID_INTERVALO_DETALLE)
        {
            try
            {
                //ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CREAR_TAREA"));
                return View(_datelle.ObtenerDetalleTarea(User.Identity.Name,ID_SEDE,ID_CARRERA,ID_MATERIA,ID_PARALELO, ID_INTERVALO_DETALLE));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }
        #endregion

        #region CalificarTarea
        public ActionResult CalificarTareas(int id)
        {
            try
            {
                //ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CREAR_TAREA"));
                return View(_calificar.ObtenerTareaCalificar(id));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }

        [HttpPost]
        public JsonResult ActualizarNota(string ID_ESTUDIANTE_TAREA, string VALOR)
        {
            try
            {
                _calificar.ActulizarNota(Convert.ToInt32(ID_ESTUDIANTE_TAREA), Convert.ToDecimal(VALOR));
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR_NOTA_ESTUDIANTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "NOTA_ESTUDIANTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ID_ESTUDIANTE_NOTA", ID_ESTUDIANTE_TAREA), ServicesAuditoria.audit().CrearTag("VALOR_NOTA", VALOR), ServicesAuditoria.audit().CrearTag("ESTADO", "GUARDADO"));
                return Json(new { success = true, message = "Guardado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR_NOTA_ESTUDIANTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "NOTA_ESTUDIANTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ID_ESTUDIANTE_NOTA", ID_ESTUDIANTE_TAREA), ServicesAuditoria.audit().CrearTag("VALOR_NOTA", VALOR), ServicesAuditoria.audit().CrearTag("ESTADO", "ERROR"));
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region EliminarTarea
        public ActionResult EliminarTareas(int ID_TAREA, int ID_SEDE, int ID_CARRERA, int ID_MATERIA, int ID_PARALELO, int ID_INTERVALO_DETALLE)
        {
            try
            {
                _tarea.EliminarTarea(ID_TAREA);
                //ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CREAR_TAREA"));
               return  RedirectToAction("DetalleTareas", "Tareas",new { ID_SEDE,ID_CARRERA, ID_MATERIA,ID_PARALELO,ID_INTERVALO_DETALLE });
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }
        #endregion

    }
}