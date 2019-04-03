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
    public partial class ReporteAsistenciaDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnReport);
            if (!IsPostBack)
            {
                ((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_REPORTE_INSCRIPCIONES));
                CargarSede();
                //CargarDocente();
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
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.ReporteAsistenciaDocente");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@FECHA_ASISTENCIA", DbType.String, txt_fecha.Text);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);


                Document document = new Document(PageSize.A4.Rotate(), 20f, 20f, 10f, 10f);

                /*FONT*/
                Font fontNormalHorario = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.NORMAL);
                Font fontNormalHorarioCabecera = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.BOLD);

                /*SEPARADOR*/
                float[] anchoColumna = { 30 };
                PdfPTable separador = new PdfPTable(1);
                separador.SetTotalWidth(anchoColumna);
                separador.DefaultCell.Border = PdfTable.NO_BORDER;
                separador.DefaultCell.FixedHeight = 10;
                separador.AddCell(new Phrase("", fontNormalHorario));

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
                    phrase.Add(new Chunk("REPORTE ASISTENCIA " + txt_fecha.Text + "\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.BLACK)));
                    phrase.Add(new Chunk("Periodo: " + ds.Tables[0].Rows[0]["DESCRIPCION_PERIODO"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Sede: " + ds.Tables[0].Rows[0]["DESCRIPCION_UNIVERSIDAD"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new Color(System.Drawing.ColorTranslator.FromHtml("#8b1716"));
                    DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                    DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                    document.Add(table);

                    document.Add(separador);
                    document.Add(separador);
                    document.Add(separador);
                    document.Add(separador);

                    PdfPTable tableDetalle = new PdfPTable(9);
                    tableDetalle.WidthPercentage = 100;
                    float[] anchoColumnastblDetalle = { 50, 175, 150, 150, 75, 250, 100, 150, 350 };
                    tableDetalle.SetTotalWidth(anchoColumnastblDetalle);
                    tableDetalle.DefaultCell.Border = PdfTable.NO_BORDER;

                    //SEDE
                    PdfPCell cellCabecera = new PdfPCell(new Paragraph("SEDE", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //CARRERA
                    cellCabecera = new PdfPCell(new Paragraph("CARRERA", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //MATERIA
                    cellCabecera = new PdfPCell(new Paragraph("MATERIA", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //HORARIO
                    cellCabecera = new PdfPCell(new Paragraph("HORARIO", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //#
                    cellCabecera = new PdfPCell(new Paragraph("#", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //NOMBRES
                    cellCabecera = new PdfPCell(new Paragraph("APELLIDOS Y NOMBRES", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //FECHA
                    cellCabecera = new PdfPCell(new Paragraph("FECHA", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //ESTADO
                    cellCabecera = new PdfPCell(new Paragraph("ESTADO", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);
                    //OBSERVACIONES
                    cellCabecera = new PdfPCell(new Paragraph("OBSERVACIONES", fontNormalHorarioCabecera));
                    cellCabecera.HorizontalAlignment = 1;
                    tableDetalle.AddCell(cellCabecera);

                    ds.Tables[0].Columns.Remove("DESCRIPCION_PERIODO");
                    foreach (DataTable table4 in ds.Tables)
                    {
                        foreach (DataRow item2 in table4.Rows)
                        {
                            //SEDE
                            cellCabecera = new PdfPCell(new Paragraph(item2["DESCRIPCION_UNIVERSIDAD"].ToString(), fontNormalHorario));
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //CARRERA
                            cellCabecera = new PdfPCell(new Paragraph(item2["DESCRIPCION_CARRERA"].ToString(), fontNormalHorario));
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //MATERIA
                            cellCabecera = new PdfPCell(new Paragraph(item2["DESCRIPCION_MATERIA"].ToString(), fontNormalHorario));
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //HORARIO
                            cellCabecera = new PdfPCell(new Paragraph(item2["HORIA"].ToString(), fontNormalHorario));
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //#
                            cellCabecera = new PdfPCell(new Paragraph(item2["ID_DOCENTE"].ToString(), fontNormalHorario));
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //NOMBRES
                            cellCabecera = new PdfPCell(new Paragraph(item2["NOMBRE"].ToString(), fontNormalHorario));
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //FECHA
                            cellCabecera = new PdfPCell(new Paragraph(item2["FECHA_ASISTENCIA"].ToString(), fontNormalHorario));
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //ESTADO
                            if (item2["ID_ESTADO_ASISTENCIA"].ToString()=="0")
                            {
                                cellCabecera = new PdfPCell(new Paragraph(item2["DESCRIPCION_ESTADO"].ToString(), new Font(Font.HELVETICA, 6, Font.BOLD, Color.BLUE)));
                            }
                            else if (item2["ID_ESTADO_ASISTENCIA"].ToString() == "1")
                            {
                                cellCabecera = new PdfPCell(new Paragraph(item2["DESCRIPCION_ESTADO"].ToString(), new Font(Font.HELVETICA, 6, Font.BOLD, Color.GREEN)));
                            }
                            else
                            {
                                cellCabecera = new PdfPCell(new Paragraph(item2["DESCRIPCION_ESTADO"].ToString(), new Font(Font.HELVETICA, 6, Font.BOLD, Color.RED)));
                            }
                            cellCabecera.HorizontalAlignment = 1;
                            tableDetalle.AddCell(cellCabecera);
                            //OBSERVACIONES
                            cellCabecera = new PdfPCell(new Paragraph(item2["OBSERVACION_ASISTENCIA"].ToString(), fontNormalHorario));
                            tableDetalle.AddCell(cellCabecera);
                        }
                    }

                    document.Add(tableDetalle);

                    //Addtional Information
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "Reporte_Asistencia_Docente_" + ds.Tables[0].Rows[0]["DESCRIPCION_UNIVERSIDAD"].ToString() + "_" + txt_fecha.Text + ".pdf");
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