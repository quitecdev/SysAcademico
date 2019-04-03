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
    public partial class iframeCambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cod"] != null)
            {
                ID_USUARIO.Value = Request.QueryString["cod"].ToString();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(ID_USUARIO.Value, ID_USUARIO.Value, Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_CAMBIAR_CLAVE));
            }
        }

        protected void bnt_guardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (ID_USUARIO.Value != string.Empty)
                {
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "ACC");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_USUARIO", DbType.String, ID_USUARIO.Value);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CLAVE_USUARIO", DbType.String, txt_claveNueva.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    string outMensaje1 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                    if (outMensaje1 == "OK: Actualizado con Exito")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('La contraseña se ha actualizado correctamente.')", true);
                    }
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(ID_USUARIO.Value, ID_USUARIO.Value, Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_CAMBIAR_CLAVE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_USUARIO", ID_USUARIO.Value));
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }
    }
}