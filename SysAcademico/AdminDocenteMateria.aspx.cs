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
    public partial class AdminDocenteMateria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDocente();
                Sede();
                CargarCarrera();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_MATERIA));
            }
        }

        public void CargarDocente()
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

            cmb_docenteAñadir.DataSource = ds.Tables[0];
            cmb_docenteAñadir.DataTextField = ds.Tables[0].Columns["NOMBES_COMPLETOS"].ToString();
            cmb_docenteAñadir.DataValueField = ds.Tables[0].Columns["ID_DOCENTE"].ToString();
            cmb_docenteAñadir.DataBind();
            cmb_docenteAñadir.Items.Insert(0, "");

            cmb_docenteEditar.DataSource = ds.Tables[0];
            cmb_docenteEditar.DataTextField = ds.Tables[0].Columns["NOMBES_COMPLETOS"].ToString();
            cmb_docenteEditar.DataValueField = ds.Tables[0].Columns["ID_DOCENTE"].ToString();
            cmb_docenteEditar.DataBind();
            cmb_docenteEditar.Items.Insert(0, "");

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

                cmb_sedeIntensivo.DataSource = ds.Tables[0];
                cmb_sedeIntensivo.DataTextField = ds.Tables[0].Columns["DESCRIPCION_UNIVERSIDAD"].ToString();
                cmb_sedeIntensivo.DataValueField = ds.Tables[0].Columns["ID_SEDE"].ToString();
                cmb_sedeIntensivo.DataBind();
                cmb_sedeIntensivo.Items.Insert(0, "");

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

        protected void cmb_docente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHorario(cmb_docente.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_BUSCAR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_MATERIA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_DOCENTE", cmb_docente.SelectedValue));
        }

        public void CargarHorario(string docente)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBFU");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, docente);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            GridHorario.DataSource = ds;
            GridHorario.DataBind();

            cmd.Parameters.Clear();
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBCO");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, docente);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            GridCodigos.DataSource = ds;
            GridCodigos.DataBind();

        }

        protected void cmb_sedeAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_carrera.ClearSelection();
            cmb_materia.ClearSelection();
            cmb_paralelo.ClearSelection();
            cmb_horario.ClearSelection();
            cmb_docenteAñadir.ClearSelection();
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
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminParaleloMateria");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_MATERIA", DbType.String, cmb_materia.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_paralelo.DataSource = ds.Tables[0];
                cmb_paralelo.DataTextField = ds.Tables[0].Columns["DESCRIPCION_PARALELO"].ToString();
                cmb_paralelo.DataValueField = ds.Tables[0].Columns["ID_PARALELO_MATERIA"].ToString();
                cmb_paralelo.DataBind();
                cmb_paralelo.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_paralelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminHorarioDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBFD");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO_MATERIA", DbType.String, cmb_paralelo.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horario.DataSource = ds.Tables[0];
                cmb_horario.DataTextField = ds.Tables[0].Columns["DETALLE"].ToString();
                cmb_horario.DataValueField = ds.Tables[0].Columns["ID_HORARIO_DETALLE"].ToString();
                cmb_horario.DataBind();
                cmb_horario.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_docenteAñadir_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_docenteAñadir.SelectedValue = cmb_docente.SelectedValue;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docenteAñadir.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_HORARIO_DETALLE", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    CargarHorario(cmb_docenteAñadir.SelectedValue);
                    LimpiarControles.Limpiar(this.Controls);
                    cmb_docente.SelectedValue = cmb_docenteAñadir.SelectedValue;
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_MATERIA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_DOCENTE_MATERIA_PARALELO", outID.ToString()));
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_docenteEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocente");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBFM");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docenteEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cbm_materiaEditar.DataSource = ds.Tables[0];
                cbm_materiaEditar.DataTextField = ds.Tables[0].Columns["DESCRIPCION_MATERIA"].ToString();
                cbm_materiaEditar.DataValueField = ds.Tables[0].Columns["ID_MATERIA"].ToString();
                cbm_materiaEditar.DataBind();
                cbm_materiaEditar.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cbm_materiaEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OFMD");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docenteEditar.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_MATERIA", DbType.String, cbm_materiaEditar.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

        }

        protected void GridParalelo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

        protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_HORARIO_DETALLE"] = ((Label)GridParalelo.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_HORARIO_DETALLE")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ELIMINACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_MATERIA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_HORARIO_DETALLE", ((Label)GridParalelo.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_HORARIO_DETALLE")).Text));
        }



        protected void cmb_sedeIntensivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OHIN");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeIntensivo.SelectedValue);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
        }

        protected void Grid_Intensivos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField1.Value = e.RowIndex.ToString();
        }

        protected void ObjectDataSource2_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_HORARIO_DETALLE"] = ((Label)Grid_Intensivos.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[2].FindControl("ID_HORARIO_DETALLE")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ELIMINACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_DOCENTE_MATERIA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_HORARIO_DETALLE", ((Label)Grid_Intensivos.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[2].FindControl("ID_HORARIO_DETALLE")).Text));
        }
    }
}