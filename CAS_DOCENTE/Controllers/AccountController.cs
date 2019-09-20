﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Docente;
using System.Web.Security;
using Model.Services;
using CAS_DOCENTE.Models;
using System.IO;

namespace CAS_DOCENTE.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        Login ingreso = new Login();
        ForgotPassword recuperar = new ForgotPassword();
        ChangePassword cambiar = new ChangePassword();
        EncuestaDocente _encuesta = new EncuestaDocente();
        // GET: Ingreso
        public ActionResult Login()
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(null, null, Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "INGRESO"), ServicesAuditoria.audit().CrearTag("IP", Request.UserHostAddress));
                if (Request.Cookies["Login"] != null)
                {
                    ingreso.COD_USUARIO = Request.Cookies["Login"].Values["username"];
                    ingreso.CLAVE_USUARIO = Request.Cookies["Login"].Values["password"];
                    ingreso.RECORDAR = true;
                }
                return View(ingreso);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View(ingreso);
            }
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
                    Login obtenerDatosUsurio = _login.Obtener(_login);

                    //List<Menu> _menu = menu.ObtenerMenu(obtenerDatosUsurio.ROL_ID);
                    FormsAuthentication.SetAuthCookie(obtenerDatosUsurio.ID_USUARIO, false); // set the formauthentication cookie  
                    Session["LoginCredentials"] = obtenerDatosUsurio; // Bind the _logincredentials details to "LoginCredentials" session  
                                                                      //Session["MenuMaster"] = _menu; //Bind the _menus list to MenuMaster session  
                    Session["COD_USUARIO"] = obtenerDatosUsurio.COD_USUARIO;
                    Session["ID_USUARIO"] = obtenerDatosUsurio.ID_USUARIO;
                    Session["DESCRIPCION_ROL"] = obtenerDatosUsurio.DESCRIPCION_ROL;
                    if (string.IsNullOrEmpty(obtenerDatosUsurio.IMAGEN))
                    {
                        Session["IMG_USUARIO"] = "~/assets/images/usuario.png";
                    }
                    else
                    {
                        Session["IMG_USUARIO"] = obtenerDatosUsurio.IMAGEN;
                    }


                    if (obtenerDatosUsurio.MODIFICAR_CLAVE == 0)
                    {
                        return RedirectToAction("ChangePassword", "Account");
                    }

                    if (_login.RECORDAR)
                    {
                        HttpCookie cookie = new HttpCookie("Login");
                        cookie.Values.Add("username", _login.COD_USUARIO);
                        cookie.Values.Add("password", _login.CLAVE_USUARIO);
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);
                    }
                    //isExist = _encuesta.ValidarEncuesta(obtenerDatosUsurio.ID_USUARIO);
                    var action = "";
                    var controler = "";
                    //if (isExist)
                    //{
                        action = "Index";
                        controler = "Home";
                    //}
                    //else
                    //{
                    //    // var a = _carrera.ObtenerCarreraEstudiante(obtenerDatosUsurio.ID_USUARIO);
                    //    action = "evalucionDocentes";
                    //    controler = "Encuestas";
                    //}
                    ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "INICIO_SESION", ServicesAuditoria.audit().CrearTag("ROL", Session["DESCRIPCION_ROL"].ToString()));
                    return RedirectToAction(action, controler);
                }
                else
                {
                    ViewBag.TheResult = true;
                    ServicesAuditoria.audit().RegistrarAuditoria(null, null, Session.SessionID, "INGRESO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "INGRESO"), ServicesAuditoria.audit().CrearTag("IP", Request.UserHostAddress), ServicesAuditoria.audit().CrearTag("ERROR:", _login.COD_USUARIO));
                    return View();
                }
            }
            return View();
        }

        public ActionResult ForgotPassword()
        {
            ServicesAuditoria.audit().RegistrarAuditoria(null, null, Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "RECUPERAR_CUENTA"));
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword _recuperar)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TheResult = false;
                ViewBag.Envio = false;
                bool isExist = false;
                isExist = recuperar.ValidarUsurio(_recuperar);
                if (isExist)
                {
                    //ForgotPassword obtenerDatosUsurio = _recuperar.Obtener(_recuperar);
                    recuperar.Enviar(_recuperar.Obtener(_recuperar));
                    ViewBag.Envio = true;
                    ServicesAuditoria.audit().RegistrarAuditoria(null, null, Session.SessionID, "RECUPERAR_CUENTA", ServicesAuditoria.audit().CrearTag("FORMULARIO", "RECUPERAR_CUENTA"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", _recuperar.COD_USUARIO), ServicesAuditoria.audit().CrearTag("ESTADO", "ENVIADO"));
                }
                else
                {
                    ViewBag.TheResult = true;
                    ServicesAuditoria.audit().RegistrarAuditoria(null, null, Session.SessionID, "RECUPERAR_CUENTA", ServicesAuditoria.audit().CrearTag("FORMULARIO", "RECUPERAR_CUENTA"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", _recuperar.COD_USUARIO), ServicesAuditoria.audit().CrearTag("ESTADO", "USUARIO_NO_ENCONTRADO"));
                    return View();
                }

            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            ServicesAuditoria.audit().RegistrarAuditoria(null, null, Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CAMBIAR_CLAVE"));
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword _cambiar)
        {
            ViewBag.Envio = false;
            if (ModelState.IsValid)
            {

                _cambiar.ID_USUARIO = Session["ID_USUARIO"].ToString();
                cambiar.CambiarContraseña(_cambiar);
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ACTUALIZACION", ServicesAuditoria.audit().CrearTag("FORMULARIO", "CAMBIAR_CLAVE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ROL", Session["DESCRIPCION_ROL"].ToString()));
                ViewBag.Envio = true;

            }
            return View();
        }

        public ActionResult LogOut()
        {
            ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "FINALIZO_SESION", ServicesAuditoria.audit().CrearTag("ROL", Session["DESCRIPCION_ROL"].ToString()));
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        // El Json recibido será serializado automáticamente al objeto nuevo cocche teniendo en cuenta que las propiedades han de tener el mismo nombre
        public JsonResult GetHour()
        {
            return Json(DateTime.Now.ToString());
        }


        Perfil perfil = new Perfil();
        [Authorize]
        public ActionResult Perfil()
        {
            try
            {
                ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ABRIR_FORMULARIO", ServicesAuditoria.audit().CrearTag("FORMULARIO", "PERFIL_DOCENTE"));
                return View(perfil.ObtenerPerfil(User.Identity.Name));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return View(perfil.ObtenerPerfil(User.Identity.Name));
            }
        }


        [Authorize]
        [HttpPost]
        public ActionResult Perfil(HttpPostedFileBase postedFile, Perfil _perfil)
        {
            try
            {
                string sExt = string.Empty;
                string sName = string.Empty;
                string carpetaAdjuntos = string.Empty;
                string rutaAdjunto = string.Empty;

                if (ModelState.IsValid)
                {
                    if (postedFile != null)
                    {
                        sName = postedFile.FileName;
                        sExt = Path.GetExtension(sName);
                        DirectoryInfo fol = new DirectoryInfo(Server.MapPath("~/assets/images/users"));
                        carpetaAdjuntos = Path.Combine(fol.ToString(), User.Identity.Name + sExt);
                        postedFile.SaveAs(carpetaAdjuntos);

                        _perfil.IMG_DOCENTE = "~/assets/images/users/" + User.Identity.Name + sExt;
                    }
                    perfil.GuardarPerfil(_perfil);
                    ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ACTUALIZAR_PERFIL_DOCENTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "PERFIL_DOCENTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ESTADO", "ACTUALIZADO"));
                    this.AddToastMessage("Perfil", "Sus datos se han guardado correctamente.", ToastType.Success);
                }
                return View(perfil.ObtenerPerfil(User.Identity.Name));
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                this.AddToastMessage("Perfil", ex.Message.ToString(), ToastType.Error);
                return View(perfil.ObtenerPerfil(User.Identity.Name));
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult CambiarConstraseña(ChangePassword clave)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clave.ID_USUARIO = User.Identity.Name;
                    cambiar.CambiarContraseña(clave);
                    ServicesAuditoria.audit().RegistrarAuditoria(Session["COD_USUARIO"].ToString(), Session["ID_USUARIO"].ToString(), Session.SessionID, "ACTUALIZAR_CALVE_DOCENTE", ServicesAuditoria.audit().CrearTag("FORMULARIO", "PERFIL_DOCENTE"), ServicesAuditoria.audit().CrearTag("COD_USUARIO", Session["COD_USUARIO"].ToString()), ServicesAuditoria.audit().CrearTag("ESTADO", "ACTUALIZADO"));
                    this.AddToastMessage("Perfil", "Sus clave se a actualizado correctamente.", ToastType.Success);
                }
                return RedirectToAction("Perfil", "Account");
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                this.AddToastMessage("Perfil", ex.Message.ToString(), ToastType.Error);
                return RedirectToAction("Perfil", "Account");
            }
        }

        Notificacion notificacion = new Notificacion();
        [Authorize]
        [HttpPost]
        public ActionResult Notificacion()
        {

            return PartialView("_Notificacion", notificacion.ObterNotificacion(User.Identity.Name));
        }

        [Authorize]
        [HttpPost]
        public JsonResult ContadorNotificacion()
        {
            var output = notificacion.Contador(User.Identity.Name);
            return Json(output, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult NotificacionVer(string ID_NOTIFICACION)
        {
            int id = Convert.ToInt32(ID_NOTIFICACION);
            return PartialView("_NotificacionDetalle", notificacion.VerNotificacion(id));
        }
    }
}