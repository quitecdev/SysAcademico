using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    public class ReportesController : Controller
    {
        #region EncuestaDocente
        Reporte_EncuestaDocente encuestaDocente = new Reporte_EncuestaDocente();
        // GET: Reportes
        public ActionResult EncuestaDocente()
        {
            return View(encuestaDocente);
        }

        [HttpPost]
        public ActionResult EncuestaDocente(Reporte_EncuestaDocente _reporte)
        {
            if (ModelState.IsValid)
            {
                return View(encuestaDocente.ObtenerDatos(_reporte.ID_DOCENTE));
            }
            return View(encuestaDocente);
        }
        #endregion
    }
}