using CAS_ESTUDIANTE.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CAS_ESTUDIANTE.Tags
{
    // Si no estamos logeado, regresamos al login
    public class AutenticadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Login"
                }));
            }
        }
    }

    // Si estamos logeado ya no podemos acceder a la página de Login
    //public class NoLoginAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        base.OnActionExecuting(filterContext);

    //        if (SessionHelper.ExistUserInSession())
    //        {
    //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
    //            {
    //                controller = "Inicio",
    //                action = "Index"
    //            }));
    //        }
    //    }
    //}
}