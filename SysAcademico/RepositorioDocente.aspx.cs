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
    public partial class RepositorioDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_LIBRETA_DOCENTE));
                CargarSede();
                //CargarDocente();
            }
        }

        public void CargarSede()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteRepositorio");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBS");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, "1717275208");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_sede.DataSource = ds.Tables[0];
                cmb_sede.DataTextField = ds.Tables[0].Columns["DESCRIPCION_UNIVERSIDAD"].ToString();
                cmb_sede.DataValueField = ds.Tables[0].Columns["ID_SEDE"].ToString();
                cmb_sede.DataBind();
                cmb_sede.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_sede_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteRepositorio");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBC");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, "1717275208");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_carrera.DataSource = ds.Tables[0];
                cmb_carrera.DataTextField = ds.Tables[0].Columns["DESCRIPCION_CARRERA"].ToString();
                cmb_carrera.DataValueField = ds.Tables[0].Columns["ID_CARRERA"].ToString();
                cmb_carrera.DataBind();
                cmb_carrera.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_carrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteRepositorio");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBI");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, "1717275208");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horario.DataSource = ds.Tables[0];
                cmb_horario.DataTextField = ds.Tables[0].Columns["DESCRIPCION_TIPO_INVERTALO"].ToString();
                cmb_horario.DataValueField = ds.Tables[0].Columns["ID_TIPO_INTERVALO"].ToString();
                cmb_horario.DataBind();
                cmb_horario.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }


        protected void cmb_horario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string acordion = "";
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteRepositorio");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBSM");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_TIPO_INTERVALO", DbType.String, cmb_horario.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            int inicio = 0;
            int contador = 0;
            foreach (DataTable table in ds.Tables)
            {

                foreach (DataRow item in table.Rows)
                {
                    DataSet ds2 = new DataSet();
                    DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteRepositorio");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBCA");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@SEMANA_CRONOGRAMA", DbType.String, item["SEMANA_CRONOGRAMA"].ToString());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CRONOGRAMA", DbType.String, item["ID_CRONOGRAMA"].ToString());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                    ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                    string contenido = "";

                    foreach (DataRow theRow in ds2.Tables[0].Rows)
                    {
                        DataSet ds3 = new DataSet();
                        DbCommand cmd3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteRepositorio");
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@OPERACION", DbType.String, "OBSDA");
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@SEMANA_CRONOGRAMA", DbType.String, item["SEMANA_CRONOGRAMA"].ToString());
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_CARPETA", DbType.String, theRow["ID_CARPETA"].ToString());
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_TIPO_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_CRONOGRAMA", DbType.String, item["ID_CRONOGRAMA"].ToString());
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outMensaje", DbType.String, 200);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outID", DbType.Int32, 10);
                        ds3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd3);
                        string adjuntos = "";
                        foreach (DataRow theRow2 in ds3.Tables[0].Rows)
                        {
                            adjuntos = adjuntos + "<li class='list-group-item'> <a href='" + theRow2["RUTA_ADJUNTO"].ToString() + "' class='user-list-item' target='_blank'> <div class='avatar text-center'> <i class='" + theRow2["ICONO_ADJUNTO"].ToString() + " text-custom'></i> </div> <div class='user-desc'> <span class='name'>" + theRow2["NOMBRE_ADJUNTO"].ToString() + "</span> <span class='desc'>" + theRow2["PESO_ADJUNTO"].ToString() + "</span> </div> </a> </li>";
                        }
                        contenido = contenido + "<div class='panel-heading'> <h4 class='panel-title'> <a data-toggle='collapse' href='#collapse" + contador + "'><i class='indicator fa fa-caret-right' aria-hidden='true'></i> " + theRow["DESCRIPCION_CARPETA"].ToString() + "</a> </h4> </div> <div id='collapse" + contador + "' class='panel-collapse collapse'> <ul class='list-group m-b-0 user-list'>" + adjuntos + "</ul> </div>";

                        //Console.WriteLine(theRow["ID"] + "\t" + theRow["FirstName"]);
                        contador++;
                    }

                    if (inicio == 0)
                    {
                        acordion = acordion + "<div class='panel panel-default bx-shadow-none'> <div class='panel-heading' role='tab' id='heading" + item["SEMANA_CRONOGRAMA"].ToString() + "'> <h4 class='panel-title'> <a role='button' data-toggle='collapse' data-parent='#accordion' href='#" + item["SEMANA_CRONOGRAMA"].ToString() + "' aria-expanded='true' aria-controls='" + item["SEMANA_CRONOGRAMA"].ToString() + "'> " + item["DESCRIPCION_SEMANA"].ToString() + " - " + item["TEMA"].ToString() + " </a> </h4> </div> <div id='" + item["SEMANA_CRONOGRAMA"].ToString() + "' class='panel-collapse collapse in' role='tabpanel' aria-labelledby='heading" + item["SEMANA_CRONOGRAMA"].ToString() + "'> <div class='panel-body'>" + contenido + " </div> </div> </div>";
                    }
                    else
                    {
                        acordion = acordion + "<div class='panel panel-default bx-shadow-none'> <div class='panel-heading' role='tab' id='heading" + item["SEMANA_CRONOGRAMA"].ToString() + "'> <h4 class='panel-title'> <a class='collapsed' role='button' data-toggle='collapse' data-parent='#accordion' href='#" + item["SEMANA_CRONOGRAMA"].ToString() + "' aria-expanded='flase' aria-controls='" + item["SEMANA_CRONOGRAMA"].ToString() + "'> " + item["DESCRIPCION_SEMANA"].ToString() + " - " + item["TEMA"].ToString() + " </a> </h4> </div> <div id='" + item["SEMANA_CRONOGRAMA"].ToString() + "' class='panel-collapse collapse' role='tabpanel' aria-labelledby='heading" + item["SEMANA_CRONOGRAMA"].ToString() + "'> <div class='panel-body'>" + contenido + "</tbody> </table>  </div> </div> </div>";
                    }

                    inicio++;
                }
            }
            div_nota.Controls.Add(new LiteralControl("<div class='col-lg-12'> <br /> <h3>" + cmb_carrera.SelectedItem + "</h3> <div class='panel-group' id='accordion' role='tablist' runat='server' aria-multiselectable='true'>" + acordion + " </div> </div>"));
        }
    }
}

