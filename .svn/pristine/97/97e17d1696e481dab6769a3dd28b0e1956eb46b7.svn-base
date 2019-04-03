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
    public class CalificacionesController : Controller
    {
        NotasAsignadas notasAsiganadas = new NotasAsignadas();
        // GET: Calificaciones
        public ActionResult Index()
        {
            return View(notasAsiganadas.Obtener(User.Identity.Name));
        }

        Notas _notas = new Notas();

        Calificar _calificar = new Calificar();

        public ActionResult Nota(int ID_SEDE, int ID_CARRERA, int ID_NOTA, int ID_INTERVALO_DETALLE)
        {
            try
            {
                return View(_calificar.ObtenerLibreta(ID_SEDE, ID_CARRERA, ID_NOTA, ID_INTERVALO_DETALLE, User.Identity.Name));
            }
            catch (Exception ex)
            {

                ServicesTrackError.RegistrarError(ex);
                return View();
            }      
        }

        [HttpPost]
        public JsonResult ActualizarNota(string ID_NOTA, string VALOR)
        {
            try
            {
                _calificar.ActulizarNota(Convert.ToInt32(ID_NOTA), Convert.ToDecimal(VALOR));
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR_NOTA_ESTUDIANTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "NOTA_ESTUDIANTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ID_ESTUDIANTE_NOTA", ID_NOTA), ServicesAuditoria.audit().CrearTag("VALOR_NOTA", VALOR), ServicesAuditoria.audit().CrearTag("ESTADO", "GUARDADO"));
                return Json(new { success = true, message = "Guardado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "GUARDAR_NOTA_ESTUDIANTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "NOTA_ESTUDIANTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ID_ESTUDIANTE_NOTA", ID_NOTA), ServicesAuditoria.audit().CrearTag("VALOR_NOTA", VALOR), ServicesAuditoria.audit().CrearTag("ESTADO", "ERROR"));
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}