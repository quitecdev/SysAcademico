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
    public partial class RepositorioEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_REPOSITORIO_ESTUDIANTE));
                CargarRepositorio();
            }
        }

        public void CargarRepositorio()
        {

            DataSet ds4 = new DataSet();
            DbCommand cmd4 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd4, "@OPERACION", DbType.String, "OBSC");
            //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd4, "@ID_ESTUDIANTE", DbType.String, "0802788778");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd4, "@ID_ESTUDIANTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd4, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd4, "@outID", DbType.Int32, 10);
            ds4 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd4);

            int contador = 0;
            foreach (DataTable table4 in ds4.Tables)
            {
                foreach (DataRow item2 in table4.Rows)
                {
                    string acordion = "";
                    DataSet ds = new DataSet();
                    DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBSM");
                    //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE", DbType.String, "0802788778");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, item2["ID_CARRERA"].ToString());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                    int inicio = 0;

                    foreach (DataTable table in ds.Tables)
                    {

                        foreach (DataRow item in table.Rows)
                        {
                            DataSet ds2 = new DataSet();
                            DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBCA");
                            //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_ESTUDIANTE", DbType.String, "0802788778");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_ESTUDIANTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@SEMANA_CRONOGRAMA", DbType.String, item["SEMANA_CRONOGRAMA"].ToString());
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, item2["ID_CARRERA"].ToString());
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CRONOGRAMA", DbType.String, item["ID_CRONOGRAMA"].ToString());
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                            ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                            string contenido = "";

                            foreach (DataRow theRow in ds2.Tables[0].Rows)
                            {
                                DataSet ds3 = new DataSet();
                                DbCommand cmd3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCronogramaAdjunto");
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@OPERACION", DbType.String, "OBSDA");
                                //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_ESTUDIANTE", DbType.String, "0802788778");
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_ESTUDIANTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@SEMANA_CRONOGRAMA", DbType.String, item["SEMANA_CRONOGRAMA"].ToString());
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_CARPETA", DbType.String, theRow["ID_CARPETA"].ToString());
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_CARRERA", DbType.String, item2["ID_CARRERA"].ToString());
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_CRONOGRAMA", DbType.String, item["ID_CRONOGRAMA"].ToString());
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outMensaje", DbType.String, 200);
                                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outID", DbType.Int32, 10);
                                ds3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd3);
                                string adjuntos = "";
                                foreach (DataRow theRow2 in ds3.Tables[0].Rows)
                                {
                                    adjuntos = adjuntos + "<li class='list-group-item'> <a href='" + theRow2["RUTA_ADJUNTO"].ToString() + "' class='user-list-item' target='_blank'> <div class='avatar text-center'> <i class='" + theRow2["ICONO_ADJUNTO"].ToString() + " text-custom'></i> </div> <div class='user-desc'> <span class='name'>" + theRow2["NOMBRE_ADJUNTO"].ToString() + "</span> <span class='desc'>" + theRow2["PESO_ADJUNTO"].ToString() + "</span> </div> </a> </li>";
                                }
                                contenido = contenido + "<div class='panel-headin'g> <h4 class='panel-title'> <a data-toggle='collapse' href='#collapse" + contador + "'><i class='indicator fa fa-caret-right' aria-hidden='true'></i> " + theRow["DESCRIPCION_CARPETA"].ToString() + "</a> </h4> </div> <div id='collapse" + contador + "' class='panel-collapse collapse'> <ul class='list-group m-b-0 user-list'>" + adjuntos + "</ul> </div>";

                                //Console.WriteLine(theRow["ID"] + "\t" + theRow["FirstName"]);
                                contador++;
                            }

                            if (inicio == 0)
                            {
                                acordion= acordion +"<div class='panel panel-default bx-shadow-none'> <div class='panel-heading' role='tab' id='heading" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "'> <h4 class='panel-title'> <a role='button' data-toggle='collapse' data-parent='#accordion' href='#" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "' aria-expanded='true' aria-controls='" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "'> " + item["DESCRIPCION_SEMANA"].ToString() + " - " + item["TEMA"].ToString() + " </a> </h4> </div> <div id='" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "' class='panel-collapse collapse in' role='tabpanel' aria-labelledby='heading" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "'> <div class='panel-body'>" + contenido + " </div> </div> </div>";
                            }
                            else
                            {
                                acordion= acordion+"<div class='panel panel-default bx-shadow-none'> <div class='panel-heading' role='tab' id='heading" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "'> <h4 class='panel-title'> <a class='collapsed' role='button' data-toggle='collapse' data-parent='#accordion_"+ item2["ID_CARRERA"].ToString() + "' href='#" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "' aria-expanded='flase' aria-controls='" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "'> " + item["DESCRIPCION_SEMANA"].ToString() + " - " + item["TEMA"].ToString() + " </a> </h4> </div> <div id='" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "' class='panel-collapse collapse' role='tabpanel' aria-labelledby='heading" + item2["ID_CARRERA"].ToString()+ item["SEMANA_CRONOGRAMA"].ToString() + "'> <div class='panel-body'>" + contenido + "</tbody> </table>  </div> </div> </div>";
                            }

                            inicio++;
                        }
                    }

                    div_nota.Controls.Add(new LiteralControl("<div class='col-lg-12'> <br /> <h3>"+item2["DESCRIPCION_CARRERA"].ToString()+"</h3> <div class='panel-group' id='accordion_"+ item2["ID_CARRERA"].ToString() + "' role='tablist' runat='server' aria-multiselectable='true'>"+ acordion + " </div> </div>"));
                }                
            }

        }
    }
}