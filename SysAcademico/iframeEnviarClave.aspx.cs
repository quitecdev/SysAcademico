using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAcademico
{
    public partial class iframeEnviarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(null, null, Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_ENVIAR_CLAVE));
        }

        protected void bnt_enviar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CORREO_USUARIO", DbType.String, txt_email.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                string outMensaje1 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet dsEnvio = new DataSet();
                    DbCommand cmdEnvio = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.NotificadorEnviaClave");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdEnvio, "@ID_USUARIO ", DbType.String, ds.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                    dsEnvio = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmdEnvio);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Su constraña se envio correctamente a su email.')", true);
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(null,null, Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ENVIAR_CORREO, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_ENVIAR_CLAVE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("CORREO", txt_email.Text));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('El email ingresado no es correcto.')", true);
                }


            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('"+ex.ToString()+"')", true);
            }
        }
    }
}