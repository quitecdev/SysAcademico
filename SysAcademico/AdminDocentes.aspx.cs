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
    public partial class AdminDocentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE));
            }
            //CargarDocentes();
        }

        protected void GridInscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridDocentes.SelectedRow;
            Label rrdp = (Label)row.FindControl("ID_DOCENTE");

        }

        protected void GridInscripcion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string NO_MODIFICAR = GridDocentes.DataKeys[e.Row.RowIndex]["NO_MODIFICAR"].ToString();
                Label estado = (Label)e.Row.FindControl("NO_MODIFICAR");
                LinkButton eliminar = (LinkButton)e.Row.FindControl("lnk_eliminar");
                if (estado.Text == "1")
                {
                    eliminar.Visible = false;

                    // ModificarRegistro.Visible = false;
                }
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocente");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, txt_ci.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_PATERNO", DbType.String, txt_apellidoPaterno.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_MATERNO", DbType.String, txt_apellidoMaterno.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@PRIMER_NOMBRE", DbType.String, txt_primerNombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@SEGUNDO_NOMBRE", DbType.String, txt_segundoNombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CORREO", DbType.String, txt_email.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_DOCENTE", txt_ci.Text));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    GridDocentes.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('" + ex.ToString() + "');", true);
            }
        }

        protected void txt_ci_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBU");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_USUARIO", DbType.String, txt_ci.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(Page), "Validar", "alert('El Documento de Identidad ingresado ya existe.');", true);
                    txt_ci.Text = "";
                    txt_ci.Focus();
                }

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_DOCENTE"] = ((Label)GridDocentes.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_DOCENTE")).Text;
            e.InputParameters["APELLIDO_PATERNO_DOCENTE"] = ((TextBox)GridDocentes.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_apellidoPaterno")).Text;
            e.InputParameters["APELLIDO_MATERNO_DOCENTE"] = ((TextBox)GridDocentes.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_apellidoMaterno")).Text;
            e.InputParameters["PRIMER_NOMBRE_DOCENTE"] = ((TextBox)GridDocentes.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_primerNombre")).Text;
            e.InputParameters["SEGUNDO_NOMBRE_DOCENTE"] = ((TextBox)GridDocentes.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_segundoNombre")).Text;
            e.InputParameters["CORREO_DOCENTE"] = ((TextBox)GridDocentes.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_correo")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_DOCENTE", ((Label)GridDocentes.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_DOCENTE")).Text));
        }

        protected void GridDocentes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

        protected void GridDocentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ObtenerDocente")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                id_docente.Value = e.CommandArgument.ToString();

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(Page), "Validar", "$('.bs-example-modal-sm').modal('show'); ", true);
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_docente.Value != "")
                {
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocente");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "EL");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, id_docente.Value);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    GridDocentes.DataBind();
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ELIMINACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_NOTAS), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_DOCENTE", id_docente.Value));
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }
    }
}