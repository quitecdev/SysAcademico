using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAcademico
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Session["acceso"] = Request.Url.ToString();
            Seguridad seguridad = new Seguridad();
            seguridad.ValidarSession();
            CargarMenuInicio();
            CargarDatos();
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_PRINCIPAL), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("IP", Request.UserHostAddress));
        }

        public void CargarMenuInicio()
        {
            int i = 0;
            try
            {
                foreach (DataRow menuinicio in ((util)HttpContext.Current.Session["util"]).usuario.Menu_Inicio.Tables["RolMenus"].Rows)
                {
                    //<li class="has_sub"><a href="javascript:ConfigurarFrame('iframe_Contenido','AdminDocentes.aspx');" class="waves-effect"><i class="zmdi zmdi-face"></i><span>Docentes</span></a></li>
                    string nombre = menuinicio.Table.Rows[i]["DESCRIPCION_MENU"].ToString();
                    string icono = menuinicio.Table.Rows[i]["ICONO_MENU"].ToString();
                    string pagina = menuinicio.Table.Rows[i]["URL_MENU"].ToString();
                    //string iframe = "ConfigurarFrame('iframe_Contenido','" + pagina + "');";
                    string iframe = "\"javascript:ConfigurarFrame('iframe_Contenido','" + pagina + "');\"";
                    menu.Controls.Add(new LiteralControl("<li class='has_sub'><a href=" + iframe + " class='waves-effect'><i class='" + icono + "'></i><span>" + nombre + "</span></a></li>"));
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


        [WebMethod]
        public static void metodoLimpiarDatos()
        {
            try
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), System.Web.HttpContext.Current.Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_SESSION_FINALIZO, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ROL:", ((util)HttpContext.Current.Session["util"]).usuario.Menu_Inicio.Tables[0].Rows[0]["DESCRIPCION_ROL"].ToString()));
                System.Web.HttpContext.Current.Session["usuario"] = null;
                System.Web.HttpContext.Current.Session.Abandon();
            }
            catch (Exception)
            {
                System.Web.HttpContext.Current.Session["usuario"] = null;
                System.Web.HttpContext.Current.Session.Abandon();
            }

            //System.Web.HttpContext.Current.Response.Redirect("page-404.html", true);

        }

        [WebMethod]
        public static string ContNotificaciones()
        {
            List<Notificacion> datos = new List<Notificacion>();
            int i = 0;
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("AdminNotificaciones");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBNL");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_USUARIO", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    datos.Add(new Notificacion()
                    {
                        ID_NOTIFICACION = Convert.ToString(dr.Table.Rows[i]["ID_NOTIFICACION"]),
                        ASUNTO_NOTIFICACION = Convert.ToString(dr.Table.Rows[i]["ASUNTO_NOTIFICACION"]),
                        FECHA_NOTIFICACION = Convert.ToString(dr.Table.Rows[i]["FECHA_NOTIFICACION"]),
                        ESTADO_NOTIFICACION = Convert.ToString(dr.Table.Rows[i]["ESTADO_NOTIFICACION"]),
                        TOTAL = Convert.ToString(dr.Table.Rows[i]["TOTAL"])
                    });
                    i++;
                }

                string json = JsonConvert.SerializeObject(datos);
                return json;
            }

            return null;
        }



        public class Notificacion
        {
            public string ID_NOTIFICACION { get; set; }
            public string ASUNTO_NOTIFICACION { get; set; }
            public string FECHA_NOTIFICACION { get; set; }
            public string ESTADO_NOTIFICACION { get; set; }
            public string TOTAL { get; set; }
        }





    }
}