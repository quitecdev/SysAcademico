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
    public partial class AdminIntervalos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoHorario();
                CargarTipoIntervalo();
                CargarSede();
                Session["ID_SEDE"] = "0";
                Session["ID_TIPO_INTERVALO"] = "0";
                Session["ID_HORARIO_TIPO"] = "0";
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_INTERVALOS));
            }
        }

        public void CargarSede()
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

        public void CargarTipoHorario()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminHorarioTipo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_tipoHorario.DataSource = ds.Tables[0];
                cmb_tipoHorario.DataTextField = ds.Tables[0].Columns["DESCRIPCION_HORARIO_TIPO"].ToString();
                cmb_tipoHorario.DataValueField = ds.Tables[0].Columns["ID_HORARIO_TIPO"].ToString();
                cmb_tipoHorario.DataBind();
                cmb_tipoHorario.Items.Insert(0, "");

                cmb_tipoHorarioAñadir.DataSource = ds.Tables[0];
                cmb_tipoHorarioAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_HORARIO_TIPO"].ToString();
                cmb_tipoHorarioAñadir.DataValueField = ds.Tables[0].Columns["ID_HORARIO_TIPO"].ToString();
                cmb_tipoHorarioAñadir.DataBind();
                cmb_tipoHorarioAñadir.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        public void CargarTipoIntervalo()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminTipoIntervalo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_tipoIntervalo.DataSource = ds.Tables[0];
                cmb_tipoIntervalo.DataTextField = ds.Tables[0].Columns["DESCRIPCION_TIPO_INVERTALO"].ToString();
                cmb_tipoIntervalo.DataValueField = ds.Tables[0].Columns["ID_TIPO_INTERVALO"].ToString();
                cmb_tipoIntervalo.DataBind();
                cmb_tipoIntervalo.Items.Insert(0, "");

                cmb_tipoIntervaloAñadir.DataSource = ds.Tables[0];
                cmb_tipoIntervaloAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_TIPO_INVERTALO"].ToString();
                cmb_tipoIntervaloAñadir.DataValueField = ds.Tables[0].Columns["ID_TIPO_INTERVALO"].ToString();
                cmb_tipoIntervaloAñadir.DataBind();
                cmb_tipoIntervaloAñadir.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervalo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_TIPO_INTERVALO", DbType.String, cmb_tipoIntervaloAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_HORARIO_TIPO", DbType.String, cmb_tipoHorarioAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DESCRIPCION_INTERVALO", DbType.String, txt_descripcion.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_INTERVALOS), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO", outID.ToString()));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    Session["ID_SEDE"] = cmb_sedeAñadir.SelectedValue;
                    Session["ID_TIPO_INTERVALO"] = cmb_tipoIntervaloAñadir.SelectedValue;
                    Session["ID_HORARIO_TIPO"] = cmb_tipoHorarioAñadir.SelectedValue;
                    GridIntervalo.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_tipoHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_SEDE"] = cmb_sede.SelectedValue;
            Session["ID_TIPO_INTERVALO"] = cmb_tipoIntervalo.SelectedValue;
            Session["ID_HORARIO_TIPO"] = cmb_tipoHorario.SelectedValue;
            GridIntervalo.DataBind();
        }

        protected void cmb_tipoIntervalo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_SEDE"] = cmb_sede.SelectedValue;
            Session["ID_TIPO_INTERVALO"] = cmb_tipoIntervalo.SelectedValue;
            Session["ID_HORARIO_TIPO"] = cmb_tipoHorario.SelectedValue;
            GridIntervalo.DataBind();
        }

        protected void cmb_sede_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_tipoHorario.ClearSelection();
            cmb_tipoIntervalo.ClearSelection();
        }

        protected void cmb_sedeAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_tipoHorarioAñadir.ClearSelection();
            cmb_tipoIntervaloAñadir.ClearSelection();
        }

        protected void cmb_tipoHorario_SelectedIndexChanged1(object sender, EventArgs e)
        {
            cmb_tipoIntervalo.ClearSelection();
        }

        protected void ObjIntervalo_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_INTERVALO"] = ((Label)GridIntervalo.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_INTERVALO")).Text;
            e.InputParameters["DESCRIPCION_INTERVALO"] = ((TextBox)GridIntervalo.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_descripcion")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_INTERVALOS), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO", ((Label)GridIntervalo.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_INTERVALO")).Text));
        }

        protected void GridIntervalo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

    }
}