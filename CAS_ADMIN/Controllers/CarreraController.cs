using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class CarreraController : Controller
    {
        // GET: Carrera
        Carrera _carrera = new Carrera();
        #region Carrera
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getTableCarrera()
        {
            try
            {
                return Json(new { data = _carrera.ObtenerCarrera() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region EliminarCarrera
        public JsonResult EliminarCarrera(int ID_CARRERA)
        {
            try
            {
                _carrera.EliminarCarrera(ID_CARRERA);
                return Json(new { success = true, message = "Carrera eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region getCarreraSede
        public JsonResult getCarreraSede(int id_sede)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _carrera.ObtenerCarreraSede(id_sede))
            {
                //licities.Add(new SelectListItem { Text = x.DESCRIPCION_INTERVALO, Value = x.ID_INTERVALO.ToString() });
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_CARRERA, Value = x.ID_CARRERA.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        #region CrearCarrera
        public ActionResult CrearCarrea(int id=0)
        {
            return View(_carrera.ObtenerCarrera(id));
        }
        [HttpPost]
        public ActionResult CrearCarrea(Carrera carrera)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _carrera.GuardarCarrera(carrera);
                    return Json(new { success = true, message = "Carrera creada exitosamente" }, JsonRequestBehavior.AllowGet);
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

        #region Aula
        Aulas _aulas = new Aulas();
        public ActionResult Aula(int id =0)
        {
            return View(_aulas);
        }

        [HttpPost]
        public ActionResult Aula(Aulas aula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _aulas.GuardarAula(aula);
                    return Json(new { success = true, message = "Aula creada exitosamente" }, JsonRequestBehavior.AllowGet);
                }
                return View(_aulas);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DetalleAula(int ID_MATERIA,int ID_SEDE)
        {
            return PartialView("_DetalleAula", _aulas.ObtenerAulas(ID_MATERIA, ID_SEDE));
        }

        public JsonResult EliminarAulda(int ID_PARALELO_MATERIA)
        {
            try
            {
                _aulas.EliminarAula(ID_PARALELO_MATERIA);
                return Json(new { success = true, message = "Aula eliminada correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Materia
        Materia _materia = new Materia();
        public JsonResult getMateriaCarrera(int id_carrera)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _materia.ObtenerMaterias(id_carrera))
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_MATERIA, Value = x.ID_MATERIA.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        #region Parelelo
        Paralelo _paralelo = new Paralelo();
        public JsonResult getParaleloMateria(int id_sede, int id_materia)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _paralelo.ObtenerParaleloMateria(id_sede,id_materia))
            {
                licities.Add(new SelectListItem { Text = x.DESCRIPCION_PARALELO, Value = x.ID_PARALELO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion

        #region HorarioParalelo
        IntervaloDetalle _intervalo = new IntervaloDetalle();
        public JsonResult getHorarioParalelo(int id_paraleloMateria)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _intervalo.ObtenerHorarioParalelo(id_paraleloMateria))
            {
                licities.Add(new SelectListItem { Text = x.DETALLE, Value = x.ID_HORARIO_DETALLE.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        #endregion
    }
}