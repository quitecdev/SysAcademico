using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAcademico
{
    public partial class AdminNotificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetAutoCompleteData(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "AUC");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FILTRO", DbType.String, txt);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(Convert.ToString(dr["NOMBRE"]));
            }

            return result;
        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            string valo = txt_destinatario.Text;
            string[] destino = valo.Split(',');
            foreach (string filtro in destino)
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNotificaciones");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "ENOT");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FILTRO", DbType.String, filtro);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@TXT_NOTIFICACION", DbType.String, txtSummernote.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ASUNTO_NOTIFICACION", DbType.String, txt_asunto.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            }
        }
    }
}