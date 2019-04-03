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
    public partial class AdminHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_HORARIO));
                Session["ID_INTERVALO_DETALLE"] = "0";
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
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_intervalo.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_intervaloDetalle.DataSource = ds.Tables[0];
                cmb_intervaloDetalle.DataTextField = ds.Tables[0].Columns["DETALLE"].ToString();
                cmb_intervaloDetalle.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_intervaloDetalle.DataBind();
                cmb_intervaloDetalle.Items.Insert(0, "");

                cmb_intervaloDetalleAñadir.DataSource = ds.Tables[0];
                cmb_intervaloDetalleAñadir.DataTextField = ds.Tables[0].Columns["DETALLE"].ToString();
                cmb_intervaloDetalleAñadir.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_intervaloDetalleAñadir.DataBind();
                cmb_intervaloDetalleAñadir.Items.Insert(0, "");
     

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_intervaloDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_INTERVALO_DETALLE"] = cmb_intervaloDetalle.SelectedValue;
            GridIntervalo.DataBind();
            cmb_intervaloAñadir.SelectedValue = cmb_intervalo.SelectedValue;
        }


        protected void cmb_intervaloDetalleAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDias");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_intervaloDetalleAñadir.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            cmb_Día.DataSource = ds.Tables[0];
            cmb_Día.DataTextField = ds.Tables[0].Columns["DESCRIPCION_DIAS"].ToString();
            cmb_Día.DataValueField = ds.Tables[0].Columns["ID_DIAS"].ToString();
            cmb_Día.DataBind();
            cmb_Día.Items.Insert(0, "");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminHorario");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_intervaloDetalleAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DIA", DbType.String, cmb_Día.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_HORARIO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_HORARIO", outID.ToString()));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    Session["ID_INTERVALO_DETALLE"] = cmb_intervaloDetalleAñadir.SelectedValue;
                    GridIntervalo.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_intervaloAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_intervaloAñadir.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            cmb_intervaloDetalleAñadir.DataSource = ds.Tables[0];
            cmb_intervaloDetalleAñadir.DataTextField = ds.Tables[0].Columns["DETALLE"].ToString();
            cmb_intervaloDetalleAñadir.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
            cmb_intervaloDetalleAñadir.DataBind();
            cmb_intervaloDetalleAñadir.Items.Insert(0, "");
        }
    }
}