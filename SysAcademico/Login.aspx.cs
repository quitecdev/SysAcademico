using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAcademico
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(null, null, Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_INGRESO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("IP", Request.UserHostAddress));
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txt_usuario.Text = Request.Cookies["UserName"].Value;
                    txt_clave.Attributes["value"] = Request.Cookies["Password"].Value;
                    chkRememberMe.Checked = true;
                }
            }
        }

        protected void bnt_ingresar_Click(object sender, EventArgs e)
        {

            bool aprobado = false;
            try
            {

                if (chkRememberMe.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txt_usuario.Text.Trim();
                Response.Cookies["Password"].Value = txt_clave.Text.Trim();

                string resultado = "null";
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "VA");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@COD_USUARIO", DbType.String, txt_usuario.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CLAVE_USUARIO", DbType.String, txt_clave.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MODIFICAR_CLAVE"].ToString() != "0")
                    {
                        ((util)HttpContext.Current.Session["util"]).usuario = ((util)HttpContext.Current.Session["util"]).ValidarUsuario(txt_usuario.Text, txt_clave.Text, ref resultado);
                        if (((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows.Count > 0)
                        {
                            aprobado = true;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "ModalCambiarClave('" + ds.Tables[0].Rows[0]["ID_USUARIO"].ToString() + "');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('El usuario o contraseña ingresados no son correctos.')", true);
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(null, null, Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_INGRESO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("IP", Request.UserHostAddress), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ERROR", "CLAVE O USUARIO INCORRECTOS"), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("USERNAME", txt_usuario.Text));
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
                aprobado = false;
            }
            if (aprobado == true)
            {

                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_SESSION_INICIO, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ROL:", ((util)HttpContext.Current.Session["util"]).usuario.Menu_Inicio.Tables[0].Rows[0]["DESCRIPCION_ROL"].ToString()));
                Page.Response.Redirect("Principal.aspx", true);
            }

        }
    }
}