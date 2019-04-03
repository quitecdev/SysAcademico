using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Services.Admin;

namespace CAS_ADMIN.Controllers
{
    public class UsuarioController : Controller
    {
        #region ModificarClave
        Usuario usuario = new Usuario();
        [HttpPost]
        public JsonResult ModificarClave(string ID_USUARIO)
        {
            try
            {
                usuario.ModificarClave(ID_USUARIO);
                return Json(new { success = true, message = "Se ha modificado la clave correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}