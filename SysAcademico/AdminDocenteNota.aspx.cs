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
    public partial class AdminDocenteNota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Sede();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_NOTAS));
            }
        }

        public void Sede()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminSede");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_sede.DataSource = ds.Tables[0];
                cmb_sede.DataTextField = ds.Tables[0].Columns["DESCRIPCION_UNIVERSIDAD"].ToString();
                cmb_sede.DataValueField = ds.Tables[0].Columns["ID_SEDE"].ToString();
                cmb_sede.DataBind();
                cmb_sede.Items.Insert(0, "");

                cmb_sedeAñadir.DataSource = ds.Tables[0];
                cmb_sedeAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_UNIVERSIDAD"].ToString();
                cmb_sedeAñadir.DataValueField = ds.Tables[0].Columns["ID_SEDE"].ToString();
                cmb_sedeAñadir.DataBind();
                cmb_sedeAñadir.Items.Insert(0, "");

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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBN");
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


        protected void cmb_sede_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet ds2 = new DataSet();
                DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBCFS");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                cmb_carrera.DataSource = ds2.Tables[0];
                cmb_carrera.DataTextField = ds2.Tables[0].Columns["DESCRIPCION_CARRERA"].ToString();
                cmb_carrera.DataValueField = ds2.Tables[0].Columns["ID_CARRERA"].ToString();
                cmb_carrera.DataBind();
                cmb_carrera.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_carreraAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carreraAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_notaAñadir.DataSource = ds.Tables[0];
                cmb_notaAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_NOTA"].ToString();
                cmb_notaAñadir.DataValueField = ds.Tables[0].Columns["ID_NOTA"].ToString();
                cmb_notaAñadir.DataBind();
                cmb_notaAñadir.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }


        protected void cmb_sedeAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                DataSet ds2 = new DataSet();
                DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBCFS");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);

                cmb_carreraAñadir.DataSource = ds2.Tables[0];
                cmb_carreraAñadir.DataTextField = ds2.Tables[0].Columns["DESCRIPCION_CARRERA"].ToString();
                cmb_carreraAñadir.DataValueField = ds2.Tables[0].Columns["ID_CARRERA"].ToString();
                cmb_carreraAñadir.DataBind();
                cmb_carreraAñadir.Items.Insert(0, "");


            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
            finally
            {
                cmb_carreraAñadir.ClearSelection();
            }
        }



        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PONDERACION", DbType.String, cmb_notaPonderacion.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_NOTAS), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_DOCENTE_NOTA", outID.ToString()));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    //GridIntervalo.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                }
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNota");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBND");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_notaDetalle.DataSource = ds.Tables[0];
                cmb_notaDetalle.DataTextField = ds.Tables[0].Columns["DESCRIPCION_NOTA_DETALLE"].ToString();
                cmb_notaDetalle.DataValueField = ds.Tables[0].Columns["ID_NOTA_DETALLE"].ToString();
                cmb_notaDetalle.DataBind();
                cmb_notaDetalle.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_notaAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNota");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBND");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_notaAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_notaDetalleAñadir.DataSource = ds.Tables[0];
                cmb_notaDetalleAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_NOTA_DETALLE"].ToString();
                cmb_notaDetalleAñadir.DataValueField = ds.Tables[0].Columns["ID_NOTA_DETALLE"].ToString();
                cmb_notaDetalleAñadir.DataBind();
                cmb_notaDetalleAñadir.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_notaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataSet ds = new DataSet();
            //    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNotaDetalle");
            //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBG");
            //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
            //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA_DETALLE", DbType.String, cmb_notaDetalle.SelectedValue);
            //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
            //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            //    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            //    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            //    GridHorario.DataSource = ds;
            //    GridHorario.DataBind();

            //}
            //catch (Exception ex)
            //{
            //    ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            //}
        }

        protected void cmb_notaDetalleAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNotaDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBNP");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA_DETALLE", DbType.String, cmb_notaDetalleAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_notaPonderacion.DataSource = ds.Tables[0];
                cmb_notaPonderacion.DataTextField = ds.Tables[0].Columns["DESCRIPCION_PONDERACION"].ToString();
                cmb_notaPonderacion.DataValueField = ds.Tables[0].Columns["ID_PONDERACION"].ToString();
                cmb_notaPonderacion.DataBind();
                cmb_notaPonderacion.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_notaPonderacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocente");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_docente.DataSource = ds.Tables[0];
                cmb_docente.DataTextField = ds.Tables[0].Columns["NOMBES_COMPLETOS"].ToString();
                cmb_docente.DataValueField = ds.Tables[0].Columns["ID_DOCENTE"].ToString();
                cmb_docente.DataBind();
                cmb_docente.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void GridNotasDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridNotasDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

        protected void GridNotasDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ObtenerDocente")
            {
                //id_docente.Value = e.CommandArgument.ToString();
            }
        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_DOCENTE_NOTA"] = ((Label)GridNotasDetalle.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_DOCENTE_NOTA")).Text;
            e.InputParameters["FECHA_INICIO"] = ((TextBox)GridNotasDetalle.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_fechaInicio")).Text;
            e.InputParameters["FECHA_FIN"] = ((TextBox)GridNotasDetalle.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_fechaFin")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_NOTAS), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_DOCENTE_NOTA", ((Label)GridNotasDetalle.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_DOCENTE_NOTA")).Text));
        }

    }
}