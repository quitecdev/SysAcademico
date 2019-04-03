using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Docente;
using Model.Services;

namespace CAS_DOCENTE.Controllers
{
    [Authorize]
    public class RepositorioController : Controller
    {
        CarreraIntervalo carrera = new CarreraIntervalo();
        // GET: Repositorio
        public ActionResult Index()
        {
            return View(carrera.ObtenerCarreras(User.Identity.Name));
        }

        RepositorioDocente repositorio = new RepositorioDocente();
        public ActionResult Vista(int ID_SEDE, int ID_CARRERA, int ID_TIPO_INTERVALO,int ID_PARALELO)
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "REPOSITORIO_DOCENTE"));
                return View(repositorio.ObtenerRepositorioDocente(ID_SEDE, ID_CARRERA, ID_TIPO_INTERVALO, ID_PARALELO));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View();
            }
        }
    }
}