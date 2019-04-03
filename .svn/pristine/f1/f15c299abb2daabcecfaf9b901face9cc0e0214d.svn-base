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
    public partial class iframeBuscarInscripciones : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_BUSCAR_INSCRIPCION));
                CargarInscripciones();
                CargarProvincia();
                CargarCiudad();
            }
        }

        public void CargarInscripciones()
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
            GridInscripcion.DataSource = ds;
            GridInscripcion.DataBind();
        }

        protected void GridInscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles.Limpiar(this.Controls);

            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(Page), "vi", "$('#modalEstado').modal('show');", true);
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBES");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, GridInscripcion.SelectedRow.Cells[1].Text);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
            ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

            nombre.Controls.Add(new LiteralControl(ds.Tables[0].Rows[0]["NOMBRE"].ToString() + " <small>" + ds.Tables[0].Rows[0]["ID_INSCRIP"].ToString() + "</small>"));
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string DOC_IDENTIDAD = Convert.ToString(row["DOC_IDENTIDAD"]);
                if (DOC_IDENTIDAD == "True")
                {
                    ckb_docIdent.Checked = true;
                    ckb_docIdent.Enabled = false;
                }
                else
                {
                    ckb_docIdent.Checked = false;
                    ckb_docIdent.Enabled = true;
                }

                string PAPELETA_VOT = Convert.ToString(row["PAPELETA_VOT"]);
                if (PAPELETA_VOT == "True")
                {
                    ckb_papeleta.Checked = true;
                    ckb_papeleta.Enabled = false;
                }
                else
                {
                    ckb_papeleta.Checked = false;
                    ckb_papeleta.Enabled = true;
                }

                string FOTOGRAFIA = Convert.ToString(row["FOTOGRAFIA"]);
                if (FOTOGRAFIA == "True")
                {
                    ckb_foto.Checked = true;
                    ckb_foto.Enabled = false;
                }
                else
                {
                    ckb_foto.Checked = false;
                    ckb_foto.Enabled = true;
                }

                string CERT_MEDICO = Convert.ToString(row["CERT_MEDICO"]);
                if (CERT_MEDICO == "True")
                {
                    ckb_certf.Checked = true;
                    ckb_certf.Enabled = false;
                }
                else
                {
                    ckb_certf.Checked = false;
                    ckb_certf.Enabled = true;
                }

                string FACTURA = Convert.ToString(row["NUMERO_FACTURA"]);
                string PAGO = Convert.ToString(row["PAGO"]);
                if (PAGO == "True")
                {
                    ckb_pago.Checked = true;
                    ckb_pago.Enabled = false;
                    if (FACTURA != string.Empty)
                    {
                        txt_factura.Enabled = false;
                        txt_factura.Text = FACTURA;
                    }
                    else
                    {
                        txt_factura.Enabled = true;
                    }
                }


            }

        }

        protected void GridInscripcion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = GridInscripcion.DataKeys[e.Row.RowIndex]["ID_INSCRIPCION_ESTADO"].ToString();
                string factura = GridInscripcion.DataKeys[e.Row.RowIndex]["NUMERO_FACTURA"].ToString();
                string url = GridInscripcion.DataKeys[e.Row.RowIndex]["URL"].ToString();

                var ModificarRegistro = e.Row.FindControl("Seleccionar") as LinkButton;
                var ElimnarRegistro = e.Row.FindControl("lb_estado") as Label;

                var VerArchivo = e.Row.FindControl("lnk_documento") as LinkButton;

                if (estado == "1")
                {
                    if (factura != string.Empty)
                    {
                        ModificarRegistro.Visible = false;
                        ElimnarRegistro.Attributes.Add("class", "label label-success");
                        VerArchivo.Visible = true;
                        VerArchivo.Attributes.Add("href", url);
                        VerArchivo.Attributes.Add("target", "_blank");
                    }
                    else
                    {
                        ModificarRegistro.Visible = true;
                        ElimnarRegistro.Attributes.Add("class", "label label-warning");
                        VerArchivo.Visible = false;
                    }
                }
                else if (estado == "2")
                {
                    ModificarRegistro.Visible = true;
                    ElimnarRegistro.Attributes.Add("class", "label label-primary");
                    VerArchivo.Visible = true;
                    VerArchivo.Attributes.Add("href", url);
                    VerArchivo.Attributes.Add("target", "_blank");
                }
                else if (estado == "3")
                {
                    ModificarRegistro.Visible = true;
                    ElimnarRegistro.Attributes.Add("class", "label label-warning");
                    VerArchivo.Visible = false;
                }
                else if (estado == "4")
                {
                    ModificarRegistro.Visible = true;
                    ElimnarRegistro.Attributes.Add("class", "label label-danger");
                    VerArchivo.Visible = false;
                }
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int contValidacion = 0;
                bool imprimir = false;

                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "ACE");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, GridInscripcion.SelectedRow.Cells[1].Text);
                if (ckb_docIdent.Checked == true)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DOC_IDENTIDAD", DbType.Int32, 1);
                    contValidacion++;
                }
                if (ckb_foto.Checked == true)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FOTOGRAFIA", DbType.Int32, 1);
                    contValidacion++;
                }
                if (ckb_papeleta.Checked == true)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@PAPELETA_VOT", DbType.Int32, 1);
                    contValidacion++;
                }
                if (ckb_certf.Checked == true)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CERT_MEDICO", DbType.Int32, 1);
                    contValidacion++;
                }

                if (ckb_pago.Checked == true)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@PAGO", DbType.Int32, 1);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@NUMERO_FACTURA", DbType.String, txt_factura.Text);
                    contValidacion = contValidacion + 5;
                }

                /*ESTADO */
                if (contValidacion == 9)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTATUS", DbType.Int32, 1);
                    imprimir = true;
                }
                else if (contValidacion >= 5)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTATUS", DbType.Int32, 2);
                    imprimir = true;
                }
                else if (contValidacion <= 4)
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTATUS", DbType.Int32, 3);
                }
                else
                {
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTATUS", DbType.Int32, 4);
                }

                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                int outID = Convert.ToInt32(((util)HttpContext.Current.Session["util"]).ConexionSegura.GetParameterValue(cmd, "@outID"));
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ACTUALIZACION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_BUSCAR_INSCRIPCION), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INSCRIP", GridInscripcion.SelectedRow.Cells[1].Text));
                if (imprimir == true)
                {
                    Imprimir(GridInscripcion.SelectedRow.Cells[1].Text);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(Page), "vi", "alert('Se ha completado exitosamente la inscripción. Para completar la matrícula presente todo los documentos y/o pago de la matrícula')", true);
                }
                CargarInscripciones();

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        Document document = null;
        PdfWriter pdfw = null;
        MemoryStream msResultado = new MemoryStream();
        Pdf_Eventos ev = new Pdf_Eventos();

        public void Imprimir(string ID_INSCRIP)
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
                Font fontNormalHorarioCabecera = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD, new Color(255, 255, 255));

                /*DOCUMENTO INICIAL*/
                PathOut = ID_INSCRIP + ".pdf";// "SalidaPDF.pdf";
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
                DataSet dsDatosPersonales = new DataSet();
                DbCommand cmdDatosPersonales = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdDatosPersonales, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdDatosPersonales, "@ID_INSCRIP", DbType.String, ID_INSCRIP);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdDatosPersonales, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdDatosPersonales, "@outID", DbType.Int32, 10);
                dsDatosPersonales = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmdDatosPersonales);

                PdfPTable tableDatosPersonales = new PdfPTable(2);
                float[] anchoColumnastblTotal = { 270, 800 };
                tableDatosPersonales.WidthPercentage = 100;
                tableDatosPersonales.SetTotalWidth(anchoColumnastblTotal);
                tableDatosPersonales.DefaultCell.Border = PdfTable.NO_BORDER;
                tableDatosPersonales.HorizontalAlignment = Element.ALIGN_RIGHT;

                tableDatosPersonales.AddCell((new Phrase("Nº Factura:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["NUMERO_FACTURA"].ToString(), fontNormal))); ;

                tableDatosPersonales.AddCell((new Phrase("Nº Docuemento de identidad:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["ID_INSCRIP"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Nombre:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["NOMBRE"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Fecha Nacimiento:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["FECHA_NACIMIENTO_INSCRIP"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Estado Civil:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["DESCRIPCION_ESTADO_CIVIL"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Correo Electrónico:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["CORREO"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Teléfono Fijo:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["TELEF_INSCRIP"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Celular:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["CEL_INSCRIP"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Teléfono de Emergencia:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["TELEF_EMER_INSCRIP"].ToString(), fontNormal)));

                tableDatosPersonales.AddCell((new Phrase("Dirección:", font_Cabeceras)));
                tableDatosPersonales.AddCell((new Phrase(dsDatosPersonales.Tables[0].Rows[0]["DIRECCION"].ToString(), fontNormal)));

                document.Add(tableDatosPersonales);
                document.Add(separador);
                document.Add(separador);

                Paragraph DatosCarrera = new Paragraph(new Chunk("DATOS CARRERA", FontFactory.GetFont(FontFactory.HELVETICA, 15, iTextSharp.text.Font.BOLD)));
                DatosCarrera.Alignment = Element.ALIGN_LEFT;
                document.Add(DatosCarrera);
                document.Add(separador);
                document.Add(separador);

                ////DATOS CARRERA
                DataSet dsCarrera = new DataSet();
                DbCommand cmdCarrear = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdCarrear, "@OPERACION", DbType.String, "OBDMI");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdCarrear, "@ID_INSCRIP", DbType.String, ID_INSCRIP);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdCarrear, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdCarrear, "@outID", DbType.Int32, 10);
                dsCarrera = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmdCarrear);

                //CREAMOS EL GRIDVIEW
                GridView GridCarrera = new GridView();
                GridCarrera.AllowPaging = false;
                GridCarrera.DataSource = dsCarrera;
                GridCarrera.DataBind();

                PdfPTable tableDetalleCarrera = new PdfPTable(1);
                tableDetalleCarrera.WidthPercentage = 40;
                tableDetalleCarrera.HorizontalAlignment = Element.ALIGN_LEFT;

                float[] anchoColumnastblDetalleCarrera = { 350 };
                tableDetalleCarrera.SetTotalWidth(anchoColumnastblDetalleCarrera);
                tableDetalleCarrera.DefaultCell.Border = PdfTable.NO_BORDER;
                if (GridCarrera.HeaderRow != null)
                {
                    for (int x = 0; x < dsCarrera.Tables[0].Columns.Count; x++)
                    {
                        string cellText = Server.HtmlDecode(GridCarrera.HeaderRow.Cells[x].Text);
                        PdfPCell cell = new PdfPCell(new Paragraph(cellText, font_Cabeceras));
                        cell.BackgroundColor = Color.LIGHT_GRAY;
                        tableDetalleCarrera.AddCell(cell);
                    }

                    int i = 0;
                    foreach (DataRow dr in dsCarrera.Tables[0].Rows)
                    {

                        for (int j = 0; j < dsCarrera.Tables[0].Columns.Count; j++)
                        {
                            string cellText = Server.HtmlDecode(dr.Table.Rows[i][j].ToString());
                            PdfPCell cell = new PdfPCell(new Paragraph(cellText, fontNormal));
                            tableDetalleCarrera.AddCell(cell);
                        }

                        i++;
                    }
                }
                document.Add(tableDetalleCarrera);
                document.Add(separador);
                document.Add(separador);

                ////DATOS MATERIA
                DataSet dsIntervalo = new DataSet();
                DbCommand cmdIntervalo = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcionDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdIntervalo, "@OPERACION", DbType.String, "OBD2");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmdIntervalo, "@ID_INSCRIP", DbType.String, ID_INSCRIP);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdIntervalo, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmdIntervalo, "@outID", DbType.Int32, 10);
                dsIntervalo = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmdIntervalo);

                dsIntervalo.Tables[0].Columns.Remove(dsIntervalo.Tables[0].Columns[0]);

                dsIntervalo.Tables[0].Columns[0].ColumnName = "MATERIA";
                dsIntervalo.Tables[0].Columns[1].ColumnName = "PARALELO";
                dsIntervalo.Tables[0].Columns[2].ColumnName = "DIA";
                dsIntervalo.Tables[0].Columns[3].ColumnName = "HORA";

                //CREAMOS EL GRIDVIEW
                GridView GridDetalle = new GridView();
                GridDetalle.AllowPaging = false;
                GridDetalle.DataSource = dsIntervalo;
                GridDetalle.DataBind();

                PdfPTable tableDetalle = new PdfPTable(4);
                tableDetalle.WidthPercentage = 100;


                float[] anchoColumnastblDetalle = { 750, 250, 300, 350 };
                tableDetalle.SetTotalWidth(anchoColumnastblDetalle);
                tableDetalle.DefaultCell.Border = PdfTable.NO_BORDER;
                if (GridDetalle.HeaderRow != null)
                {
                    for (int x = 0; x < dsIntervalo.Tables[0].Columns.Count; x++)
                    {
                        string cellText = Server.HtmlDecode(GridDetalle.HeaderRow.Cells[x].Text);
                        PdfPCell cell = new PdfPCell(new Paragraph(cellText, font_Cabeceras));
                        cell.BackgroundColor = Color.LIGHT_GRAY;
                        tableDetalle.AddCell(cell);
                    }

                    int i = 0;
                    foreach (DataRow dr in dsIntervalo.Tables[0].Rows)
                    {

                        for (int j = 0; j < dsIntervalo.Tables[0].Columns.Count; j++)
                        {
                            string cellText = Server.HtmlDecode(dr.Table.Rows[i][j].ToString());
                            PdfPCell cell = new PdfPCell(new Paragraph(cellText, fontNormal));
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
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(Page), "vi", "PdfInscripcion('" + Src + "')", true);
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_IMPRESION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_IFRAME_BUSCAR_INSCRIPCION), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ARCHIVO", Src));
            }
        }

        protected void ckb_pago_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_pago.Checked == true)
            {
                txt_factura.Enabled = true;
            }
            else
            {
                txt_factura.Enabled = false;
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
                    cmb_ciudad.SelectedValue = ds.Tables[0].Rows[0]["UBI_ID"].ToString();
                    txt_direccion.Text = ds.Tables[0].Rows[0]["DIRECCION2"].ToString();
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(Page), "vi", "$('#modalEditar').modal('show');", true);

                }
            }
            catch (Exception)
            {
                
                throw;
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

        public void CargarCiudad()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminUbicacion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
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

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminInscripcion");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "ACD");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INSCRIP", DbType.String, txt_DI.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_PATERNO_INSCRIP", DbType.String, txt_apellido_paterno.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@APELLIDO_MATERNO_INSCRIP", DbType.String, txt_apellido_materno.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@PRIMER_NOMBRE_INSCRIP", DbType.String, txt_primer_nombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@SEGUNDO_NOMBRE_INSCRIP", DbType.String, txt_segundo_nombre.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CORREO", DbType.String, txt_correo.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FECHA_NACIMIENTO_INSCRIP", DbType.String, Convert.ToDateTime(txt_fecha_nacimiento.Text));
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTADO_CIVIL", DbType.Int32, Convert.ToInt32(cmb_estado_civil.SelectedValue));
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PROVINCIA", DbType.Int32, Convert.ToInt32("1"));
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CIUDAD", DbType.Int32, Convert.ToInt32(cmb_ciudad.SelectedValue));
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@DIRECCION", DbType.String, txt_direccion.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@TELEF_INSCRIP", DbType.String, txt_telf.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@CEL_INSCRIP", DbType.String, txt_celular.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@TELEF_EMER_INSCRIP", DbType.String, txt_emergencia.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_INSERCION, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO", ((util)HttpContext.Current.Session["util"]).AUD_INSCRIPCION), ((util)HttpContext.Current.Session["util"]).audit().CrearTag("ID_INSCRIP", txt_DI.Text));
                Imprimir(txt_DI.Text);
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(Page), "vi", "alert('Se ha actualizado correctamente este registro')", true);
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }


    }
}