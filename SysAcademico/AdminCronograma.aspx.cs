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
    public partial class AdminCronograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Sede();
                CargarCarrera();
                CargarTipoIntervalo();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(
                                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(),
                                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(),
                                                                        Session.SessionID,
                                                                        ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR,
                                                                        ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_CRONOGRAMA));
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

        public void CargarCarrera()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
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


        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronograma");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_TIPO_INTERVALO", DbType.String, cmb_tipoIntervalo.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DESCRIPCION_CRONOGRAMA", DbType.String, txt_codigo.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FECHA_INICIO", DbType.DateTime, Convert.ToDateTime(txt_fechaInicio.Text));
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FECHA_FIN", DbType.DateTime, Convert.ToDateTime(txt_fechaFin.Text));
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    GridCarrera.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    LimpiarControles.Limpiar(this.Controls);
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_CRONOGRAMA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_CRONOGRAMA", outID.ToString()));

                }
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminMateria");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                //cmb_materia.DataSource = ds.Tables[0];
                //cmb_materia.DataTextField = ds.Tables[0].Columns["DESCRIPCION_MATERIA"].ToString();
                //cmb_materia.DataValueField = ds.Tables[0].Columns["ID_MATERIA"].ToString();
                //cmb_materia.DataBind();
                //cmb_materia.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_sedeAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_tipoIntervalo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminParaleloMateria");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBPPC");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_TIPO_INTERVALO", DbType.String, cmb_tipoIntervalo.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            cmb_paralelo.DataSource = ds.Tables[0];
            cmb_paralelo.DataTextField = ds.Tables[0].Columns["DESCRIPCION_PARALELO"].ToString();
            cmb_paralelo.DataValueField = ds.Tables[0].Columns["ID_PARALELO"].ToString();
            cmb_paralelo.DataBind();
            cmb_paralelo.Items.Insert(0, "");
        }
    }
}