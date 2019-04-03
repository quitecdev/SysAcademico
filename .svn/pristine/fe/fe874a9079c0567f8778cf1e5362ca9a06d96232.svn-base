using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SysAcademico
{
    public partial class AdminInscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_INSCRIPCION));
                CargarProvincia();
                CargarSede();
                CargarInscripciones();
                CargarFormaPago();
                GridMateriasAsiganadas.DataSource = null;
                GridMateriasAsiganadas.DataBind();
                Session["dt_Materias"] = null;
                Session["dt_Carreras"] = null;
            }
        }

        public void CargarProvincia()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUbicacion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBP");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_provincia.DataSource = ds.Tables[0];
                cmb_provincia.DataTextField = ds.Tables[0].Columns["UBI_PROVINCIA"].ToString();
                cmb_provincia.DataBind();
                cmb_provincia.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
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

        protected void cmb_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUbicacion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBC");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@UBI_PROVINCIA", DbType.String, cmb_provincia.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_ciudad.DataSource = ds.Tables[0];
                cmb_ciudad.DataTextField = ds.Tables[0].Columns["UBI_CIUDAD"].ToString();
                cmb_ciudad.DataValueField = ds.Tables[0].Columns["UBI_ID"].ToString();
                cmb_ciudad.DataBind();
                cmb_ciudad.Items.Insert(0, "");
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


        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_materia.SelectedValue == "1" && cmb_horario.SelectedValue == "1")
                {
                    /*Agrego Materias*/
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OIMC");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    if (Session["dt_Materias"] != null)
                    {
                        ds.Merge(Session["dt_Materias"] as DataSet);
                    }
                    //GridMateriasAsiganadas.DataSource = ds;
                    GridMateriasAsiganadas.DataBind();
                    Session["dt_Materias"] = ds;

                    /*Agrego Carreras*/
                    DataSet ds2 = new DataSet();
                    DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBDM");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                    ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                    if (Session["dt_Carreras"] != null)
                    {
                        ds2.Merge(Session["dt_Carreras"] as DataSet);
                    }
                    Session["dt_Carreras"] = ds2;
                }
                else if (cmb_materia.SelectedValue == "4" && cmb_horario.SelectedValue == "2")
                {
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OIMP");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    if (Session["dt_Materias"] != null)
                    {
                        ds.Merge(Session["dt_Materias"] as DataSet);
                    }
                    //GridMateriasAsiganadas.DataSource = ds;
                    GridMateriasAsiganadas.DataBind();
                    Session["dt_Materias"] = ds;

                    /*Agrego Carreras*/
                    DataSet ds2 = new DataSet();
                    DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBDM");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                    ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                    if (Session["dt_Carreras"] != null)
                    {
                        ds2.Merge(Session["dt_Carreras"] as DataSet);
                    }
                    Session["dt_Carreras"] = ds2;
                }
                else
                {
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OIM");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    if (Session["dt_Materias"] != null)
                    {
                        ds.Merge(Session["dt_Materias"] as DataSet);
                    }
                    //GridMateriasAsiganadas.DataSource = ds;
                    GridMateriasAsiganadas.DataBind();
                    Session["dt_Materias"] = ds;

                    /*Agrego Carreras*/
                    DataSet ds2 = new DataSet();
                    DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBDM");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                    ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                    if (Session["dt_Carreras"] != null)
                    {
                        ds2.Merge(Session["dt_Carreras"] as DataSet);
                    }
                    Session["dt_Carreras"] = ds2;
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }
        protected void btn_agregar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_DI.Text != string.Empty)
                {
                    var estatus = "0";
                    //if (Convert.ToInt32(ds.Tables[0].Rows[0]["TOTAL"].ToString()) <= 28)
                    //{
                    DataSet ds2 = new DataSet();
                    DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "IN");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, id_inscripcion_detalle.Value);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INSCRIP", DbType.String, txt_DI.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_PARALELO", DbType.String, cmb_paralelo.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_TIPO_PAGO", DbType.String, cmb_forma_pago.SelectedValue);

                    if (cmb_forma_pago.SelectedValue == "2")
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@NUMERO_FACTURA", DbType.String, txt_factura.Text);
                    }
                    if (cmb_forma_pago.SelectedValue != "1")
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_ESTATUS", DbType.String, "1");
                        estatus = "1";
                    }
                    else
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_ESTATUS", DbType.String, "3");
                        estatus = "3";
                    }

                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                    ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, typeof(Page), "vi", "$('#con-close-modal').modal('hide');", true);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "alert('El registro se ha completado exitosamente.');", true);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "alert('El paralelo asiganado se encuentra al máximo de su capacidad.');", true);
                    //}
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_INSCRIPCION), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INSCRIP", txt_DI.Text), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_SEDE", cmb_sede.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_CARRERA", cmb_materia.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO", cmb_horario.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO_DETALLE", cmb_hora.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_PARALELO", cmb_paralelo.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_TIPO_PAGO", cmb_forma_pago.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_ESTATUS", estatus));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "alert('No se han ingresado el número de identidad.');", true);
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
            GridMateriasAsiganadas.DataBind();
            id_inscripcion_detalle.Value = "";

        }

        protected void GridMateriasAsiganadas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = e.RowIndex;
                DataTable dt = (Session["dt_Materias"]) as DataTable;
                DataRow row = dt.Rows[0];
                dt.Rows.Remove(row);
                //GridMateriasAsiganadas.DataSource = dt;
                GridMateriasAsiganadas.DataBind();
                Session["dt_Materias"] = dt;
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
                if (GridMateriasAsiganadas.Rows.Count > 0)
                {

                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DESCRIPCION_NACIONALIDAD", DbType.String, cmb_nacionalidad.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_PATERNO_INSCRIP", DbType.String, txt_apellido_paterno.Text.ToUpper());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_MATERNO_INSCRIP", DbType.String, txt_apellido_materno.Text.ToUpper());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@PRIMER_NOMBRE_INSCRIP", DbType.String, txt_primer_nombre.Text.ToUpper());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@SEGUNDO_NOMBRE_INSCRIP", DbType.String, txt_segundo_nombre.Text.ToUpper());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CORREO", DbType.String, txt_correo.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FECHA_NACIMIENTO_INSCRIP", DbType.DateTime, Convert.ToDateTime(txt_fecha_nacimiento.Text));
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTADO_CIVIL", DbType.Int32, Convert.ToInt32(cmb_estado_civil.SelectedValue));
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PROVINCIA", DbType.Int32, Convert.ToInt32("1"));
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CIUDAD", DbType.Int32, Convert.ToInt32(cmb_ciudad.SelectedValue));
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DIRECCION", DbType.String, txt_direccion.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@TELEF_INSCRIP", DbType.String, txt_telf.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CEL_INSCRIP", DbType.String, txt_celular.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@TELEF_EMER_INSCRIP", DbType.String, txt_emergencia.Text);

                    if (ckb_docIdent.Checked == true)
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DOC_IDENTIDAD", DbType.Int32, 1);
                    }
                    if (ckb_foto.Checked == true)
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FOTOGRAFIA", DbType.Int32, 1);
                    }
                    if (ckb_papeleta.Checked == true)
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@PAPELETA_VOT", DbType.Int32, 1);
                    }
                    if (ckb_certf.Checked == true)
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CERT_MEDICO", DbType.Int32, 1);
                    }

                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_INSCRIPCION), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INSCRIP", txt_DI.Text));
                    GuardarEncueta();
                    Imprimir();
                    LimpiarControles.Limpiar(this.Controls);
                    GridMateriasAsiganadas.DataSource = null;
                    GridMateriasAsiganadas.DataBind();
                    id_inscripcion_detalle.Value = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "alert('No se han asigando carreras.');", true);
                }

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }

        }


        public void GuardarEncueta()
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminEncuesta");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
            if (rd_web.Checked == true)
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@WEB", DbType.Int32, 1);
            if (rd_amigo.Checked == true)
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@AMIGOS", DbType.Int32, 1);
            if (rd_facebook.Checked == true)
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FACEBOK", DbType.Int32, 1);
            if (rd_twitter.Checked == true)
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@TWITTER", DbType.Int32, 1);
            if (rd_otro.Checked == true)
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OTROS", DbType.Int32, 1);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
        }

        Document document = null;
        PdfWriter pdfw = null;
        MemoryStream msResultado = new MemoryStream();
        Pdf_Eventos ev = new Pdf_Eventos();

        public void Imprimir()
        {
            string PathOut = null;
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("Inscripciones"));

            try
            {

                //Crear Documento Pdf
                if (document == null)
                {
                    document = new Document(PageSize.A4, 30f, 30f, 150f, 90f);
                    pdfw = PdfWriter.GetInstance(document, msResultado);
                    document.Open();
                }
                //Configuro la pagina
                Rectangle pageSize = new Rectangle(PageSize.A4);
                document.SetPageSize(pageSize);
                document.SetMargins(30f, 30f, 150f, 90f);

                //Agrego la Plantilla a la Primera Pagina
                PdfContentByte cb = pdfw.DirectContent;
                PdfImportedPage page1 = null;
                PdfReader reader = new PdfReader(Server.MapPath("./doc/PlantillaHojaInscripcion.pdf"));
                page1 = pdfw.GetImportedPage(reader, 1);
                cb.AddTemplate(page1, 0, 0, 0, 0, 0, 0);

                //Manejo Eventos para Agregar la Plantilla a nuevas paginas
                //////Expediente_Eventos ev = new Expediente_Eventos();
                ev.PdfW = pdfw;
                ev.RutaPlantilla = Server.MapPath("./doc/PlantillaHojaInscripcion.pdf");
                pdfw.PageEvent = ev;


                /*FONT*/
                Font font_Cabeceras = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD);
                Font font_Cabeceras2 = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(255, 255, 255));
                Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
                Font fontNormalHorario = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL);
                Font fontNormalHorarioCabecera = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD);

                /*DOCUMENTO INICIAL*/
                PathOut = txt_DI.Text.ToString() + ".pdf";// "SalidaPDF.pdf";
                Session["FULLPATHOUT_INSCRIPCION"] = Path.Combine(di.ToString(), PathOut);
                pdfw = PdfWriter.GetInstance(document, new FileStream(Session["FULLPATHOUT_INSCRIPCION"].ToString(), FileMode.Create));

                /*SEPARADOR*/
                float[] anchoColumna = { 30 };
                PdfPTable separador = new PdfPTable(1);
                separador.SetTotalWidth(anchoColumna);
                separador.DefaultCell.Border = PdfTable.NO_BORDER;
                separador.DefaultCell.FixedHeight = 10;
                separador.AddCell(new Phrase("", fontNormal));

                document.Open();

                Paragraph DatosPersonales = new Paragraph(new Chunk("DATOS PERSONALES", FontFactory.GetFont(FontFactory.HELVETICA, 15, iTextSharp.text.Font.BOLD)));
                DatosPersonales.Alignment = Element.ALIGN_LEFT;
                document.Add(DatosPersonales);
                document.Add(separador);
                document.Add(separador);

                //DATOS PERSONALES 
                PdfPTable tableDatosPersonales = new PdfPTable(2);
                float[] anchoColumnastblTotal = { 270, 800 };
                tableDatosPersonales.WidthPercentage = 100;
                tableDatosPersonales.SetTotalWidth(anchoColumnastblTotal);
                tableDatosPersonales.DefaultCell.Border = PdfTable.NO_BORDER;
                tableDatosPersonales.HorizontalAlignment = Element.ALIGN_RIGHT;

                tableDatosPersonales.AddCell((new Phrase("Nº Docuemento de identidad:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(txt_DI.Text, fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Nombre:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(txt_apellido_paterno.Text.ToUpper() + " " + txt_apellido_materno.Text.ToUpper() + " " + txt_primer_nombre.Text.ToUpper() + " " + txt_segundo_nombre.Text.ToUpper(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Fecha Nacimiento:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(txt_fecha_nacimiento.Text, fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Estado Civil:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(cmb_estado_civil.SelectedItem.ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Correo Electrónico:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(txt_correo.Text, fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Teléfono Fijo:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(txt_telf.Text, fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Celular:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(txt_celular.Text, fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Teléfono de Emergencia:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(txt_emergencia.Text, fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Dirección:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(cmb_provincia.SelectedItem.ToString() + ", " + cmb_ciudad.SelectedItem.ToString() + ", " + txt_direccion.Text, fontNormal)));

                document.Add(tableDatosPersonales);
                document.Add(separador);
                document.Add(separador);

                Paragraph DatosCarrera = new Paragraph(new Chunk("DATOS CARRERA", FontFactory.GetFont(FontFactory.HELVETICA, 15, iTextSharp.text.Font.BOLD)));
                DatosCarrera.Alignment = Element.ALIGN_LEFT;
                document.Add(DatosCarrera);
                document.Add(separador);
                document.Add(separador);

                ////DATOS CARRERA
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBPDF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);


                //CREAMOS EL GRIDVIEW
                GridView GridDetalle = new GridView();
                GridDetalle.AllowPaging = false;
                GridDetalle.DataSource = ds;
                GridDetalle.DataBind();

                PdfPTable tableDetalle = new PdfPTable(7);
                tableDetalle.WidthPercentage = 100;


                float[] anchoColumnastblDetalle = { 200, 350, 350, 250, 250, 250, 350 };
                tableDetalle.SetTotalWidth(anchoColumnastblDetalle);
                tableDetalle.DefaultCell.Border = PdfTable.NO_BORDER;
                if (GridDetalle.HeaderRow != null)
                {
                    for (int x = 0; x < ds.Tables[0].Columns.Count; x++)
                    {
                        string cellText = Server.HtmlDecode(GridDetalle.HeaderRow.Cells[x].Text);
                        PdfPCell cell = new PdfPCell(new Paragraph(cellText, fontNormalHorarioCabecera));
                        cell.BackgroundColor = Color.LIGHT_GRAY;
                        tableDetalle.AddCell(cell);
                    }

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            string cellText = Server.HtmlDecode(dr.Table.Rows[i][j].ToString());
                            PdfPCell cell = new PdfPCell(new Paragraph(cellText, fontNormalHorario));
                            tableDetalle.AddCell(cell);
                        }

                        i++;
                    }
                }
                document.Add(tableDetalle);
                document.Add(separador);
                document.Add(separador);

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
            finally
            {
                document.Close();
                File.WriteAllBytes(Session["FULLPATHOUT_INSCRIPCION"].ToString(), msResultado.ToArray());
                string Src = "./Inscripciones/" + PathOut;
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, typeof(Page), "vi", "PdfInscripcion('" + Src + "')", true);
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_IMPRESION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_INSCRIPCION), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ARCHIVO", Src));
            }
        }

        protected void txt_DI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool res = false;

                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "BEX");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "EXISTE")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "alert('El Documento de Identidad ingresado ya existe.');", true);
                    txt_DI.Text = "";
                    txt_DI.Focus();
                }
                else if (cmb_nacionalidad.SelectedItem.Text != "Pasaporte" && cmb_nacionalidad.SelectedItem.Text != "PASAPORTE")
                {
                    ValidarCedula ObjCed = new ValidarCedula(this.txt_DI.Text, cmb_nacionalidad.SelectedItem.Text);
                    ObjCed.comprobar_num();
                    res = ObjCed.res;
                    if (res == false)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "ValidarCedula();", true);
                        txt_DI.Text = "";
                        txt_DI.Focus();
                    }
                }
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
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBCFS");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
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
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
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


        public void CargarFormaPago()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminTipoPago");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_forma_pago.DataSource = ds.Tables[0];
                cmb_forma_pago.DataTextField = ds.Tables[0].Columns["DESCRIPCION_TIPO_PAGO"].ToString();
                cmb_forma_pago.DataValueField = ds.Tables[0].Columns["ID_TIPO_PAGO"].ToString();
                cmb_forma_pago.DataBind();
                cmb_forma_pago.Items.Insert(0, "");

                cmb_formaPagoEditar.DataSource = ds.Tables[0];
                cmb_formaPagoEditar.DataTextField = ds.Tables[0].Columns["DESCRIPCION_TIPO_PAGO"].ToString();
                cmb_formaPagoEditar.DataValueField = ds.Tables[0].Columns["ID_TIPO_PAGO"].ToString();
                cmb_formaPagoEditar.DataBind();
                cmb_formaPagoEditar.Items.Insert(0, "");

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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminParaleloMateria");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBPF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_materia.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
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

        protected void btn_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles.Limpiar(this.Controls);
            GridMateriasAsiganadas.DataSource = null;
            GridMateriasAsiganadas.DataBind();
            Session["dt_Materias"] = null;
            Session["dt_Carreras"] = null;

        }

        public void CargarInscripciones()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB2");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                GridInscripcion.DataSource = ds;
                GridInscripcion.DataBind();
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void GridInscripcion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {

                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, e.CommandArgument.ToString());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                    cmb_nacionalidad.SelectedValue = ds.Tables[0].Rows[0]["DESCRIPCION_NACIONALIDAD"].ToString();
                    txt_DI.Text = ds.Tables[0].Rows[0]["ID_INSCRIP"].ToString();
                    txt_apellido_paterno.Text = ds.Tables[0].Rows[0]["APELLIDO_PATERNO_INSCRIP"].ToString();
                    txt_apellido_materno.Text = ds.Tables[0].Rows[0]["APELLIDO_MATERNO_INSCRIP"].ToString();
                    txt_primer_nombre.Text = ds.Tables[0].Rows[0]["PRIMER_NOMBRE_INSCRIP"].ToString();
                    txt_segundo_nombre.Text = ds.Tables[0].Rows[0]["SEGUNDO_NOMBRE_INSCRIP"].ToString();
                    txt_fecha_nacimiento.Text = ds.Tables[0].Rows[0]["FECHA_NACIMIENTO_INSCRIP"].ToString();
                    cmb_estado_civil.SelectedValue = ds.Tables[0].Rows[0]["ID_ESTADO_CIVIL"].ToString();
                    txt_telf.Text = ds.Tables[0].Rows[0]["TELEF_INSCRIP"].ToString();
                    txt_celular.Text = ds.Tables[0].Rows[0]["CEL_INSCRIP"].ToString();
                    txt_emergencia.Text = ds.Tables[0].Rows[0]["TELEF_EMER_INSCRIP"].ToString();
                    txt_correo.Text = ds.Tables[0].Rows[0]["CORREO"].ToString();
                    cmb_provincia.SelectedValue = ds.Tables[0].Rows[0]["UBI_PROVINCIA"].ToString();

                    DataSet dsC = new DataSet();
                    DbCommand cmdC = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUbicacion");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdC, "@OPERACION", DbType.String, "OB");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdC, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdC, "@outID", DbType.Int32, 10);
                    dsC = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmdC);
                    cmb_ciudad.DataSource = dsC.Tables[0];
                    cmb_ciudad.DataTextField = dsC.Tables[0].Columns["UBI_CIUDAD"].ToString();
                    cmb_ciudad.DataValueField = dsC.Tables[0].Columns["UBI_ID"].ToString();
                    cmb_ciudad.DataBind();
                    cmb_ciudad.Items.Insert(0, "");

                    cmb_ciudad.SelectedValue = ds.Tables[0].Rows[0]["UBI_ID"].ToString();
                    txt_direccion.Text = ds.Tables[0].Rows[0]["DIRECCION2"].ToString();

                    if (ds.Tables[0].Rows[0]["DOC_IDENTIDAD"].ToString() == "True")
                    {
                        ckb_docIdent.Checked = true;
                    }
                    else
                    {
                        ckb_docIdent.Checked = false;
                    }

                    if (ds.Tables[0].Rows[0]["PAPELETA_VOT"].ToString() == "True")
                    {
                        ckb_papeleta.Checked = true;
                    }
                    else
                    {
                        ckb_papeleta.Checked = false;
                    }

                    if (ds.Tables[0].Rows[0]["FOTOGRAFIA"].ToString() == "True")
                    {
                        ckb_foto.Checked = true;
                    }
                    else
                    {
                        ckb_foto.Checked = false;
                    }

                    if (ds.Tables[0].Rows[0]["CERT_MEDICO"].ToString() == "True")
                    {
                        ckb_certf.Checked = true;
                    }
                    else
                    {
                        ckb_certf.Checked = false;
                    }

                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, typeof(Page), "vi", "$('#modalBuscar').modal('hide');", true);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridInscripcion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string url = GridInscripcion.DataKeys[e.Row.RowIndex]["URL"].ToString();
                var VerArchivo = e.Row.FindControl("lnk_documento") as LinkButton;
                VerArchivo.Attributes.Add("href", url);
                VerArchivo.Attributes.Add("target", "_blank");
            }
        }

        protected void GridInscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridInscripcion_PreRender(object sender, EventArgs e)
        {
            // You only need the following 2 lines of code if you are not 
            // using an ObjectDataSource of SqlDataSource
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB2");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            GridInscripcion.DataSource = ds;
            GridInscripcion.DataBind();

            if (GridInscripcion.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                GridInscripcion.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                GridInscripcion.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                GridInscripcion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void cmb_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_forma_pago.SelectedValue == "2")
            {
                txt_factura.Enabled = true;
            }
            else
            {
                txt_factura.Enabled = false;
            }

        }

        protected void GridMateriasAsiganadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
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
                    cmb_sedeEditar.Enabled = false;
                    CargarMateriaEditar();
                    cmb_carrearEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_CARRERA"].ToString();
                    cmb_carrearEditar_SelectedIndexChanged(cmb_carrearEditar, EventArgs.Empty);
                    cmb_carrearEditar.Enabled = false;
                    cmb_horarioEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_INTERVALO"].ToString();
                    CargarHoraEditar();
                    cmb_horaEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_INTERVALO_DETALLE"].ToString();
                    cmb_horaEditar_SelectedIndexChanged(cmb_horaEditar, EventArgs.Empty);
                    if (ds.Tables[0].Rows[0]["ID_PARALELO"].ToString()!="0")
                    {
                        cmb_ParaleloEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_PARALELO"].ToString();
                    }
                    cmb_formaPagoEditar.SelectedValue = ds.Tables[0].Rows[0]["ID_TIPO_PAGO"].ToString();
                    cmb_formaPagoEditar_SelectedIndexChanged(cmb_formaPagoEditar, EventArgs.Empty);
                    txt_facturaEditar.Text = ds.Tables[0].Rows[0]["NUMERO_FACTURA"].ToString();
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, typeof(Page), "vi", "$('#modalEditar').modal('show');", true);

                }
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }

        public void CargarMateriaEditar()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBCP");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
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

        protected void GridMateriasAsiganadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ob = e.Row.FindControl("ID_INSCRIPCION_ESTADO") as Label;
                string estado = ob.Text;
                var ElimnarRegistro = e.Row.FindControl("DESCRIPCION_ESTADO") as Label;

                if (estado == "1")
                {
                    ElimnarRegistro.Attributes.Add("class", "label label-success");
                }
                else
                {
                    ElimnarRegistro.Attributes.Add("class", "label label-warning");
                }

                //var estado_pediodo = e.Row.FindControl("ESTADO") as HiddenField;
                //string valor = estado_pediodo.Value;

                //var controlEditar = e.Row.FindControl("lnk_eliminar") as LinkButton;
                //if (valor != "3")
                //{
                //    controlEditar.Visible = false;
                //}


                //string factura = GridInscripcion.DataKeys[e.Row.RowIndex]["NUMERO_FACTURA"].ToString();
                //string url = GridInscripcion.DataKeys[e.Row.RowIndex]["URL"].ToString();

                //var ModificarRegistro = e.Row.FindControl("Seleccionar") as LinkButton;
                //var ElimnarRegistro = e.Row.FindControl("lb_estado") as Label;

                //var VerArchivo = e.Row.FindControl("lnk_documento") as LinkButton;

                //if (estado == "1")
                //{
                //    if (factura != string.Empty)
                //    {
                //        ModificarRegistro.Visible = false;
                //        ElimnarRegistro.Attributes.Add("class", "label label-success");
                //        VerArchivo.Visible = true;
                //        VerArchivo.Attributes.Add("href", url);
                //        VerArchivo.Attributes.Add("target", "_blank");
                //    }
                //    else
                //    {
                //        ModificarRegistro.Visible = true;
                //        ElimnarRegistro.Attributes.Add("class", "label label-warning");
                //        VerArchivo.Visible = false;
                //    }
                //}
                //else if (estado == "2")
                //{
                //    ModificarRegistro.Visible = true;
                //    ElimnarRegistro.Attributes.Add("class", "label label-primary");
                //    VerArchivo.Visible = true;
                //    VerArchivo.Attributes.Add("href", url);
                //    VerArchivo.Attributes.Add("target", "_blank");
                //}
                //else if (estado == "3")
                //{
                //    ModificarRegistro.Visible = true;
                //    ElimnarRegistro.Attributes.Add("class", "label label-warning");
                //    VerArchivo.Visible = false;
                //}
                //else if (estado == "4")
                //{
                //    ModificarRegistro.Visible = true;
                //    ElimnarRegistro.Attributes.Add("class", "label label-danger");
                //    VerArchivo.Visible = false;
                //}
            }
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
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
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

        protected void cmb_formaPagoEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_formaPagoEditar.SelectedValue == "2")
            {
                txt_facturaEditar.Enabled = true;
            }
            else
            {
                txt_facturaEditar.Enabled = false;
            }
        }

        protected void bnt_actualizarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_DI.Text != string.Empty)
                {
                    var estatus = "0";
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalleCarrera");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP_DETALLE_CARRERA", DbType.String, id_inscripcion_detalle.Value);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sedeEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrearEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horarioEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_horaEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PARALELO", DbType.String, cmb_ParaleloEditar.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_TIPO_PAGO", DbType.String, cmb_formaPagoEditar.SelectedValue);

                    if (cmb_formaPagoEditar.SelectedValue == "2")
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@NUMERO_FACTURA", DbType.String, txt_facturaEditar.Text);
                    }
                    if (cmb_formaPagoEditar.SelectedValue != "1")
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTATUS", DbType.String, "1");
                        estatus = "1";
                    }
                    else
                    {
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTATUS", DbType.String, "3");
                        estatus = "3";
                    }

                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, typeof(Page), "vi", "$('#con-close-modal').modal('hide');", true);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "alert('El registro se ha completado exitosamente.');", true);

                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_INSCRIPCION), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INSCRIP", txt_DI.Text), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_SEDE", cmb_sede.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_CARRERA", cmb_materia.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO", cmb_horario.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INTERVALO_DETALLE", cmb_hora.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_PARALELO", cmb_paralelo.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_TIPO_PAGO", cmb_forma_pago.SelectedValue), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_ESTATUS", estatus));

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel3, typeof(Page), "Validar", "alert('No se han ingresado el número de identidad.');", true);
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
            GridMateriasAsiganadas.DataBind();
            id_inscripcion_detalle.Value = "";
        }

    }
}