using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_WEB_PAGE.Controllers
{
    public class ComponentesController : Controller
    {
        ContadorWeb contador = new ContadorWeb();
        // GET: Componentes
        public ActionResult Contadores()
        {
            return View(contador.ObtenerContador());
        }
    }
}