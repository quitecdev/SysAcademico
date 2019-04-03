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
    public partial class iframe_Notificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Request.QueryString["not_id"] != null)
                {
                    CargarContenido(Request.QueryString["not_id"].ToString());
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_NOTIFICACION));
                }
            }
        }


        public void CargarContenido(string ID_NOTIFICACION)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("AdminNotificaciones");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTIFICACION", DbType.String, ID_NOTIFICACION);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                contenido.Controls.Add(new LiteralControl(ds.Tables[0].Rows[0]["TXT_NOTIFICACION"].ToString()));

                DataSet ds2 = new DataSet();
                DbCommand cms2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("AdminNotificaciones");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cms2, "@OPERACION", DbType.String, "ACE");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cms2, "@ID_NOTIFICACION", DbType.String, ID_NOTIFICACION);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cms2, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cms2, "@outID", DbType.Int32, 10);
                ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cms2);
            }
        }
    }
}