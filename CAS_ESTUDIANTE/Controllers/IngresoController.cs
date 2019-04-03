using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Estudiante;

namespace CAS_ESTUDIANTE.Controllers
{
    public class IngresoController : Controller
    {

        Login ingreso = new Login();
        // GET: Ingreso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login _login)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TheResult = false;
                bool isExist = false;
                isExist = ingreso.ValidarUsurio(_login);
                if (isExist)
                {
                    //Login obtenerDatosUsurio = _login.Obtener(_login);
                    //List<Menu> _menu = menu.ObtenerMenu(obtenerDatosUsurio.ROL_ID);
                    //FormsAuthentication.SetAuthCookie(obtenerDatosUsurio.USUARIO_CODIGO, false); // set the formauthentication cookie  
                    //Session["LoginCredentials"] = obtenerDatosUsurio; // Bind the _logincredentials details to "LoginCredentials" session  
                    //Session["MenuMaster"] = _menu; //Bind the _menus list to MenuMaster session  
                    //Session["USUARIO_CODIGO"] = obtenerDatosUsurio.USUARIO_CODIGO;
                    //Session["USUARIO_ID"] = obtenerDatosUsurio.USUARIO_ID;
                    //Session["ROL_DESCRIPCION"] = obtenerDatosUsurio.ROL_DESCRIPCION;
                    //Session["ID_NUMERO_FACTURA"] = obtenerDatosUsurio.ID_NUMERO_FACTURA;
                    //contador.GenerarContador();
                    //var action = _menu.First().MENU_PAGINA;
                    //var controler = _menu.First().MENU_FORM;
                    //return RedirectToAction(action, controler);
                }
                else
                {
                    ViewBag.TheResult = true;
                    return View();
                }
            }
            return View();
        }
    }
}