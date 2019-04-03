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
    public partial class NotaEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
            ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_NOTA_ESTUDIANTE));
        }

        public void Cargar()
        {

            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminEstudianteNota");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBC");
            //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE", DbType.String, "0912818440");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            //CARRERA
            int contador = 0;
            string contenido = "";
            foreach (DataTable table in ds.Tables)
            {           
                foreach (DataRow item in table.Rows)
                {
                    
                    DataSet ds2 = new DataSet();
                    DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminEstudianteNota");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OBN");
                    //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_ESTUDIANTE", DbType.String, "0912818440");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_ESTUDIANTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@ID_CARRERA", DbType.String, item["ID_CARRERA"].ToString());
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                    ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);

                    //NOTAS
                    string collapse = "";
                    decimal nota_final=0;
                    foreach (DataTable table2 in ds2.Tables)
                    {
                        foreach (DataRow dr in table2.Rows)
                        {

                            DataSet ds3 = new DataSet();
                            DbCommand cmd3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminEstudianteNota");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@OPERACION", DbType.String, "OBND");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_NOTA_DETALLE", DbType.String, dr["ID_NOTA_DETALLE"].ToString());
                            //((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_ESTUDIANTE", DbType.String, "0912818440");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd3, "@ID_ESTUDIANTE", DbType.String, ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outMensaje", DbType.String, 200);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd3, "@outID", DbType.Int32, 10);
                            ds3 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd3);
                            var tabla = ConvertDataTableToHTML(ds3.Tables[0]);
                            collapse = collapse + "<tr data-toggle='collapse' data-target='#accordion" + contador + "' class='clickable'> <td>" + dr["ID_NOTA_DETALLE"].ToString() + "</td> <td>" + dr["DESCRIPCION_NOTA_DETALLE"].ToString() + "</td> <td>" + dr["PORCENTAJE"].ToString()+"%" + "</td> <td>" + dr["PROMEDIO"].ToString() + "</td> <td>" + dr["NOTA"].ToString() + "</td> </tr> <tr> <td colspan='5'> <div id='accordion" + contador + "' class='collapse'> "+tabla+"  </div> </td> </tr> ";
                            contador++;
                            nota_final = Convert.ToDecimal(dr["NOTA"].ToString())+ nota_final;
                        }
                        collapse = collapse + "<tr class='table-footer' style='background: #8b1716!important;'> <td></td> <td></td> <td></td> <td><strong>NOTA FINAL</strong></td> <td><strong>"+nota_final+"</strong></td> </tr>";
                    }

                    div_nota.Controls.Add(new LiteralControl("<h3 class=' m-b-15'>" + item["DESCRIPCION_CARRERA"].ToString() + "</h3><table class='table table-collapse table-striped m-0'> <thead class='table-collapse-thead'> <th>#</th> <th>DETALLE</th> <th>PORCENTAJE</th> <th>PROMEDIO</th> <th>NOTA</th> </thead>  <tbody class='table-collapse-tbody'> "+ collapse + " </tbody> </table> "));

                }

            }



        }


        public static string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table class='table m-0'>";
            //add header row
            html += "<thead>";
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<th>" + dt.Columns[i].ColumnName + "</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }

    }
}