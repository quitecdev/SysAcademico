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
    public partial class AUX_CORREGIR_INSCRIPCION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSede();
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

                cmb_sedeEditar.DataSource = ds.Tables[0];
                cmb_sedeEditar.DataTextField = ds.Tables[0].Columns["DESCRIPCION_UNIVERSIDAD"].ToString();
                cmb_sedeEditar.DataValueField = ds.Tables[0].Columns["ID_SEDE"].ToString();
                cmb_sedeEditar.DataBind();
                cmb_sedeEditar.Items.Insert(0, "");
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_materia.DataSource = ds.Tables[0];
                cmb_materia.DataTextField = ds.Tables[0].Columns["DESCRIPCION_CARRERA"].ToString();
                cmb_materia.DataValueField = ds.Tables[0].Columns["ID_CARRERA"].ToString();
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervalo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBIF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horario.DataSource = ds.Tables[0];
                cmb_horario.DataTextField = ds.Tables[0].Columns["DESCRIPCION_INTERVALO"].ToString();
                cmb_horario.DataValueField = ds.Tables[0].Columns["ID_INTERVALO"].ToString();
                cmb_horario.DataBind();
                cmb_horario.Items.Insert(0, "");
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBDF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_hora.DataSource = ds.Tables[0];
                cmb_hora.DataTextField = ds.Tables[0].Columns["INTERVALO"].ToString();
                cmb_hora.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_hora.DataBind();
                cmb_hora.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_hora_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "VI1");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                GridCarrera.DataSource = ds;
                GridCarrera.DataBind();
                //cmb_paralelo.DataSource = ds.Tables[0];
                //cmb_paralelo.DataTextField = ds.Tables[0].Columns["DESCRIPCION_PARALELO"].ToString();
                //cmb_paralelo.DataValueField = ds.Tables[0].Columns["ID_PARALELO"].ToString();
                //cmb_paralelo.DataBind();
                //cmb_paralelo.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }

        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        protected void GridCarrera_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBP");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, e.CommandArgument.ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                id_inscripcion_detalle.Value = e.CommandArgument.ToString();
                cmb_sedeEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_SEDE"].ToString();
                CargarMateriaEditar();
                cmb_carrearEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_CARRERA"].ToString();
                cmb_carrearEditar_SelectedIndexChanged(cmb_carrearEditar, EventArgs.Empty);
                cmb_horarioEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_INTERVALO"].ToString();
                CargarHoraEditar();
                cmb_horaEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_INTERVALO_DETALLE"].ToString();
                cmb_horaEditar_SelectedIndexChanged(cmb_horaEditar, EventArgs.Empty);
                cmb_ParaleloEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_PARALELO"].ToString();
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(Page), "vi", "$('#modalEditar').modal('show');", true);
            }
            else if (e.CommandName == "Ocultar")
            {
                id_inscripcion_detalle.Value = e.CommandArgument.ToString();

                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OC");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, e.CommandArgument.ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

            }

            cmb_hora_SelectedIndexChanged(cmb_hora, EventArgs.Empty);
        }

        protected void cmb_sedeEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBCPF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, id_inscripcion_detalle.Value);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_carrearEditar.DataSource = ds.Tables[0];
                cmb_carrearEditar.DataTextField = ds.Tables[0].Columns["DESCRIPCION_CARRERA"].ToString();
                cmb_carrearEditar.DataValueField = ds.Tables[0].Columns["ID_CARRERA"].ToString();
                cmb_carrearEditar.DataBind();

                DataSet ds2 = new DataSet();
                DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervalo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBIFP");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, id_inscripcion_detalle.Value);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                cmb_horarioEditar.DataSource = ds2.Tables[0];
                cmb_horarioEditar.DataTextField = ds2.Tables[0].Columns["DESCRIPCION_INTERVALO"].ToString();
                cmb_horarioEditar.DataValueField = ds2.Tables[0].Columns["ID_INTERVALO"].ToString();
                cmb_horarioEditar.DataBind();
                cmb_horarioEditar.Items.Insert(0, "");

                cmb_horaEditar.Items.Clear();
                cmb_ParaleloEditar.Items.Clear();



            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_horarioEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBDF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrearEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horarioEditar.SelectedValue);
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horaEditar.DataSource = ds.Tables[0];
                cmb_horaEditar.DataTextField = ds.Tables[0].Columns["INTERVALO"].ToString();
                cmb_horaEditar.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_horaEditar.DataBind();
                cmb_horaEditar.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }


        public void CargarMateriaEditar()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, id_inscripcion_detalle.Value);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_carrearEditar.DataSource = ds.Tables[0];
                cmb_carrearEditar.DataTextField = ds.Tables[0].Columns["DESCRIPCION_CARRERA"].ToString();
                cmb_carrearEditar.DataValueField = ds.Tables[0].Columns["ID_CARRERA"].ToString();
                cmb_carrearEditar.DataBind();
                cmb_carrearEditar.Items.Insert(0, "");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cmb_carrearEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervalo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBIF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrearEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horarioEditar.DataSource = ds.Tables[0];
                cmb_horarioEditar.DataTextField = ds.Tables[0].Columns["DESCRIPCION_INTERVALO"].ToString();
                cmb_horarioEditar.DataValueField = ds.Tables[0].Columns["ID_INTERVALO"].ToString();
                cmb_horarioEditar.DataBind();
                cmb_horarioEditar.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        public void CargarHoraEditar()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBDF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrearEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horarioEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horaEditar.DataSource = ds.Tables[0];
                cmb_horaEditar.DataTextField = ds.Tables[0].Columns["INTERVALO"].ToString();
                cmb_horaEditar.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_horaEditar.DataBind();
                cmb_horaEditar.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_horaEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminParaleloMateria");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBPF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrearEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horarioEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_horaEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_ParaleloEditar.DataSource = ds.Tables[0];
                cmb_ParaleloEditar.DataTextField = ds.Tables[0].Columns["DESCRIPCION_PARALELO"].ToString();
                cmb_ParaleloEditar.DataValueField = ds.Tables[0].Columns["ID_PARALELO"].ToString();
                cmb_ParaleloEditar.DataBind();
                cmb_ParaleloEditar.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void bnt_actualizarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_inscripcion_detalle.Value != string.Empty)
                {

                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "ACC");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, id_inscripcion_detalle.Value);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrearEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horarioEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_horaEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO", DbType.String, cmb_ParaleloEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(Page), "vi", "$('#con-close-modal').modal('hide');", true);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(Page), "Validar", "alert('El registro se ha completado exitosamente.');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(Page), "Validar", "alert('No se han ingresado el número de identidad.');", true);
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
            id_inscripcion_detalle.Value = "";
        }


        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridCarrera.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("cbk_ok") as CheckBox);
                    if (chkRow.Checked == false)
                    {
                        string id_detalle = row.Cells[8].Text;

                        DataSet ds = new DataSet();
                        DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OC");
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, id_detalle);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                        ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    }
                }
            }
            cmb_hora_SelectedIndexChanged(cmb_hora, EventArgs.Empty);
        }

    }
}