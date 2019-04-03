using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAS_ESTUDIANTE.Models;

namespace CAS_ESTUDIANTE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PreguntasFrecuentes()
        {
            return View();
        }
    }
}