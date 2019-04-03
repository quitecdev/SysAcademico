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
    public partial class AdminIntervalosDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_INTERVALOS_DETALLE));
                Session["ID_INTERVALO"] = "0";
                CargarIntervalo();
            }
        }

        public void CargarIntervalo()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervalo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_intervalo.DataSource = ds.Tables[0];
                cmb_intervalo.DataTextField = ds.Tables[0].Columns["DESCRIPCION_INTERVALO"].ToString();
                cmb_intervalo.DataValueField = ds.Tables[0].Columns["ID_INTERVALO"].ToString();
                cmb_intervalo.DataBind();
                cmb_intervalo.Items.Insert(0, "");

                cmb_intervaloAñadir.DataSource = ds.Tables[0];
                cmb_intervaloAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_INTERVALO"].ToString();
                cmb_intervaloAñadir.DataValueField = ds.Tables[0].Columns["ID_INTERVALO"].ToString();
                cmb_intervaloAñadir.DataBind();
                cmb_intervaloAñadir.Items.Insert(0, "");

                
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_intervalo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_INTERVALO"] = cmb_intervalo.SelectedValue;
            GridIntervalo.DataBind();
            cmb_intervaloAñadir.SelectedValue = cmb_intervalo.SelectedValue;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_intervaloAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@INICIO_INTERVALO", DbType.String, txt_inicio.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FIN_INTERVALO", DbType.String, txt_fin.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_INTERVALOS_DETALLE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO_DETALLE", outID.ToString()));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    Session["ID_INTERVALO"] = cmb_intervaloAñadir.SelectedValue;
                    GridIntervalo.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                }

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_INTERVALO_DETALLE"] = ((Label)GridIntervalo.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_INTERVALO_DETALLE")).Text;
            e.InputParameters["INICIO_INTERVALO"] = ((TextBox)GridIntervalo.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_inicioEdit")).Text;
            e.InputParameters["FIN_INTERVALO"] = ((TextBox)GridIntervalo.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_finEdit")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_INTERVALOS_DETALLE), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO_DETALLE", ((Label)GridIntervalo.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_INTERVALO_DETALLE")).Text));
        }

        protected void GridIntervalo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

    }
}