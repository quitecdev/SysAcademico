using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    [Authorize]
    public class HorarioDetalleController : Controller
    {
        // GET: HorarioDetalle
        HorarioDetalleMateria _horarioDetalle = new HorarioDetalleMateria();

        ModelHorario _horario = new ModelHorario();
        public ActionResult HorarioDetalleMateria(int ID_PARALELO_MATERIA,int ID_SEDE)
        {
            _horario.ID_PARALELO_MATERIA = ID_PARALELO_MATERIA;
            _horario.ID_SEDE = ID_SEDE;
            return View(_horario);
        }



        [HttpPost]
        public ActionResult HorarioDetalleMateria(ModelHorario horario)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _horario.GuadarHorario(horario);
                return Json(new { success = true, message = "Horario creada exitosamente" }, JsonRequestBehavior.AllowGet);
                //}
                //return View(carrera);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult DetalleHorarioMateria(int ID_PARALELO_MATERIA)
        {
            return PartialView("_DetalleHorarioMateria", _horarioDetalle.ObtenerDetalleHorario(ID_PARALELO_MATERIA));
        }

        public JsonResult EliminarHorarioDetalle(int ID_HORARIO_DETALLE)
        {
            try
            {
                _horario.EliminarHorarioDetalle(ID_HORARIO_DETALLE);
                return Json(new { success = true, message = "Horario eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}