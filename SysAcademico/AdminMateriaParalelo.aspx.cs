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
    public partial class AdminMateriaParalelo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_MATERIA_PARALELO));
                CargarCarrera();
                CargarSede();
                Session["ID_MATERIA"] = "";
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

                cmb_carreraAñadir.DataSource = ds.Tables[0];
                cmb_carreraAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_CARRERA"].ToString();
                cmb_carreraAñadir.DataValueField = ds.Tables[0].Columns["ID_CARRERA"].ToString();
                cmb_carreraAñadir.DataBind();
                cmb_carreraAñadir.Items.Insert(0, "");
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
                cmb_carreraAñadir.SelectedValue = cmb_carrera.SelectedValue;
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminMateria");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_materia.DataSource = ds.Tables[0];
                cmb_materia.DataTextField = ds.Tables[0].Columns["DESCRIPCION_MATERIA"].ToString();
                cmb_materia.DataValueField = ds.Tables[0].Columns["ID_MATERIA"].ToString();
                cmb_materia.DataBind();
                cmb_materia.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_materia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MATERIA"] = cmb_materia.SelectedValue;
            GridParalelo.DataBind();
            cmb_materiaAñadir.SelectedValue = cmb_materia.SelectedValue;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminParaleloMateria");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_MATERIA", DbType.String, cmb_materiaAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@MAX_ASIGANDO", DbType.String, txt_cantidad.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_MATERIA_PARALELO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_PARALELO_MATERIA", outID.ToString()));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    Session["ID_MATERIA"] = cmb_materiaAñadir.SelectedValue;
                    GridParalelo.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                }
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminMateria");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carreraAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_materiaAñadir.DataSource = ds.Tables[0];
                cmb_materiaAñadir.DataTextField = ds.Tables[0].Columns["DESCRIPCION_MATERIA"].ToString();
                cmb_materiaAñadir.DataValueField = ds.Tables[0].Columns["ID_MATERIA"].ToString();
                cmb_materiaAñadir.DataBind();
                cmb_materiaAñadir.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_materiaAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminParalelo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_MATERIA", DbType.String, cmb_materiaAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_paralelo.DataSource = ds.Tables[0];
                cmb_paralelo.DataTextField = ds.Tables[0].Columns["DESCRIPCION_PARALELO"].ToString();
                cmb_paralelo.DataValueField = ds.Tables[0].Columns["ID_PARALELO"].ToString();
                cmb_paralelo.DataBind();
                cmb_paralelo.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_sedeAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_carreraAñadir.ClearSelection();
            cmb_materiaAñadir.ClearSelection();
            cmb_paralelo.ClearSelection();
        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_PARALELO_MATERIA"] = ((Label)GridParalelo.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_PARALELO_MATERIA")).Text;
            e.InputParameters["MAX_ASIGANDO"] = ((TextBox)GridParalelo.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_asignado")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_MATERIA_PARALELO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_PARALELO_MATERIA", ((Label)GridParalelo.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_PARALELO_MATERIA")).Text));
        }

        protected void GridParalelo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }
    }
}