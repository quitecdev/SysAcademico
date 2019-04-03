using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAcademico
{
    public partial class NotaDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSede();
                CargarDocente();
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
        }

        public void CargarSede()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBS");
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_sede.DataSource = ds.Tables[0];
                cmb_sede.DataTextField = ds.Tables[0].Columns["DESCRIPCION_UNIVERSIDAD"].ToString();
                cmb_sede.DataValueField = ds.Tables[0].Columns["ID_SEDE"].ToString();
                cmb_sede.DataBind();
                cmb_sede.Items.Insert(0, "");

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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBC");
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
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

        protected void cmb_carrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBN");
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_nota.DataSource = ds.Tables[0];
                cmb_nota.DataTextField = ds.Tables[0].Columns["DESCRIPCION_NOTA"].ToString();
                cmb_nota.DataValueField = ds.Tables[0].Columns["ID_NOTA"].ToString();
                cmb_nota.DataBind();
                cmb_nota.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_nota_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBIN");
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horario.DataSource = ds.Tables[0];
                cmb_horario.DataTextField = ds.Tables[0].Columns["DETALLE"].ToString();
                cmb_horario.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_horario.DataBind();
                cmb_horario.Items.Insert(0, "");
                //DefinirColumnas(ds);
                //GridView1.DataSource = ds;
                //GridView1.DataBind();

                //GridNotasDetalle.DataSource = ds;
                //GridNotasDetalle.DataBind();

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_docente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminDocenteNotas");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBS");
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_sede.DataSource = ds.Tables[0];
                cmb_sede.DataTextField = ds.Tables[0].Columns["DESCRIPCION_UNIVERSIDAD"].ToString();
                cmb_sede.DataValueField = ds.Tables[0].Columns["ID_SEDE"].ToString();
                cmb_sede.DataBind();
                cmb_sede.Items.Insert(0, "");

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
                GridView1.Columns.Clear();
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.sp_NotasPivot");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, cmb_docente.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, cmb_nota.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CabeceraDinamica(ds);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AlertaSession", "alert('¡Vaya! Parece que no existen notas para ingresar. ');", true);
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        public void CabeceraDinamica(DataSet ds)
        {
            GridView1.Columns.Clear();
            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                if (column.ColumnName == "IDENTIDAD")
                {
                    BoundField bfield = new BoundField();
                    bfield.HeaderText = (column.ColumnName);
                    bfield.DataField = (column.ColumnName);
                    GridView1.Columns.Add(bfield);
                }
                else if (column.ColumnName == "NOMBRE")
                {
                    BoundField bfield = new BoundField();
                    bfield.HeaderText = (column.ColumnName);
                    bfield.DataField = (column.ColumnName);
                    GridView1.Columns.Add(bfield);
                }
                else
                {
                    TemplateField tempPrecio = new TemplateField();
                    tempPrecio.HeaderTemplate = new GridViewHeaderTemplate(column.ColumnName);
                    tempPrecio.ItemTemplate = new GridViewItemTemplate(column.ColumnName);
                    GridView1.Columns.Add(tempPrecio);
                    //TemplateField tfield = new TemplateField();
                    //tfield.HeaderText = column.ColumnName;
                    //GridView1.Columns.Add(tfield);
                }
            }

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        public void VerNotas()
        {

        }



        [WebMethod()]
        public static string ActualizarNota(string ID_ESTUDIANTE, string DESCRIPCION_PONDERACION, string VALOR_NOTA)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminEstudianteNota");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "AC");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE", DbType.String, ID_ESTUDIANTE);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DESCRIPCION_PONDERACION", DbType.String, DESCRIPCION_PONDERACION);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@VALOR_NOTA", DbType.Decimal, Convert.ToDecimal(VALOR_NOTA));
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            return Convert.ToString("");
        }


        #region FuncionDinamica


        public class GridViewHeaderTemplate : ITemplate
        {
            string text;

            public GridViewHeaderTemplate(string text)
            {
                this.text = text;
            }

            public void InstantiateIn(System.Web.UI.Control container)
            {
                Literal lc = new Literal();
                lc.Text = text;

                container.Controls.Add(lc);

            }
        }

        public class GridViewItemTemplate : ITemplate
        {
            private string columnName;

            public GridViewItemTemplate(string columnName)
            {
                this.columnName = columnName;
            }

            public void InstantiateIn(System.Web.UI.Control container)
            {
                TextBox tb = new TextBox();
                tb.ID = string.Format("txt{0}", columnName);
                tb.Attributes.Add("class", "form-control decimal");
                tb.Attributes.Add("data-nota", columnName);
                tb.Attributes.Add("style", "width: 65px");
                tb.DataBinding += new EventHandler(tb_DataBinding);

                container.Controls.Add(tb);
            }

            void tb_DataBinding(object sender, EventArgs e)
            {
                TextBox t = (TextBox)sender;

                GridViewRow row = (GridViewRow)t.NamingContainer;

                string RawValue = DataBinder.Eval(row.DataItem, columnName).ToString();

                t.Text = RawValue;
            }
        }


        #endregion

    }
}