using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class ReporteNotasEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btn_buscar);
            if (!IsPostBack)
            {
                //((util)HttpContext.Current.Session["util"]).audit().RegistrarAuditoria(((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["COD_USUARIO"].ToString(), ((util)HttpContext.Current.Session["util"]).usuario.Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString(), Session.SessionID, ((util)HttpContext.Current.Session["util"]).AUD_ACCION_ABRIR, ((util)HttpContext.Current.Session["util"]).audit().CrearTag("FORMULARIO:", ((util)HttpContext.Current.Session["util"]).AUD_FORMULARIO_REPORTE_INSCRIPCIONES));
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

                DataSet ds2 = new DataSet();
                DbCommand cmd2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminPeriodo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd2, "@OPERACION", DbType.String, "OB");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd2, "@outID", DbType.Int32, 10);
                ds2 = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd2);
                cmb_periodo.DataSource = ds2.Tables[0];
                cmb_periodo.DataTextField = ds2.Tables[0].Columns["DESCRIPCION_PERIODO"].ToString();
                cmb_periodo.DataValueField = ds2.Tables[0].Columns["ID_PERIODO"].ToString();
                cmb_periodo.DataBind();
                cmb_periodo.Items.Insert(0, "");

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void cmb_sede_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminCarrera");
            ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBCFS");
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

        protected void cmb_carrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervalo");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBIF");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_horario.DataSource = ds.Tables[0];
                cmb_horario.DataTextField = ds.Tables[0].Columns["DESCRIPCION_INTERVALO"].ToString();
                cmb_horario.DataValueField = ds.Tables[0].Columns["ID_INTERVALO"].ToString();
                cmb_horario.DataBind();
                cmb_horario.Items.Insert(0, "");
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
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBID");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);
                cmb_hora.DataSource = ds.Tables[0];
                cmb_hora.DataTextField = ds.Tables[0].Columns["INTERVALO"].ToString();
                cmb_hora.DataValueField = ds.Tables[0].Columns["ID_INTERVALO_DETALLE"].ToString();
                cmb_hora.DataBind();
                cmb_hora.Items.Insert(0, "");
            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
            }
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            GenerarPdf();
        }

        public void GenerarPdf()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand cmd = ((util)HttpContext.Current.Session["util"]).ConexionSegura.GetStoredProcCommand("dbo.ReporteNotaEstudiante");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBC");
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PERIODO", DbType.String, cmb_periodo.SelectedValue);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                ds = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    Document document = new Document(PageSize.A3.Rotate(), 20f, 20f, 10f, 10f);

                    /*FONT*/
                    Font fontNormalHorario = FontFactory.GetFont(FontFactory.HELVETICA, 5, Font.NORMAL);
                    Font fontNormalHorarioCabecera = FontFactory.GetFont(FontFactory.HELVETICA, 5, Font.BOLD);

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
                        phrase.Add(new Chunk(ds.Tables[0].Rows[0]["DESCRIPCION_CARRERA"].ToString() + "\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.BLACK)));
                        phrase.Add(new Chunk("Periodo: " + ds.Tables[0].Rows[0]["DESCRIPCION_PERIODO"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk("Sede: " + ds.Tables[0].Rows[0]["DESCRIPCION_UNIVERSIDAD"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk("Modalidad: " + ds.Tables[0].Rows[0]["DESCRIPCION_TIPO_INVERTALO"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk("Hora: " + ds.Tables[0].Rows[0]["HORA"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
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


                        int columnas = Convert.ToInt32(ds.Tables[0].Rows[0]["TOTAL"].ToString()) + 4;
                        PdfPTable tableDetalle = new PdfPTable(columnas);
                        tableDetalle.WidthPercentage = 100;
                        //float[] anchoColumnastblDetalle = { 100, 75, 80, 300, 250 };
                        //tableDetalle.SetTotalWidth(anchoColumnastblDetalle);
                        tableDetalle.DefaultCell.Border = PdfTable.NO_BORDER;

                        //GENERO CABECERA

                        //NUMERO 
                        PdfPCell cellID = new PdfPCell(new Paragraph("# ", fontNormalHorarioCabecera));
                        cellID.Rowspan = 2;
                        cellID.HorizontalAlignment = 1;
                        tableDetalle.AddCell(cellID);


                        //APELLIDO
                        PdfPCell cellApellido = new PdfPCell(new Paragraph("APELLIDOS", fontNormalHorarioCabecera));
                        cellApellido.Rowspan = 2;
                        cellApellido.HorizontalAlignment = 1;
                        tableDetalle.AddCell(cellApellido);

                        //NOMBRES
                        PdfPCell cellNombre = new PdfPCell(new Paragraph("NOMBRES", fontNormalHorarioCabecera));
                        cellNombre.Rowspan = 2;
                        cellNombre.HorizontalAlignment = 1;
                        tableDetalle.AddCell(cellNombre);

                        //PARCIALES
                        DataSet dsP = new DataSet();
                        cmd.Parameters.Clear();
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBP");
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, ds.Tables[0].Rows[0]["ID_NOTA"].ToString());
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                        dsP = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                        PdfPCell cellParcial = null;
                        foreach (DataTable table4 in dsP.Tables)
                        {
                            foreach (DataRow item2 in table4.Rows)
                            {
                                cellParcial = new PdfPCell(new Paragraph(item2["DESCRIPCION_NOTA_DETALLE"].ToString(), fontNormalHorarioCabecera));
                                if (item2["TOTAL"].ToString() != "1")
                                {
                                    cellParcial.Colspan = Convert.ToInt32(item2["TOTAL"].ToString());
                                    cellParcial.HorizontalAlignment = 1;
                                }
                                else
                                {
                                    cellParcial.Rowspan = 2;
                                    cellParcial.HorizontalAlignment = 1;
                                }
                                tableDetalle.AddCell(cellParcial);
                            }
                        }

                        /*NOTA FINAL*/
                        cellParcial = new PdfPCell(new Paragraph("NOTA FINAL", fontNormalHorarioCabecera));
                        cellParcial.Rowspan = 2;
                        cellParcial.HorizontalAlignment = 1;
                        tableDetalle.AddCell(cellParcial);

                        /*NOTA DETALLE*/
                        DataSet dsD = new DataSet();
                        cmd.Parameters.Clear();
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBD");
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, ds.Tables[0].Rows[0]["ID_NOTA"].ToString());
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                        dsD = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                        foreach (DataTable table4 in dsD.Tables)
                        {
                            foreach (DataRow item2 in table4.Rows)
                            {
                                if (item2["TOTAL"].ToString() != "1")
                                {
                                    cellParcial = new PdfPCell(new Paragraph(item2["DESCRIPCION_PONDERACION"].ToString(), fontNormalHorarioCabecera));
                                    cellParcial.HorizontalAlignment = 1;
                                    tableDetalle.AddCell(cellParcial);
                                }
                            }
                        }

                        /*OBTENER ESTUDIANTES*/
                        DataSet dsEst = new DataSet();
                        cmd.Parameters.Clear();
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBEST");
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PERIODO", DbType.String, cmb_periodo.SelectedValue);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                        ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                        dsEst = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                        if (dsEst.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataTable table4 in dsEst.Tables)
                            {
                                foreach (DataRow item2 in table4.Rows)
                                {
                                    cellParcial = new PdfPCell(new Paragraph(item2["ID_ESTUDIANTE"].ToString(), fontNormalHorario));
                                    tableDetalle.AddCell(cellParcial);

                                    cellParcial = new PdfPCell(new Paragraph(item2["APELLIDO_PATERNO_ESTUDIANTE"].ToString(), fontNormalHorario));
                                    tableDetalle.AddCell(cellParcial);

                                    cellParcial = new PdfPCell(new Paragraph(item2["PRIMER_NOMBRE_ESTUDIANTE"].ToString(), fontNormalHorario));
                                    tableDetalle.AddCell(cellParcial);


                                    /*OBTENER NOTAS ESTUDIANTES*/
                                    DataSet dsEstNota = new DataSet();
                                    cmd.Parameters.Clear();
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBNEST");
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, ds.Tables[0].Rows[0]["ID_NOTA"].ToString());
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE", DbType.String, item2["ID_ESTUDIANTE"].ToString());
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PERIODO", DbType.String, cmb_periodo.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                                    dsEstNota = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                                    foreach (DataTable table5 in dsEstNota.Tables)
                                    {
                                        foreach (DataRow item5 in table5.Rows)
                                        {
                                            cellParcial = new PdfPCell(new Paragraph(item5["VALOR_NOTA"].ToString(), fontNormalHorario));
                                            cellParcial.HorizontalAlignment = 1;
                                            tableDetalle.AddCell(cellParcial);
                                        }
                                    }

                                    /*OBTENER NOTAS FINAL ESTUDIANTES*/
                                    DataSet dsEstNotaFinal = new DataSet();
                                    cmd.Parameters.Clear();
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@OPERACION", DbType.String, "OBNFI");
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_SEDE", DbType.String, cmb_sede.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_CARRERA", DbType.String, cmb_carrera.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, cmb_horario.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, cmb_hora.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_NOTA", DbType.String, ds.Tables[0].Rows[0]["ID_NOTA"].ToString());
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_ESTUDIANTE", DbType.String, item2["ID_ESTUDIANTE"].ToString());
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddInParameter(cmd, "@ID_PERIODO", DbType.String, cmb_periodo.SelectedValue);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                                    ((util)HttpContext.Current.Session["util"]).ConexionSegura.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                                    dsEstNotaFinal = ((util)HttpContext.Current.Session["util"]).ConexionSegura.ExecuteDataSet(cmd);

                                    if (dsEstNotaFinal.Tables[0].Rows.Count > 1)
                                    {
                                        cellParcial = new PdfPCell(new Paragraph(dsEstNotaFinal.Tables[0].Rows[0]["NOTA_FINAL"].ToString(), fontNormalHorario));
                                    }
                                    else
                                    {
                                        cellParcial = new PdfPCell(new Paragraph("N/S", fontNormalHorario));
                                    }
                                    cellParcial.HorizontalAlignment = 1;
                                    tableDetalle.AddCell(cellParcial);
                                }
                            }
                        }



                        document.Add(tableDetalle);

                        //Addtional Information
                        document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + ds.Tables[0].Rows[0]["DESCRIPCION_UNIVERSIDAD"].ToString() + "_" + ds.Tables[0].Rows[0]["COD_CARRERA"].ToString() + "_" + ds.Tables[0].Rows[0]["HORA"].ToString() + ".pdf");
                        Response.ContentType = "application/pdf";
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();
                        Response.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                ((util)HttpContext.Current.Session["util"]).RegistrarError(ex);
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