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
    public partial class AdminCarreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(
                                                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), 
                                                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), 
                                                                                        Session.SessionID, 
                                                                                        ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, 
                                                                                        ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_CARRERA));
                Session["ID_CARRERA"] = 1;
            }
        }

        protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_CARRERA"] = ((Label)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_CARRERA")).Text;
        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_CARRERA"] = ((Label)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_CARRERA")).Text;
            e.InputParameters["DESCRIPCION_CARRERA"] = ((TextBox)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_descripcion")).Text;
            e.InputParameters["NOMBRE_TECNICO_CARRERA"] = ((TextBox)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_nombre")).Text;
            e.InputParameters["COD_CARRERA"] = ((TextBox)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_codigo")).Text;
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_CARRERA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_CARRERA", ((Label)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_CARRERA")).Text));
        }

        protected void GridCarrera_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

        protected void GridCarrera_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Label cantidadAnterior = GridCarrera.Rows[e.NewEditIndex].FindControl("CANTIDAD_PRODUCTO") as Label;
            //hd_cantidad_anterior.Value = cantidadAnterior.Text;
            //TextBox txtCantidad = GridDetalle.Rows[e.NewEditIndex].FindControl("txt_cantidad") as TextBox;
        }

        protected void GridCarrera_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "IN");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DESCRIPCION_CARRERA", DbType.String, txt_nombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@NOMBRE_TECNICO_CARRERA", DbType.String, txt_taller.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@COD_CARRERA", DbType.String, txt_codigo.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje == "OK: Insertado con Exito")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('El registro se ha completado exitosamente.');", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#con-close-modal').modal('hide');", true);
                    GridCarrera.DataBind();
                    LimpiarControles.Limpiar(this.Controls);
                    ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_CARRERA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_CARRERA", outID.ToString()));
                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void GridCarrera_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }


    }
}