using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    public class NotasController : Controller
    {
        Nota _nota = new Nota();
        NotaDetalle _notaDetalle = new NotaDetalle();
        // GET: Notas
        #region Notas
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region CrearNota
        public ActionResult CreaNotas(int id = 0)
        {
            return View(_nota.ObtenerNota(id));
        }
        [HttpPost]
        public ActionResult CreaNotas(Nota nota)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _nota.GuardarNota(nota);
                return Json(new { success = true, message = "Nota creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(carrera);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion

        #region NotaDetalle
        public ActionResult NotaDetalle(int id)
        {
            return View(_notaDetalle.ObtenerNotasDetalle(id));
        }
        #endregion

        #region CrearNotaDetalle
        public ActionResult CrearNotaDetalle(int ID_NOTA,int ID_NOTAID_NOTA_DETALLE)
        {
            return View(_notaDetalle.ObtenerNotasDetalle(ID_NOTA));
        }
        #endregion

        #region Asiganacion
        public ActionResult Asignacion()
        {
            return View();
        }
        #endregion

        [HttpGet]
        public JsonResult getTableNota()
        {
            try
            {
                return Json(new { data = _nota.ObtenerNotas() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}