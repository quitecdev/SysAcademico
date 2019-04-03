using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace SysAcademico
{
    public partial class iframe_SubirContenido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Request.QueryString["descripcion"] != null)
                {
                    Session["ID_CRONOGRAMA_DETALLE"] = Request.QueryString["descripcion"].ToString();
                    CargarContenido();
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_SUBIR_CONTENIDO));
                }
            }
        }


        public void CargarContenido()
        {

            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CRONOGRAMA_DETALLE", DbType.String, Session["ID_CRONOGRAMA_DETALLE"]);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            GridInscripcion.DataSource = ds;
            GridInscripcion.DataBind();

            DataSet ds2 = new DataSet();
            DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaDetalle");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBR");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CRONOGRAMA_DETALLE", DbType.String, Session["ID_CRONOGRAMA_DETALLE"]);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
            ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);

            directorio_link.Controls.Add(new LiteralControl("<li class='breadcrumb-item'>"+ds2.Tables[0].Rows[0]["COD_CARRERA"].ToString()+ "</li><li class='breadcrumb-item'>" + ds2.Tables[0].Rows[0]["TEMA"].ToString() + "</li><li class='breadcrumb-item'>" + ds2.Tables[0].Rows[0]["DIA"].ToString() + "</li>"));

            //           < li class="breadcrumb-item"><a href = "#" > Home </ a ></ li >

            //< li class="breadcrumb-item"><a href = "#" > Library </ a ></ li >

            // < li class="breadcrumb-item active" aria-current="page">Data</li>
        }




        protected void btn_subir_Click(object sender, EventArgs e)
        {
            try
            {

                if (file_adjunto.HasFile)
                {
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBR");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CRONOGRAMA_DETALLE", DbType.String, Session["ID_CRONOGRAMA_DETALLE"]);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                    GenerarCarpetasRepositorio(Session["ID_CRONOGRAMA_DETALLE"].ToString());

                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("Repositorio"));
                    string directorio = Path.Combine(di.ToString(), ds.Tables[0].Rows[0]["DESCRIPCION_PERIODO"].ToString(), ds.Tables[0].Rows[0]["COD_CARRERA"].ToString(), ds.Tables[0].Rows[0]["TEMA"].ToString(), ds.Tables[0].Rows[0]["DIA"].ToString());
                    string filename = Path.GetFileName(file_adjunto.FileName);
                    string tipo = Path.GetExtension(file_adjunto.FileName);

                    long fileSizeInBytes = file_adjunto.FileContent.Length;
                    string fileSize = string.Format("{0:0.00} MB", (fileSizeInBytes / 1024f) / 1024f);

                    string icon = "";
                    switch (tipo)
                    {
                        case ".gif":
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                            icon = "fa fa-file-image-o";
                            break;
                        case ".odt":
                        case ".doc":
                        case ".docx":
                            icon = "fa fa-file-word-o";
                            break;
                        case ".odp":
                        case ".ppt":
                            icon = "fa fa-file-powerpoint-o";
                            break;
                        case ".ods":
                        case ".xls":
                            icon = "fa fa-file-excel-o";
                            break;
                        case ".pdf":
                            icon = "fa fa-file-pdf-o";
                            break;
                        case ".cda":
                        case ".mp3":
                        case ".ogg":
                        case ".wav":
                            icon = "fa fa-file-sound-o";
                            break;
                        case ".avi":
                        case ".mpg":
                        case ".mpeg":
                        case ".wmv":
                        case ".mov":
                        case ".ogv":
                            icon = "fa fa-file-movie-o";
                            break;
                        case ".rar":
                        case ".zip":
                        case ".tar":
                        case ".tgz":
                            icon = "fa fa-file-zip-o";
                            break;
                        default:
                            icon = "zmdi zmdi-attachment";
                            break;
                    }

                    string local = Path.Combine(directorio, filename);
                    string svr = Path.Combine(@".\Repositorio", ds.Tables[0].Rows[0]["DESCRIPCION_PERIODO"].ToString(), ds.Tables[0].Rows[0]["COD_CARRERA"].ToString(), ds.Tables[0].Rows[0]["TEMA"].ToString(), ds.Tables[0].Rows[0]["DIA"].ToString(), filename);


                    DataSet ds2 = new DataSet();
                    DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "IN");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CRONOGRAMA_DETALLE", DbType.String, Session["ID_CRONOGRAMA_DETALLE"]);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@RUTA_ADJUNTO", DbType.String, svr);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ICONO_ADJUNTO", DbType.String, icon);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@PESO_ADJUNTO", DbType.String, fileSize);
                    if (rd_recurso1.Checked == true)
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARPETA", DbType.String, "1");
                    }
                    if (rd_recetas1.Checked == true)
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARPETA", DbType.String, "2");
                    }
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@NOMBRE_ADJUNTO", DbType.String, filename);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                    ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                    file_adjunto.SaveAs(local);

                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_SUBIR_CONTENIDO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("CONTENIDO:", svr));

                    CargarContenido();

                }

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        public void GenerarCarpetasRepositorio(string ID_CRONOGRAMA_DETALLE)
        {

            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaDetalle");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBR");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CRONOGRAMA_DETALLE", DbType.String, ID_CRONOGRAMA_DETALLE);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

            DirectoryInfo di = new DirectoryInfo(Server.MapPath("Repositorio"));

            string periodo = Path.Combine(di.ToString(), ds.Tables[0].Rows[0]["DESCRIPCION_PERIODO"].ToString());
            if (!Directory.Exists(periodo))
            {
                System.IO.Directory.CreateDirectory(periodo);
            }

            string cod_carrera = Path.Combine(periodo, ds.Tables[0].Rows[0]["COD_CARRERA"].ToString());
            if (!Directory.Exists(cod_carrera))
            {
                System.IO.Directory.CreateDirectory(cod_carrera);
            }

            string tema = Path.Combine(cod_carrera, ds.Tables[0].Rows[0]["TEMA"].ToString());
            if (!Directory.Exists(tema))
            {
                System.IO.Directory.CreateDirectory(tema);
            }

            string dia = Path.Combine(tema, ds.Tables[0].Rows[0]["DIA"].ToString());
            if (!Directory.Exists(dia))
            {
                System.IO.Directory.CreateDirectory(dia);
            }

        }

        protected void GridInscripcion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "EL");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CRONOGRAMA_ADJUNTO", DbType.String, e.CommandArgument.ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                CargarContenido();
                //hd_index.Value = e.CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#myModal').modal('show');ConfigurarFrame('iframe_BuscarInscripciones', './iframe_SubirContenido.aspx?descripcion=" + hd_index.Value + "');", true);
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_link.Text != string.Empty)
            {
                DataSet ds2 = new DataSet();
                DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CRONOGRAMA_DETALLE", DbType.String, Session["ID_CRONOGRAMA_DETALLE"]);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@RUTA_ADJUNTO", DbType.String, txt_link.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ICONO_ADJUNTO", DbType.String, "zmdi zmdi-link");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@PESO_ADJUNTO", DbType.String, "0 MB");
                if (rd_recurso2.Checked == true)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARPETA", DbType.String, "1");
                }
                if (rd_recetas2.Checked == true)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARPETA", DbType.String, "2");
                }
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@NOMBRE_ADJUNTO", DbType.String, txt_nombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_SUBIR_CONTENIDO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("LINK:", txt_link.Text));
                CargarContenido();
            }
        }

        protected void GridInscripcion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridInscripcion.PageIndex = e.NewPageIndex;
            CargarContenido();
        }
    }
}