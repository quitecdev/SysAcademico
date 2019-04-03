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
    public partial class Pagina : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Session["acceso"] = Request.Url.ToString();
            Seguridad seguridad = new Seguridad();
            seguridad.ValidarSession();
            CargarMenuInicio();
            CargarDatos();
        }

        public void CargarMenuInicio()
        {
            int i = 0;
            try
            {
                foreach (DataRow menuinicio in ((util)HttpContext.Current.Session["util"]).usuario.Menu_Inicio.Tables["RolMenus"].Rows)
                {

                    string nombre = menuinicio.Table.Rows[i]["DESCRIPCION_MENU"].ToString();
                    string icono = menuinicio.Table.Rows[i]["ICONO_MENU"].ToString();
                    string pagina = menuinicio.Table.Rows[i]["URL_MENU"].ToString();
                    menu.Controls.Add(new LiteralControl("<li class='has_sub'><a href='" + pagina + "' class='waves-effect'><i class='" + icono + "'></i><span>" + nombre + "</span></a></li>"));
                    i++;
                }

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        public void CargarDatos()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand(((util)HttpContext.Current.Session["util"]).ROL_USUARIO);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBFU");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_USUARIO", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["IMAGEN"].ToString() != string.Empty)
                    {
                        imgPerfil.ImageUrl = ds.Tables[0].Rows[0]["IMAGEN"].ToString();
                    }
                    else
                    {
                        imgPerfil.ImageUrl = "./assets/images/usuario.png";
                    }
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('" + ex.ToString() + "')", true);
            }
        }
    }
}