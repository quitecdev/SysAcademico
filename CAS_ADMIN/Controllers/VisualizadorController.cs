using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Data;

namespace CAS_ADMIN.Controllers
{
    public class VisualizadorController : Controller
    {
        // GET: Visualizador
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Video(int id)
        {
            CAS_CRONOGRAMA_ADJUNTO adjunto = new CAS_CRONOGRAMA_ADJUNTO();
            using (var ctx = new CAS_DataEntities())
            {
                adjunto = ctx.CAS_CRONOGRAMA_ADJUNTO.Where(x => x.ID_CRONOGRAMA_ADJUNTO == id).FirstOrDefault();
            }
            ViewBag.URL = adjunto.RUTA_ADJUNTO;
            return View();
        }
    }
}