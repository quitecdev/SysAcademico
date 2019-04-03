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
    public partial class AdminNotasDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaNota();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_NOTAS_DETALLE));
            }
        }

        public void CargaNota()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNota");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_nota.DataSource = ds.Tables[0];
                cmb_nota.DataTextField = ds.Tables[0].Columns["DESCRIPCION_NOTA"].ToString();
                cmb_nota.DataValueField = ds.Tables[0].Columns["ID_NOTA"].ToString();
                cmb_nota.DataBind();
                cmb_nota.Items.Insert(0, "");

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

        protected void cmb_nota_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bnt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNotaDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_notaAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DESCRIPCION_NOTA_DETALLE", DbType.String, txt_descripcion.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_NOTAS_DETALLE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_NOTA_DETALLE", outID.ToString()));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    GridNotasDetalle.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_notaAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ObjIntervalo_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_NOTA_DETALLE"] = ((Label)GridNotasDetalle.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_NOTA_DETALLE")).Text;
            e.InputParameters["DESCRIPCION_NOTA_DETALLE"] = ((TextBox)GridNotasDetalle.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_descripcion")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_NOTAS_DETALLE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_NOTA_DETALLE", ((Label)GridNotasDetalle.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_NOTA_DETALLE")).Text));
        }

        protected void GridNotasDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

        private decimal _Total = 0;
        protected void GridNotasDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string NO_MODIFICAR = GridDocentes.DataKeys[e.Row.RowIndex]["NO_MODIFICAR"].ToString();
                if (DataBinder.Eval(e.Row.DataItem, "PORCENTAJE") != string.Empty)
                {
                    _Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PORCENTAJE"));
                }
                Label estado = (Label)e.Row.FindControl("NO_MODIFICAR");
                LinkButton eliminar = (LinkButton)e.Row.FindControl("lnk_eliminar");
                if (estado.Text == "1")
                {
                    eliminar.Visible = false;

                    // ModificarRegistro.Visible = false;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "TOTAL";
                e.Row.Cells[2].Text = _Total.ToString();
                e.Row.Font.Bold = true;
            }
        }

        protected void GridNotasDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Obtener")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                id_notaDetalle.Value = e.CommandArgument.ToString();

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(Page), "Validar", "$('.bs-example-modal-sm').modal('show'); ", true);
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_notaDetalle.Value != "")
                {
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminNotaDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "EL");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA_DETALLE", DbType.String, id_notaDetalle.Value);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ELIMINACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_NOTAS_DETALLE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_NOTA_DETALLE", id_notaDetalle.Value));
                    GridNotasDetalle.DataBind();
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

    }
}