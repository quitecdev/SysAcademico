using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Text;
using System.Security.Cryptography;

namespace SysAcademico
{
    public class util
    {

        //ESTADO SESION
        public string AUD_SESSION_INICIO = "INICIO_SESION";
        public string AUD_SESSION_FINALIZO = "FINALIZO_SESION";
        //ACCION
        public string AUD_ACCION_ACTUALIZACION = "ACTUALIZACION";
        public string AUD_ACCION_ACTUALIZACION_CLAVE = "ACTUALIZACION_CLAVE";
        public string AUD_ACCION_INSERCION = "INSERCION";
        public string AUD_ACCION_ELIMINACION = "ELIMINACION";
        public string AUD_ACCION_IMPRESION = "IMPRESION";
        public string AUD_ACCION_NUEVO = "NUEVO";
        public string AUD_ACCION_BUSCAR = "BUSCAR";
        public string AUD_ACCION_ENVIAR_CORREO = "ENVIAR_CORREO";
        //ACCION FORMULARIO
        public string AUD_ACCION_ABRIR = "ABRIR_FORMULARIO";
        public string AUD_ACCION_CERRAR = "CERRAR_FORMULARIO";
        //FORMULARIOS
        public string AUD_FORMULARIO_ADMIN_CARRERA = "ADMIN_CARRERAS";
        public string AUD_FORMULARIO_ADMIN_CRONOGRAMA = "ADMIN_CRONOGRAMA";
        public string AUD_FORMULARIO_ADMIN_CRONOGRAMA_DETALLE = "ADMIN_CRONOGRAMA_DETALLE";
        public string AUD_FORMULARIO_ADMIN_DOCENTE_MATERIA = "ADMIN_DOCENTE_MATERIA";
        public string AUD_FORMULARIO_ADMIN_DOCENTE_NOTAS = "ADMIN_DOCENTE_NOTAS";
        public string AUD_FORMULARIO_ADMIN_DOCENTE = "ADMIN_DOCENTE";
        public string AUD_FORMULARIO_PRINCIPAL = "PRINCIPAL";
        public string AUD_FORMULARIO_ADMIN_HORARIO = "ADMIN_HORARIO";
        public string AUD_FORMULARIO_ADMIN_HORARIO_MATERIA = "ADMIN_HORARIO_MATERIA";
        public string AUD_FORMULARIO_ADMIN_INTERVALOS= "ADMIN_INTERVALOS";
        public string AUD_FORMULARIO_ADMIN_INTERVALOS_DETALLE = "ADMIN_INTERVALOS_DETALLE";
        public string AUD_FORMULARIO_ADMIN_MATERIA_PARALELO = "ADMIN_MATERIA_PARALELO";
        public string AUD_FORMULARIO_ADMIN_MATERIA = "ADMIN_MATERIA";
        public string AUD_FORMULARIO_ADMIN_NOTAS = "ADMIN_NOTAS";
        public string AUD_FORMULARIO_ADMIN_NOTAS_DETALLE = "ADMIN_NOTAS_DETALLE";
        public string AUD_FORMULARIO_ADMIN_NOTAS_PONDERACION = "ADMIN_NOTAS_PONDERACION";
        public string AUD_FORMULARIO_ADMIN_PARALELO = "ADMIN_PARALELO";
        public string AUD_IFRAME_BUSCAR_INSCRIPCION = "IFRAME_BUSCAR_INSCRIPCION";
        public string AUD_INSCRIPCION = "INSCRIPCION";
        public string AUD_CRONOGRAMA = "CRONOGRAMA";
        public string AUD_FORMULARIO_HORARIO_ESTUDIANTE = "HORARIO_ESTUDIANTE";
        public string AUD_FORMULARIO_HORARIO_DOCENTE = "HORARIO_DOCENTE";
        public string AUD_FORMULARIO_USUARIOS = "ADMIN_USUARIOS";
        public string AUD_IFRAME_SUBIR_CONTENIDO= "IFRAME_SUBIR_CONTENIDO";
        public string AUD_IFRAME_NOTIFICACION = "IFRAME_NOTIFICACION";
        public string AUD_IFRAME_CAMBIAR_CLAVE = "IFRAME_CAMBIAR_CLAVE";
        public string AUD_IFRAME_ENVIAR_CLAVE = "IFRAME_CAMBIAR_CLAVE";
        public string AUD_IFRAME_PERFIL_USUARIO = "IFRAME_PERFIL_USUARIO";
        public string AUD_INGRESO = "INGRESO";
        public string AUD_FORMULARIO_LIBRETA_DOCENTE = "LIBRETA_DOCENTE";
        public string AUD_FORMULARIO_NOTA_ESTUDIANTE = "NOTA_ESTUDIANTE";
        public string AUD_FORMULARIO_REPOSITORIO_ESTUDIANTE = "REPOSITORIO_ESTUDIANTE";
        public string AUD_FORMULARIO_PREGUNTAS_FRECUENTES = "PREGUNTAS_FRECUENTES";
        public string AUD_FORMULARIO_REPORTE_INSCRIPCIONES = "REPORTE_INSCRIPCIONES";

        private TRACKAuditoria.reg reg_;
        private Usuario usuario_;
        public string ROL_USUARIO;

        public Microsoft.Practices.EnterpriseLibrary.Data.Database ConexionSegura
        {

            get
            {
                Microsoft.Practices.EnterpriseLibrary.Data.Database bd = DatabaseFactory.CreateDatabase("CAS_Data");
                return DatabaseFactory.CreateDatabase("CAS_Data");
            }
        }

        public string ObtenerTag(string tag, string valor)
        {
            return "#!" + tag + ":" + valor + "!#";
        }

        public string RegistrarError(Exception ex)
        {
            TrackError.reg regerror = new TrackError.reg();
            string outMensaje = null;
            regerror.RegistrarError(ex, ref outMensaje);
            return outMensaje;
        }

        public void MessageBox(string mensaje)
        {
            if (mensaje == null)
            {
                MessageBox("NULL");
                return;
            }
            string script = "<script type='text/javascript'>alert('" + mensaje + "');</script>";

            Page page = HttpContext.Current.CurrentHandler as Page;

            if (page != null)
            {
                if ((!page.ClientScript.IsClientScriptBlockRegistered("alert")))
                {
                    page.ClientScript.RegisterClientScriptBlock(mensaje.GetType(), "alert", script);
                }
            }
        }

        public TRACKAuditoria.reg audit()
        {
            if (reg_ == null)
            {
                reg_ = new TRACKAuditoria.reg();
            }
            return reg_;
        }

        public Usuario ValidarUsuario(string codigo, string clave, ref string resultado)
        {
            try
            {
                Usuario usuarioActual = new Usuario();

                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@COD_USUARIO", DbType.String, codigo);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CLAVE_USUARIO", DbType.String, clave);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "VA");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@outID", DbType.Int32, 10);

                DataSet ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                string outMensaje = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outMensaje").ToString();

                if (outMensaje.IndexOf("ERROR") != -1)
                {
                    resultado = outMensaje;
                    return null;
                }

                if (ds == null)
                {
                    resultado = outMensaje;
                    resultado = null;
                }
                else
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            usuarioActual.Datos = ds;

                            string ID_USUARIO = ds.Tables[0].Rows[0]["ID_USUARIO"].ToString();

                            //OBTENER MENU POR ROL DE USUARIO
                            DbCommand cmdRolMenus = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUsuarios");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdRolMenus, "@ID_USUARIO", DbType.String, ID_USUARIO);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdRolMenus, "@OPERACION", DbType.String, "OBM");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdRolMenus, "@outMensaje", DbType.String, 200);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdRolMenus, "@outID", DbType.Int32, 10);
                            DataSet ds1 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmdRolMenus);
                            string outMensaje1 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmdRolMenus, "@outMensaje").ToString();
                            usuarioActual.Menu_Inicio.Load(((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteReader(cmdRolMenus), LoadOption.OverwriteChanges, "RolMenus");
                            ROL_USUARIO = ds1.Tables[0].Rows[0]["DIRECTIVA_ROL"].ToString();
                            usuario = usuarioActual;
                            resultado = outMensaje;
                        }
                        else
                        {
                            resultado = outMensaje;
                            resultado = null;
                        }
                    }
                    else
                    {
                        resultado = outMensaje;
                        resultado = null;
                    }
                }
                return usuarioActual;
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
                return null;
            }
        }

        public Usuario usuario
        {
            get
            {
                if (usuario_ == null)
                {
                    return usuario_;
                }
                else
                {
                    return (Usuario)HttpContext.Current.Session["USUARIO"];
                }
            }
            set
            {
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Session["USUARIO"] = value;
                HttpContext.Current.Application.UnLock();
                usuario_ = value;

            }
        }
    }
}