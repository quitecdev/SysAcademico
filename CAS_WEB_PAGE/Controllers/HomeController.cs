using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_WEB_PAGE.Controllers
{
    public class HomeController : Controller
    {
        ContadorWeb contador = new ContadorWeb();
        public ActionResult Index()
        {
            return View(contador.ObtenerContador());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}