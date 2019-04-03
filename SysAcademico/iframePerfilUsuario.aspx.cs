using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAcademico
{
    public partial class iframePerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosPerfil();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_PERFIL_USUARIO));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CargarDatosPerfil()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand(((util)HttpContext.Current.Session["util"]).ROL_USUARIO);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBFU");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_USUARIO", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ID_USUARIO.Value = ds.Tables[0].Rows[0]["ID_USUARIO"].ToString();
                    txt_apellido_paterno.Text = ds.Tables[0].Rows[0]["APELLIDO_PATERNO"].ToString();
                    txt_apellido_materno.Text = ds.Tables[0].Rows[0]["APELLIDO_MATERNO"].ToString();
                    txt_primer_nombre.Text = ds.Tables[0].Rows[0]["PRIMER_NOMBRE"].ToString();
                    txt_segundo_nombre.Text = ds.Tables[0].Rows[0]["SEGUNDO_NOMBRE"].ToString();
                    txt_celular.Text = ds.Tables[0].Rows[0]["CELULAR"].ToString();
                    txt_correo.Text = ds.Tables[0].Rows[0]["CORREO"].ToString();
                    txt_direccion.Text = ds.Tables[0].Rows[0]["DIRECCION"].ToString();
                    nombre.Controls.Add(new LiteralControl(txt_apellido_paterno.Text + " " + txt_apellido_materno.Text + " " + txt_primer_nombre.Text + " " + txt_segundo_nombre.Text + " <small>" + ds.Tables[0].Rows[0]["DESCRIPCION_ROL"].ToString() + "</small>"));
                    if (ds.Tables[0].Rows[0]["IMAGEN"].ToString() != string.Empty)
                    {
                        HiddenImagen.Value = ds.Tables[0].Rows[0]["IMAGEN"].ToString();
                    }
                    else
                    {
                        HiddenImagen.Value = "assets/images/usuario.png";
                    }

                }
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('" + ex.ToString() + "')", true);
            }
        }

        protected void bnt_guardar_Click(object sender, EventArgs e)
        {

            try
            {
                string sExt = string.Empty;
                string sName = string.Empty;
                string carpetaAdjuntos = string.Empty;
                string rutaAdjunto = string.Empty;

                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand(((util)HttpContext.Current.Session["util"]).ROL_USUARIO);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "AC");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_USUARIO", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_PATERNO", DbType.String, txt_apellido_paterno.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_MATERNO", DbType.String, txt_apellido_materno.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@PRIMER_NOMBRE", DbType.String, txt_primer_nombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@SEGUNDO_NOMBRE", DbType.String, txt_segundo_nombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DIRECCION", DbType.String, txt_direccion.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CEL", DbType.String, txt_celular.Text);

                if (fil_Imagen.HasFile)
                {

                    sName = fil_Imagen.FileName;
                    sExt = Path.GetExtension(sName);
                    DirectoryInfo fol = new DirectoryInfo(Server.MapPath("./assets/images/users"));
                    carpetaAdjuntos = Path.Combine(fol.ToString(), ID_USUARIO.Value + sExt);
                    fil_Imagen.SaveAs(carpetaAdjuntos);

                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@IMG", DbType.String, "./assets/images/users/" + ID_USUARIO.Value + sExt);
                }
                else
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@IMG", DbType.String, HiddenImagen.Value);
                }
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CORREO", DbType.String, txt_correo.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_PERFIL_USUARIO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_USUARIO", ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString()));


                CargarDatosPerfil();
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('" + ex.ToString() + "')", true);
            }
        }

        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        protected void txt_claveActual_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bt_actualizarClave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "VAP");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_USUARIO", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CLAVE_USUARIO", DbType.String, txt_claveActual.Text);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataSet ds2 = new DataSet();
                DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "ACP");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_USUARIO", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@CLAVE_USUARIO", DbType.String, txt_claveNueva.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION_CLAVE, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_PERFIL_USUARIO), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_USUARIO", ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString()));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Su clave a sido actualizada correctamente')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('La clave ingresada es incorrecta')", true);
                txt_claveActual.Text = "";
            }

        }
    }
}