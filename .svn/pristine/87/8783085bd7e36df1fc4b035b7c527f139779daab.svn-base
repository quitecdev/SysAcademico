using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class ReporteCronograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnReport);
            if (!IsPostBack)
            {
                CargarCronograma();
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(
                                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(),
                                                                        ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(),
                                                                        Session.SessionID,
                                                                        ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR,
                                                                        ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_ADMIN_CRONOGRAMA));
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

        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenerarPdf();
        }

        public void GenerarPdf()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.ReporteCronograma");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CRONOGRAMA", DbType.String, cmb_cronograma.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);


                Document document = new Document(PageSize.A4, 20f, 20f, 10f, 10f);

                /*FONT*/
                Font font_Cabeceras = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD);
                Font font_Cabeceras2 = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(255, 255, 255));
                Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
                Font fontNormalHorario = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL);
                Font fontNormalHorarioCabecera = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD);

                /*SEPARADOR*/
                float[] anchoColumna = { 30 };
                PdfPTable separador = new PdfPTable(1);
                separador.SetTotalWidth(anchoColumna);
                separador.DefaultCell.Border = PdfTable.NO_BORDER;
                separador.DefaultCell.FixedHeight = 10;
                separador.AddCell(new Phrase("", fontNormal));

                /*CELDA VACIA*/
                PdfPCell cellVacia = new PdfPCell(new Paragraph(" ", fontNormalHorarioCabecera));
                cellVacia.Border = PdfCell.NO_BORDER;

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    Color color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    //Company Logo
                    cell = ImageCell("~/assets/images/CAS-logo.png", 80f, PdfPCell.ALIGN_LEFT);
                    table.AddCell(cell);

                    //Datos Cabecera
                    phrase = new Phrase();
                    phrase.Add(new Chunk(ds.Tables[0].Rows[0]["DESCRIPCION_CARRERA"].ToString() + "\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.BLACK)));
                    phrase.Add(new Chunk("Periodo: " + ds.Tables[0].Rows[0]["DESCRIPCION_PERIODO"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Sede: " + ds.Tables[0].Rows[0]["DESCRIPCION_UNIVERSIDAD"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Modalidad: " + ds.Tables[0].Rows[0]["DESCRIPCION_TIPO_INVERTALO"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Paralelo: " + ds.Tables[0].Rows[0]["DESCRIPCION_PARALELO"].ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new Color(System.Drawing.ColorTranslator.FromHtml("#8b1716"));
                    DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                    DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                    document.Add(table);

                    //table = new PdfPTable(2);
                    //table.HorizontalAlignment = Element.ALIGN_LEFT;
                    //table.SetWidths(new float[] { 0.3f, 1f });
                    //table.SpacingBefore = 20f;
                    document.Add(separador);
                    document.Add(separador);

                    DataSet dss = new DataSet();
                    cmd.Parameters.Clear();
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBS");
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CRONOGRAMA", DbType.String, cmb_cronograma.SelectedValue);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                    dss = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                    foreach (DataTable table4 in dss.Tables)
                    {
                        foreach (DataRow item2 in table4.Rows)
                        {

                            DataSet dsD = new DataSet();
                            cmd.Parameters.Clear();
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBD");
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CRONOGRAMA", DbType.String, cmb_cronograma.SelectedValue);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@SEMANA_CRONOGRAMA", DbType.String, item2["ID_SEMANA"].ToString());
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                            dsD = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                            PdfPTable tableDetalle = new PdfPTable(5);
                            tableDetalle.WidthPercentage = 100;
                            float[] anchoColumnastblDetalle = { 100, 75, 80, 300, 250 };
                            tableDetalle.SetTotalWidth(anchoColumnastblDetalle);
                            tableDetalle.DefaultCell.Border = PdfTable.NO_BORDER;

                            //SEMANA
                            PdfPCell cellSemana = new PdfPCell(new Paragraph(item2["DESCRIPCION_SEMANA"].ToString(), fontNormalHorarioCabecera));
                            cellSemana.Colspan = 3;
                            cellSemana.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellSemana);
                            tableDetalle.AddCell(cellVacia);
                            tableDetalle.AddCell(cellVacia);

                            //CABECERA
                            tableDetalle.AddCell(new PdfPCell(new Paragraph("TEMA", fontNormalHorarioCabecera)));
                            tableDetalle.AddCell(new PdfPCell(new Paragraph("DÍA", fontNormalHorarioCabecera)));
                            tableDetalle.AddCell(new PdfPCell(new Paragraph("FECHA", fontNormalHorarioCabecera)));
                            tableDetalle.AddCell(new PdfPCell(new Paragraph("TEMÁTICA", fontNormalHorarioCabecera)));
                            tableDetalle.AddCell(new PdfPCell(new Paragraph("REQUERIMIENTO", fontNormalHorarioCabecera)));

                            //TEMA
                            PdfPCell cellTema = new PdfPCell(new Paragraph(dsD.Tables[0].Rows[0]["TEMA"].ToString(), fontNormalHorario));
                            cellTema.Rowspan = dsD.Tables[0].Rows.Count;
                            cellTema.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellTema);

                            foreach (DataTable tableD in dsD.Tables)
                            {
                                foreach (DataRow itemD in tableD.Rows)
                                {
                                    //DIA
                                    tableDetalle.AddCell(new PdfPCell(new Paragraph(itemD["DESCRIPCION_ABREVI"].ToString(), fontNormalHorario)));
                                    //FECHA
                                    tableDetalle.AddCell(new PdfPCell(new Paragraph(itemD["FECHA"].ToString(), fontNormalHorario)));
                                    //TEMATICA
                                    tableDetalle.AddCell(new PdfPCell(new Paragraph(itemD["TEMATICA"].ToString(), fontNormalHorario)));
                                    //REQUERIMIENTO
                                    tableDetalle.AddCell(new PdfPCell(new Paragraph(itemD["REQUERIMIENTO"].ToString(), fontNormalHorario)));
                                }
                            }
                            document.Add(tableDetalle);
                            document.Add(separador);
                        }
                    }
                    //Addtional Information
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + ds.Tables[0].Rows[0]["COD_SEDE"].ToString() + "_" + ds.Tables[0].Rows[0]["COD_CARRERA"].ToString() + "_" + ds.Tables[0].Rows[0]["DESCRIPCION_PARALELO"].ToString() + "_" + ds.Tables[0].Rows[0]["DESCRIPCION_TIPO_INVERTALO"].ToString() + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }


    }
}