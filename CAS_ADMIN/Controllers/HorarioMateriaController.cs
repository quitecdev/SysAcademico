using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;
using System.Web.Script.Serialization;

namespace CAS_ADMIN.Controllers
{
    public class HorarioMateriaController : Controller
    {
        HorarioMateria _horarioMateria = new HorarioMateria();
        Estudiante _estudiante = new Estudiante();
        // GET: HorarioMateria
        public ActionResult Index()
        {
            return View(_horarioMateria);
        }

        public ActionResult DocenteHorario(int id)
        {
            return View(_horarioMateria.DocenteAsiganado(id));
        }

        public JsonResult EliminarDetalle(int ID_DOCENTE_MATERIA_PARALELO)
        {
            try
            {
                _horarioMateria.EliminarDocenteAsignado(ID_DOCENTE_MATERIA_PARALELO);
                return Json(new { success = true, message = "Detalle eliminado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult ObtenerDetalle(int id_sede, int id_carrera, int id_materia, int id_paralelo, int id_intervalo)
        {
            try
            {
                return Json(new { data = _horarioMateria.ObtenerDetalle(id_sede, id_carrera, id_materia, id_paralelo, id_intervalo) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}