using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_WEB_PAGE.Controllers
{
    public class EventoController : Controller
    {
        EventoRegistro _registro = new EventoRegistro();
        // GET: Evento
        public ActionResult Index()
        {
            ViewBag.TheResult = false;
            return View(_registro);
        }

        [HttpPost]
        public ActionResult Index(EventoRegistro eventoRegistro)
        {
            
            if (ModelState.IsValid)
            {
                var cod = _registro.GuardarDetalle(eventoRegistro);
                if (cod != null)
                {
                    return RedirectToAction("Ticket", new { cod = cod });
                }
                ViewBag.TheResult = true;
                return View();
            }
            else
            {
                return View();
            }
        }

        public JsonResult getFecha(int id_sede, string id_hora)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _registro.ObtenerFecha(id_sede, id_hora))
            {
                licities.Add(new SelectListItem { Text = x.FECHA_EVENTO.ToString(), Value = x.FECHA_EVENTO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public JsonResult getEvento(int id_sede, string id_hora, string fecha)
        {
            List<SelectListItem> licities = new List<SelectListItem>();

            foreach (var x in _registro.ObtenerEvento(id_sede, id_hora, fecha))
            {
                licities.Add(new SelectListItem { Text = x.EVENTO_DESCRIPCIÓN.ToString(), Value = x.ID_EVENTO.ToString() });
            }
            return Json(new SelectList(licities, "Value", "Text", JsonRequestBehavior.AllowGet));
        }


        Ticket _ticket = new Ticket();

        public ActionResult Ticket(string cod)
        {
            var replacement = cod.Replace(' ', '+');
            return View(_ticket.ObtenerDatos(replacement));
        }


        public ActionResult Control()
        {
            return View();
        }


        //public ActionResult GeneratePDF(string cod)
        //{
        //    return new Rotativa.ActionAsPdf("Ticket", new { cod = cod });
        //}

    }
}