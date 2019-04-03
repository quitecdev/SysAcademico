using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SysAcademico
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Session["util"] = new util();
            Session["acceso"] = null;
            Session["USUARIO"] = string.Empty;
            Session["USUARIO_NOMRE"] = string.Empty;
            Session["dt_Materias"] = null;
            Session["dt_Carreras"] = null;
            Session["ID_CARRERA"] = 0;
            Session["ID_INTERVALO"] = "0";
            Session["ID_SEDE"] = "0";
            Session["ID_INTERVALO_DETALLE"] = "0";
            Session["ID_TIPO_INTERVALO"] = "0";
            Session["ID_HORARIO_TIPO"] = "0";

            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}