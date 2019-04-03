using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAcademico
{
    public partial class LibretaDocente : System.Web.UI.Page
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


        //public void CargarDocente()
        //{
        //    DataSet ds = new DataSet();
        //    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocente");
        //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
        //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
        //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
        //    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
        //    cmb_docente.DataSource = ds.Tables[0];
        //    cmb_docente.DataTextField = ds.Tables[0].Columns["NOMBES_COMPLETOS"].ToString();
        //    cmb_docente.DataValueField = ds.Tables[0].Columns["ID_DOCENTE"].ToString();
        //    cmb_docente.DataBind();
        //    cmb_docente.Items.Insert(0, "");
        //}

        public void CargarSede()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBS");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBC");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_nota.DataSource = ds.Tables[0];
                cmb_nota.DataTextField = ds.Tables[0].Columns["DESCRIPCION_NOTA"].ToString();
                cmb_nota.DataValueField = ds.Tables[0].Columns["ID_NOTA"].ToString();
                cmb_nota.DataBind();
                cmb_nota.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_nota_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBIN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horario.DataSource = ds.Tables[0];
                cmb_horario.DataTextField = ds.Tables[0].Columns["DETALLE"].ToString();
                cmb_horario.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_horario.DataBind();
                cmb_horario.Items.Insert(0, "");
                //DefinirColumnas(ds);
                //GridView1.DataSource = ds;
                //GridView1.DataBind();

                //GridNotasDetalle.DataSource = ds;
                //GridNotasDetalle.DataBind();

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_docente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBS");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
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

        protected void cmb_horario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBAL");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int contador = 0;
                string collapse = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            DataSet ds2 = new DataSet();
                            DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBALN");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                            //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO_DETALLE", DbType.String, cmb_horario.SelectedValue);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_ESTUDIANTE", DbType.String, dr["ID_ESTUDIANTE"].ToString());
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                            ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                            string tabla = "";
                            foreach (DataTable table2 in ds2.Tables)
                            {
                                foreach (DataRow dr2 in table2.Rows)
                                {
                                    DataSet ds3 = new DataSet();
                                    DbCommand cmd3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@OPERACION", DbType.String, "OBNV");
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                                    //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_INTERVALO_DETALLE", DbType.String, cmb_horario.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_ESTUDIANTE", DbType.String, dr["ID_ESTUDIANTE"].ToString());
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_NOTA_DETALLE", DbType.String, dr2["ID_NOTA_DETALLE"].ToString());
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outMensaje", DbType.String, 200);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outID", DbType.Int32, 10);
                                    ds3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd3);
                                    tabla = tabla + ConvertDataTableToHTML(ds3, dr2["DESCRIPCION_NOTA_DETALLE"].ToString());
                                }
                            }

                            collapse = collapse + "<tr data-toggle='collapse' data-target='#accordion" + contador + "' class='clickable'> <td>" + dr["ID_ESTUDIANTE"].ToString() + "</td> <td colspan='2'>" + dr["NOMBRE"].ToString() + "</td></tr> <tr> <td colspan='3'> <div id='accordion" + contador + "' class='collapse collapse_nota'> " + tabla + "  </div> </td> </tr> ";
                            contador++;

                        }
                    }
                    div_nota.Controls.Add(new LiteralControl("<table class='table table-collapse table-striped m-0'> <thead class='table-collapse-thead'> <th># IDENTIDAD</th><th>NOMBRE Y APELLIDO</th><th>NOTA</th> </thead>  <tbody class='table-collapse-tbody'> " + collapse + " </tbody> </table> "));
                }

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        public static string ConvertDataTableToHTML(DataSet dt, string DESCRIPCION_NOTA_DETALLE)
        {
            string html = "<table class='table table-striped m-0'>";

            ////add header row
            html += "<thead>";
            html += "<tr>";
            html += "<th style='455px'>" + DESCRIPCION_NOTA_DETALLE + "</th>";
            html += "<th style='455px'>NOTA</th>";
            html += "</tr>";
            html += "</thead>";
            foreach (DataTable table2 in dt.Tables)
            {
                foreach (DataRow dr2 in table2.Rows)
                {
                    ////add rows
                    html += "<tbody>";
                    html += "<tr>";
                    html += "<td style='455px'>" + dr2["DESCRIPCION_PONDERACION"].ToString() + "</td>";
                    if (dr2["ESTADO"].ToString() == "1")
                    {
                        html += "<td style='455px'><input type='text' data-nota='" + dr2["ID_ESTUDIANTE_NOTA"].ToString() + "' class='form-control decimal' style='width: 80px;' value='" + dr2["VALOR_NOTA"].ToString() + "'></td>";
                    }
                    else
                    {
                        html += "<td style='455px'>" + dr2["VALOR_NOTA"].ToString() + "</td>";
                    }
                    html += "</tr>";
                    html += "</tbody>";

                }
            }
            html += "</table>";
            return html;
        }


        [WebMethod()]
        public static string ActualizarNota(string ID_ESTUDIANTE_NOTA, string VALOR_NOTA)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminEstudianteNota");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "AC");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE_NOTA", DbType.String, ID_ESTUDIANTE_NOTA);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@VALOR_NOTA", DbType.Decimal, Convert.ToDecimal(VALOR_NOTA));
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), HttpContext.Current.Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_LIBRETA_DOCENTE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_ESTUDIANTE_NOTA", ID_ESTUDIANTE_NOTA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("VALOR", VALOR_NOTA));

            return Convert.ToString("");
        }

    }
}