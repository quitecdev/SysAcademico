using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_WEB_PAGE.Controllers
{
    public class InscripcionController : Controller
    {
        ModelInscripcion _inscripcion = new ModelInscripcion();
        Inscipcion funcion = new Inscipcion();
        // GET: Inscripcion
        public ActionResult Index()
        {
            ViewBag.TheResult = false;
            return View(_inscripcion);
        }

        [HttpPost]
        public ActionResult Index(ModelInscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                Inscipcion registro = new Inscipcion();
                registro.ID_INSCRIP = inscripcion.ID_INSCRIP;
                registro.APELLIDO_PATERNO_INSCRIP = inscripcion.APELLIDO_PATERNO_INSCRIP;
                registro.APELLIDO_MATERNO_INSCRIP = inscripcion.APELLIDO_MATERNO_INSCRIP;
                registro.PRIMER_NOMBRE_INSCRIP = inscripcion.PRIMER_NOMBRE_INSCRIP;
                registro.SEGUNDO_NOMBRE_INSCRIP = inscripcion.SEGUNDO_NOMBRE_INSCRIP;
                registro.DESCRIPCION_NACIONALIDAD = inscripcion.DESCRIPCION_NACIONALIDAD;
                registro.CEL_INSCRIP = inscripcion.CEL_INSCRIP;
                registro.CORREO = inscripcion.CORREO;
                registro.DIRECCION = inscripcion.DIRECCION;
                funcion.GuardarInscripcion(registro);
                ViewBag.TheResult = true;
                _inscripcion = new ModelInscripcion();
                return View(_inscripcion);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult ValidadDocumento(string documento)
        {
            bool estado = false;
            estado = funcion.ValidarInscripcion(documento);
            return Json(new { success = estado }, JsonRequestBehavior.AllowGet);
        }
    }
}