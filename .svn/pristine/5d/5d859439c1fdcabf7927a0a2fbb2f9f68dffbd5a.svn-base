using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SysAcademico
{
    public partial class AdminCronogramaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCronograma();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(
                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(),
                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(),
                                                        Session.SessionID,
                                                        ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR,
                                                        ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_CRONOGRAMA_DETALLE));
            }

        }

        public void CargarCronograma()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronograma");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_cronograma.DataSource = ds.Tables[0];
                cmb_cronograma.DataTextField = ds.Tables[0].Columns["DESCRIPCION_CRONOGRAMA"].ToString();
                cmb_cronograma.DataValueField = ds.Tables[0].Columns["ID_CRONOGRAMA"].ToString();
                cmb_cronograma.DataBind();
                cmb_cronograma.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_cronograma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["ID_CRONOGRAMA_DETALLE"] = ((Label)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ID_CRONOGRAMA_DETALLE")).Text;
            e.InputParameters["TEMA"] = ((TextBox)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_tema")).Text;
            e.InputParameters["TEMATICA"] = ((TextBox)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_tematica")).Text;
            e.InputParameters["REQUERIMIENTO"] = ((TextBox)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("txt_requerimiento")).Text;
            e.InputParameters["FERIADO"] = ((CheckBox)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[1].FindControl("ckb_feriado")).Checked.ToString();
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_CRONOGRAMA), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_CRONOGRAMA_DETALLE", ((Label)GridCarrera.Rows[Convert.ToInt32(hd_index.Value)].Cells[2].FindControl("ID_CRONOGRAMA_DETALLE")).Text));
        }



        protected void GridCarrera_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hd_index.Value = e.RowIndex.ToString();
        }

        protected void GridCarrera_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Adjunto")
            {
                hd_index.Value = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "$('#myModal').modal('show');ConfigurarFrame('iframe_BuscarInscripciones', './iframe_SubirContenido.aspx?descripcion=" + hd_index.Value + "');", true);
            }
        }

        protected void GridCarrera_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var _tema = e.Row.FindControl("TEMA") as Label;

                var _lnk_eliminar = e.Row.FindControl("lnk_eliminar") as LinkButton;

                if (_tema != null)
                {
                    if (_tema.Text != string.Empty)
                    {
                        _lnk_eliminar.Visible = true;
                    }
                    else
                    {
                        _lnk_eliminar.Visible = false;
                    }
                }

                //VerArchivo.Attributes.Add("href", url);
                //VerArchivo.Attributes.Add("target", "_blank");
            }
        }
    }
}