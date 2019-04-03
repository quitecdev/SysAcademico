﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Model.Services.Admin;
using Model.Services.Docente;
using Model.Services.Estudiante;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Data;
using System.Reflection;

namespace CAS_ADMIN.Models
{
    public class PrintPDF
    {

        //TITULOS
        static Font titleFont15 = FontFactory.GetFont("Arial", 15, Font.BOLD);
        static Font titleFont12 = FontFactory.GetFont("Arial", 12, Font.BOLD);
        static Font titleFont10 = FontFactory.GetFont("Arial", 10, Font.BOLD);
        static Font titleFont8 = FontFactory.GetFont("Arial", 8, Font.BOLD);
        static Font titleFont8B = FontFactory.GetFont("Arial", 8, Font.BOLD, Color.WHITE);
        static Font titleFont5 = FontFactory.GetFont("Arial", 6, Font.BOLD);
        static Font titleFont5B = FontFactory.GetFont("Arial", 6, Font.BOLD, Color.WHITE);
        //TEXTO
        static Font Font12 = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        static Font Font10 = FontFactory.GetFont("Arial", 10, Font.NORMAL);
        static Font Font8 = FontFactory.GetFont("Arial", 8, Font.NORMAL);
        static Font Font5 = FontFactory.GetFont("Arial", 6, Font.NORMAL);
        static Font Font5B = FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.WHITE);

        //BG
        static Color BgTable = WebColors.GetRGBColor("#8b1716");
        static iTextSharp.text.Color BgAzul = WebColors.GetRGBColor("#45b0e2");
        static iTextSharp.text.Color BgVerde = WebColors.GetRGBColor("#3ec845");
        static iTextSharp.text.Color BgRojo = WebColors.GetRGBColor("#e96154");
        static iTextSharp.text.Color BgAmarillo = WebColors.GetRGBColor("#fbca35");

        Pdf_Eventos ev = new Pdf_Eventos();

        #region DOCENTE

        #region ImprimirHorarioDocente
        public byte[] ImprimirHorarioDocente(string ID_DOCENTE)
        {
            Byte[] bytes = null;
            Docente docente = new Docente();
            Periodo perido = new Periodo();
            HorarioDocente horario = new HorarioDocente();
            try
            {
                /*DATOS*/
                docente = docente.ObtenerDocente(ID_DOCENTE);
                perido = perido.ObtenerPeriodoActivo();
                horario = horario.ObtenerHorario(ID_DOCENTE);

                Document document = new Document(PageSize.A4, 20f, 20f, 25f, 25f);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    document.Open();

                    #region Cabecera
                    List<Cabecera> list = new List<Cabecera>();
                    list.Add(new Cabecera { Titulo = "Periodo: ", Valor = perido.DESCRIPCION_PERIODO });
                    list.Add(new Cabecera { Titulo = "Documento: ", Valor = docente.ID_DOCENTE });
                    list.Add(new Cabecera { Titulo = "Docente: ", Valor = docente.APELLIDO_PATERNO_DOCENTE + " " + docente.APELLIDO_MATERNO_DOCENTE + " " + docente.PRIMER_NOMBRE_DOCENTE + " " + docente.SEGUNDO_NOMBRE_DOCENTE });
                    document.Add(TablaCabecera("Horario Docente", list));
                    #endregion

                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());

                    List<string> titulo = new List<string>();


                    #region Horario
                    PdfPTable horarioTable = new PdfPTable(7);
                    horarioTable.HorizontalAlignment = 0;
                    horarioTable.WidthPercentage = 100;
                    horarioTable.SetWidths(new float[] { 200, 100, 100, 100, 100, 100, 100 });
                    horarioTable.SpacingAfter = 40;

                    titulo.Add("HORIA/DIA");
                    titulo.Add("Lunes");
                    titulo.Add("Martes");
                    titulo.Add("Miércoles");
                    titulo.Add("Jueves");
                    titulo.Add("Viernes");
                    titulo.Add("Sábado");

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont8B));
                        cell1.BackgroundColor = BgTable;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        horarioTable.AddCell(cell1);
                    }
                    foreach (var item in horario.Horario)
                    {
                        PdfPCell horaCell = new PdfPCell(new Phrase(item.HORIA_DIA, titleFont8B));
                        horaCell.BackgroundColor = BgTable;
                        horaCell.HorizontalAlignment = 1;
                        horaCell.PaddingLeft = 10f;
                        horarioTable.AddCell(horaCell);

                        PdfPCell horaLunes = new PdfPCell(new Phrase(item.LUNES, Font8));
                        horaLunes.HorizontalAlignment = 1;
                        horaLunes.PaddingLeft = 10f;
                        horarioTable.AddCell(horaLunes);

                        PdfPCell horaMartes = new PdfPCell(new Phrase(item.MARTES, Font8));
                        horaMartes.HorizontalAlignment = 1;
                        horaMartes.PaddingLeft = 10f;
                        horarioTable.AddCell(horaMartes);

                        PdfPCell horaMiercoles = new PdfPCell(new Phrase(item.MIERCOLES, Font8));
                        horaMiercoles.HorizontalAlignment = 1;
                        horaMiercoles.PaddingLeft = 10f;
                        horarioTable.AddCell(horaMiercoles);

                        PdfPCell horaJueves = new PdfPCell(new Phrase(item.JUEVES, Font8));
                        horaJueves.HorizontalAlignment = 1;
                        horaJueves.PaddingLeft = 10f;
                        horarioTable.AddCell(horaJueves);

                        PdfPCell horaViernes = new PdfPCell(new Phrase(item.VIERNES, Font8));
                        horaViernes.HorizontalAlignment = 1;
                        horaViernes.PaddingLeft = 10f;
                        horarioTable.AddCell(horaViernes);

                        PdfPCell horaSabadp = new PdfPCell(new Phrase(item.SABADO, Font8));
                        horaSabadp.HorizontalAlignment = 1;
                        horaSabadp.PaddingLeft = 10f;
                        horarioTable.AddCell(horaSabadp);

                    }
                    document.Add(horarioTable);
                    #endregion

                    #region Materia
                    PdfPTable MateriaTable = new PdfPTable(3);
                    MateriaTable.HorizontalAlignment = 0;
                    MateriaTable.WidthPercentage = 100;
                    MateriaTable.SetWidths(new float[] { 300, 300, 300 });
                    MateriaTable.SpacingAfter = 40;

                    titulo = new List<string>();
                    titulo.Add("Sede");
                    titulo.Add("Carrera");
                    titulo.Add("Materia");

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont8B));
                        cell1.BackgroundColor = BgTable;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        MateriaTable.AddCell(cell1);
                    }

                    foreach (var item in horario.CarreraMateria)
                    {
                        PdfPCell SedeCell = new PdfPCell(new Phrase(item.DESCRIPCION_UNIVERSIDAD + " - " + item.COD_SEDE, Font8));
                        SedeCell.HorizontalAlignment = 1;
                        SedeCell.PaddingLeft = 10f;
                        MateriaTable.AddCell(SedeCell);

                        PdfPCell CarreraCell = new PdfPCell(new Phrase(item.DESCRIPCION_CARRERA + " - " + item.COD_CARRERA, Font8));
                        CarreraCell.HorizontalAlignment = 1;
                        CarreraCell.PaddingLeft = 10f;
                        MateriaTable.AddCell(CarreraCell);

                        PdfPCell MaterialCell = new PdfPCell(new Phrase(item.DESCRIPCION_MATERIA + " - " + item.COD_MATERIA, Font8));
                        MaterialCell.HorizontalAlignment = 1;
                        MaterialCell.PaddingLeft = 10f;
                        MateriaTable.AddCell(MaterialCell);
                    }


                    document.Add(MateriaTable);
                    #endregion



                    //Addtional Information
                    document.Close();
                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                return bytes;
            }
            catch (Exception ex)
            {
                return bytes;
            }
        }
        #endregion

        #region ImprimirNotaDocente
        public byte[] ImprimirNotaDocente(int ID_SEDE, int ID_CARRERA, int ID_NOTA, int ID_INTERVALO_DETALLE, string ID_DOCENTE)
        {
            Sede sede = new Sede();
            Carrera carrera = new Carrera();
            IntervaloDetalle intervalo = new IntervaloDetalle();
            Docente docente = new Docente();
            Periodo periodo = new Periodo();
            Calificar nota = new Calificar();
            Byte[] bytes = null;
            try
            {
                sede = sede.ObtenerSede(ID_SEDE);
                carrera = carrera.ObtenerCarrera(ID_SEDE);
                intervalo = intervalo.ObtenerIntervalo(ID_INTERVALO_DETALLE);
                docente = docente.ObtenerDocente(ID_DOCENTE);
                periodo = periodo.ObtenerPeriodoActivo();
                nota = nota.ObtenerLibreta(ID_SEDE, ID_CARRERA, ID_NOTA, ID_INTERVALO_DETALLE, ID_DOCENTE);
                Document document = new Document(PageSize.A3.Rotate(), 20f, 20f, 25f, 25f);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    document.Open();

                    #region Cabecera
                    List<Cabecera> list = new List<Cabecera>();
                    list.Add(new Cabecera { Titulo = "Periodo: ", Valor = periodo.DESCRIPCION_PERIODO });
                    list.Add(new Cabecera { Titulo = "Carrera: ", Valor = carrera.DESCRIPCION_CARRERA });
                    list.Add(new Cabecera { Titulo = "Horario: ", Valor = intervalo.INICIO_INTERVALO + "-" + intervalo.FIN_INTERVALO });
                    list.Add(new Cabecera { Titulo = "Documento: ", Valor = docente.ID_DOCENTE });
                    list.Add(new Cabecera { Titulo = "Docente: ", Valor = docente.APELLIDO_PATERNO_DOCENTE + " " + docente.APELLIDO_MATERNO_DOCENTE + " " + docente.PRIMER_NOMBRE_DOCENTE + " " + docente.SEGUNDO_NOMBRE_DOCENTE });
                    document.Add(TablaCabecera("Libreta Docente", list));
                    #endregion

                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());

                    #region NotaTitulo

                    int columnas = 0;
                    foreach (var item in nota.Parcial)
                    {
                        columnas = columnas + item.TOTAL.Value;
                    }

                    PdfPTable TituloDetalle = new PdfPTable(columnas + 2);
                    TituloDetalle.WidthPercentage = 100;
                    TituloDetalle.SpacingAfter = 40;

                    List<string> titulo = new List<string>();
                    titulo.Add("N. IDENTIDAD");
                    titulo.Add("NOMBRES");

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont5B));
                        cell1.BackgroundColor = BgTable;
                        cell1.Rowspan = 2;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        TituloDetalle.AddCell(cell1);
                    }

                    foreach (var item in nota.Parcial)
                    {
                        if (item.TOTAL != 1)
                        {
                            PdfPCell cell1 = new PdfPCell(new Phrase(item.DESCRIPCION_NOTA_DETALLE, titleFont5B));
                            cell1.Colspan = Convert.ToInt32(item.TOTAL);
                            cell1.BackgroundColor = BgTable;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            TituloDetalle.AddCell(cell1);
                        }
                        else
                        {
                            PdfPCell cell1 = new PdfPCell(new Phrase(item.DESCRIPCION_NOTA_DETALLE, titleFont5B));
                            cell1.BackgroundColor = BgTable;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            TituloDetalle.AddCell(cell1);
                        }
                    }

                    foreach (var item in nota.Nota_Detalla)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item.DESCRIPCION_PONDERACION, titleFont5B));
                        cell1.BackgroundColor = BgTable;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        TituloDetalle.AddCell(cell1);
                    }
                    foreach (var estudiante in nota.Estudiante)
                    {
                        PdfPCell cellId = new PdfPCell(new Phrase(estudiante.ID_ESTUDIANTE, Font5));
                        cellId.HorizontalAlignment = 1;
                        cellId.PaddingLeft = 10f;
                        TituloDetalle.AddCell(cellId);

                        PdfPCell cellNombre = new PdfPCell(new Phrase(estudiante.APELLIDO_PATERNO_ESTUDIANTE + " " + estudiante.PRIMER_NOMBRE_ESTUDIANTE, Font5));
                        cellNombre.HorizontalAlignment = 1;
                        cellNombre.PaddingLeft = 10f;
                        TituloDetalle.AddCell(cellNombre);
                        foreach (var detalle in estudiante.NOTAS)
                        {

                            PdfPCell cellNota = new PdfPCell(new Phrase(detalle.VALOR_NOTA.ToString(), Font5));
                            cellNota.HorizontalAlignment = 1;
                            cellNota.PaddingLeft = 10f;
                            TituloDetalle.AddCell(cellNota);
                        }
                    }


                    document.Add(TituloDetalle);

                    #endregion


                    document.Close();
                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                return bytes;
            }
            catch (Exception)
            {
                return bytes;
            }
        }
        #endregion

        #region ImprimirAsistenciaDocente
        public byte[] ImprimirAsistenciaDocente(string ID_DOCENTE)
        {
            Byte[] bytes = null;
            Docente docente = new Docente();
            Periodo perido = new Periodo();
            DocenteAsistencia asistencia = new DocenteAsistencia();
            List<DocenteAsistencia> listAsistencia = new List<DocenteAsistencia>();
            try
            {
                /*DATOS*/
                docente = docente.ObtenerDocente(ID_DOCENTE);
                perido = perido.ObtenerPeriodoActivo();
                listAsistencia = asistencia.ObtenerAsistencia(ID_DOCENTE);

                Document document = new Document(PageSize.A4.Rotate(), 20f, 20f, 25f, 25f);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    document.Open();

                    #region Cabecera
                    List<Cabecera> list = new List<Cabecera>();
                    list.Add(new Cabecera { Titulo = "Periodo: ", Valor = perido.DESCRIPCION_PERIODO });
                    list.Add(new Cabecera { Titulo = "Documento: ", Valor = docente.ID_DOCENTE });
                    list.Add(new Cabecera { Titulo = "Docente: ", Valor = docente.APELLIDO_PATERNO_DOCENTE + " " + docente.APELLIDO_MATERNO_DOCENTE + " " + docente.PRIMER_NOMBRE_DOCENTE + " " + docente.SEGUNDO_NOMBRE_DOCENTE });
                    document.Add(TablaCabecera("Asistencia Docente", list));
                    #endregion

                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());


                    #region Asistencia
                    PdfPTable horarioTable = new PdfPTable(7);
                    horarioTable.HorizontalAlignment = 0;
                    horarioTable.WidthPercentage = 100;
                    horarioTable.SetWidths(new float[] { 75, 250, 175, 80, 100, 185, 200 });
                    horarioTable.SpacingAfter = 40;
                    List<string> titulo = new List<string>();
                    titulo.Add("Sede");
                    titulo.Add("Carrera");
                    titulo.Add("Materia");
                    titulo.Add("Paralelo");
                    titulo.Add("Fecha");
                    titulo.Add("Hora");
                    titulo.Add("Estado");

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont8B));
                        cell1.BackgroundColor = BgTable;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        horarioTable.AddCell(cell1);
                    }

                    if (listAsistencia != null)
                    {
                        foreach (var item in listAsistencia)
                        {
                            PdfPCell sedeCell = new PdfPCell(new Phrase(item.DESCRIPCION_UNIVERSIDAD, Font8));
                            //sedeCell.BackgroundColor = BgTable;
                            sedeCell.HorizontalAlignment = 1;
                            sedeCell.PaddingLeft = 10f;
                            horarioTable.AddCell(sedeCell);

                            PdfPCell carrerraCell = new PdfPCell(new Phrase(item.DESCRIPCION_CARRERA, Font8));
                            carrerraCell.HorizontalAlignment = 1;
                            carrerraCell.PaddingLeft = 10f;
                            horarioTable.AddCell(carrerraCell);

                            PdfPCell materiaCell = new PdfPCell(new Phrase(item.DESCRIPCION_MATERIA, Font8));
                            materiaCell.HorizontalAlignment = 1;
                            materiaCell.PaddingLeft = 10f;
                            horarioTable.AddCell(materiaCell);

                            PdfPCell paraleloCell = new PdfPCell(new Phrase(item.DESCRIPCION_PARALELO, Font8));
                            paraleloCell.HorizontalAlignment = 1;
                            paraleloCell.PaddingLeft = 10f;
                            horarioTable.AddCell(paraleloCell);

                            PdfPCell fechaCell = new PdfPCell(new Phrase(item.FECHA_ASISTENCIA.ToShortDateString(), Font8));
                            fechaCell.HorizontalAlignment = 1;
                            fechaCell.PaddingLeft = 10f;
                            horarioTable.AddCell(fechaCell);

                            PdfPCell horaCell = new PdfPCell(new Phrase(item.HORA, Font8));
                            horaCell.HorizontalAlignment = 1;
                            horaCell.PaddingLeft = 10f;
                            horarioTable.AddCell(horaCell);

                            if (item.ESTADO_ASISTENCIA == 0)
                            {
                                PdfPCell estadoCell = new PdfPCell(new Phrase("Próxima Asistencia", Font5B));
                                estadoCell.BackgroundColor = BgAzul;
                                estadoCell.HorizontalAlignment = 1;
                                estadoCell.PaddingLeft = 10f;
                                horarioTable.AddCell(estadoCell);
                            }
                            else if (item.ESTADO_ASISTENCIA == 1)
                            {
                                PdfPCell estadoCell = new PdfPCell(new Phrase("Asistencia Completa", Font5B));
                                estadoCell.BackgroundColor = BgVerde;
                                estadoCell.HorizontalAlignment = 1;
                                estadoCell.PaddingLeft = 10f;
                                horarioTable.AddCell(estadoCell);
                            }
                            else
                            {
                                PdfPCell estadoCell = new PdfPCell(new Phrase("Sin Asistencia", Font5B));
                                estadoCell.BackgroundColor = BgRojo;
                                estadoCell.HorizontalAlignment = 1;
                                estadoCell.PaddingLeft = 10f;
                                horarioTable.AddCell(estadoCell);
                            }

                            PdfPCell observacionCell = new PdfPCell(new Phrase("OBSERVACIÓN: " + item.OBSERVACION_ASISTENCIA, Font8));
                            observacionCell.Colspan = 7;
                            observacionCell.PaddingLeft = 10f;
                            horarioTable.AddCell(observacionCell);

                        }
                    }
                    document.Add(horarioTable);
                    #endregion
                    //Addtional Information
                    document.Close();
                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                return bytes;
            }
            catch (Exception ex)
            {
                return bytes;
            }
        }
        #endregion

        #endregion

        #region INSCRIPCION

        #region ImprimirInscripcion
        public byte[] ImprimirInscripcion(int ID_INSCRIP_DETALLE_CARRERA)
        {
            Byte[] bytes = null;
            Periodo perido = new Periodo();
            Inscipcion inscripcion = new Inscipcion();
            InscripcionDetallleCarrera detalle = new InscripcionDetallleCarrera();
            List<InscripcionDetallleCarrera> detalleCarrera = new List<InscripcionDetallleCarrera>();
            try
            {
                /*DATOS*/
                inscripcion = inscripcion.ObtenerInscripcion(ID_INSCRIP_DETALLE_CARRERA);
                detalleCarrera = detalle.ObtenerDetalle(ID_INSCRIP_DETALLE_CARRERA, inscripcion.ID_INSCRIP);

                Document document = new Document(PageSize.A4, 20f, 20f, 150f, 25f);
                PdfReader readerBicycle = null;
                PdfContentByte _pcb = null;
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();

                    // Load the background image and add it to the document structure
                    var rootPath = System.Web.Hosting.HostingEnvironment.MapPath("~/doc/PlantillaHojaInscripcion.pdf");
                    readerBicycle = new PdfReader(rootPath);
                    PdfTemplate background = writer.GetImportedPage(readerBicycle, 1);

                    // Create a page in the document and add it to the bottom layer
                    document.NewPage();
                    _pcb = writer.DirectContentUnder;
                    _pcb.AddTemplate(background, 0, 0);

                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());

                    Paragraph DatosPersonales = new Paragraph(new Chunk("DATOS PERSONALES", titleFont15));
                    DatosPersonales.Alignment = Element.ALIGN_LEFT;
                    document.Add(DatosPersonales);
                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());

                    #region DatosPersonales
                    PdfPTable tableDatosPersonales = new PdfPTable(2);
                    float[] anchoColumnastblTotal = { 320, 800 };
                    tableDatosPersonales.WidthPercentage = 100;
                    tableDatosPersonales.SetTotalWidth(anchoColumnastblTotal);
                    tableDatosPersonales.DefaultCell.Border = PdfTable.NO_BORDER;
                    tableDatosPersonales.HorizontalAlignment = Element.ALIGN_RIGHT;

                    List<Cabecera> list = new List<Cabecera>();
                    list.Add(new Cabecera { Titulo = "Nº Docuemento de identidad:", Valor = inscripcion.ID_INSCRIP });
                    list.Add(new Cabecera { Titulo = "Nombres:", Valor = inscripcion.APELLIDO_PATERNO_INSCRIP + " " + inscripcion.APELLIDO_MATERNO_INSCRIP + " " + inscripcion.PRIMER_NOMBRE_INSCRIP + " " + inscripcion.SEGUNDO_NOMBRE_INSCRIP });
                    list.Add(new Cabecera { Titulo = "Fecha Nacimiento:", Valor = inscripcion.FECHA_NACIMIENTO_INSCRIP.Value.ToShortDateString() });
                    list.Add(new Cabecera { Titulo = "Estado Civil:", Valor = inscripcion.cmb_EstadoCivil(inscripcion.ID_ESTADO_CIVIL.Value).DESCRIPCION_ESTADO_CIVIL });
                    list.Add(new Cabecera { Titulo = "Correo Electrónico:", Valor = inscripcion.CORREO });
                    list.Add(new Cabecera { Titulo = "Teléfono:", Valor = inscripcion.TELEF_INSCRIP });
                    list.Add(new Cabecera { Titulo = "Celular: ", Valor = inscripcion.CEL_INSCRIP });
                    list.Add(new Cabecera { Titulo = "Teléfono Emergencia:", Valor = inscripcion.TELEF_EMER_INSCRIP });
                    list.Add(new Cabecera { Titulo = "Dirección:", Valor = inscripcion.DIRECCION });

                    foreach (var item in list)
                    {
                        PdfPCell tituloCell = new PdfPCell(new Phrase(item.Titulo, titleFont10));
                        tituloCell.PaddingLeft = 10f;
                        tituloCell.Border = PdfPCell.NO_BORDER;
                        tableDatosPersonales.AddCell(tituloCell);

                        PdfPCell valorCell = new PdfPCell(new Phrase(item.Valor, Font10));
                        valorCell.PaddingLeft = 10f;
                        valorCell.Border = PdfPCell.NO_BORDER;
                        tableDatosPersonales.AddCell(valorCell);
                    }
                    document.Add(tableDatosPersonales);
                    #endregion

                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());

                    DatosPersonales = new Paragraph(new Chunk("DATOS CARRERA", titleFont15));
                    DatosPersonales.Alignment = Element.ALIGN_LEFT;
                    document.Add(DatosPersonales);
                    document.Add(TablaSeparador());
                    document.Add(TablaSeparador());

                    #region DatosCarrera
                    PdfPTable carreraTable = new PdfPTable(8);
                    carreraTable.HorizontalAlignment = 0;
                    carreraTable.WidthPercentage = 100;
                    //carreraTable.SetWidths(new float[] { 300, 85, 300, 250, 200, 75, 100,250 });
                    carreraTable.SpacingAfter = 40;
                    List<string> titulo = new List<string>();
                    titulo.Add("Periodo");
                    titulo.Add("Sede");
                    titulo.Add("Carrera");
                    titulo.Add("Tip. Horario");
                    titulo.Add("Hora");
                    titulo.Add("Paralelo");
                    titulo.Add("Estado");
                    titulo.Add("Factura");

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont5B));
                        cell1.BackgroundColor = BgTable;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        carreraTable.AddCell(cell1);
                    }
                    if (detalleCarrera != null)
                    {
                        foreach (var item in detalleCarrera)
                        {
                            PdfPCell periodoCell = new PdfPCell(new Phrase(item.DESCRIPCION_PERIODO, Font5));
                            periodoCell.HorizontalAlignment = 1;
                            periodoCell.PaddingLeft = 10f;
                            carreraTable.AddCell(periodoCell);

                            PdfPCell sedeCell = new PdfPCell(new Phrase(item.DESCRIPCION_UNIVERSIDAD, Font5));
                            sedeCell.HorizontalAlignment = 1;
                            sedeCell.PaddingLeft = 10f;
                            carreraTable.AddCell(sedeCell);

                            PdfPCell carreraCell = new PdfPCell(new Phrase(item.DESCRIPCION_CARRERA, Font5));
                            carreraCell.HorizontalAlignment = 1;
                            carreraCell.PaddingLeft = 10f;
                            carreraTable.AddCell(carreraCell);

                            PdfPCell tipoHCell = new PdfPCell(new Phrase(item.DESCRIPCION_INTERVALO, Font5));
                            tipoHCell.HorizontalAlignment = 1;
                            tipoHCell.PaddingLeft = 10f;
                            carreraTable.AddCell(tipoHCell);

                            PdfPCell horaCell = new PdfPCell(new Phrase(item.HORA, Font5));
                            horaCell.HorizontalAlignment = 1;
                            horaCell.PaddingLeft = 10f;
                            carreraTable.AddCell(horaCell);

                            PdfPCell paraleloCell = new PdfPCell(new Phrase(item.DESCRIPCION_PARALELO, Font5));
                            paraleloCell.HorizontalAlignment = 1;
                            paraleloCell.PaddingLeft = 10f;
                            carreraTable.AddCell(paraleloCell);

                            if (item.ID_INSCRIPCION_ESTADO == 1 || item.ID_INSCRIPCION_ESTADO == 2)
                            {
                                PdfPCell estadoCell = new PdfPCell(new Phrase(item.DESCRIPCION_ESTADO, Font5B));
                                estadoCell.BackgroundColor = BgVerde;
                                estadoCell.HorizontalAlignment = 1;
                                estadoCell.PaddingLeft = 10f;
                                carreraTable.AddCell(estadoCell);
                            }
                            else if (item.ID_INSCRIPCION_ESTADO == 3)
                            {
                                PdfPCell estadoCell = new PdfPCell(new Phrase(item.DESCRIPCION_ESTADO, Font5B));
                                estadoCell.BackgroundColor = BgRojo;
                                estadoCell.HorizontalAlignment = 1;
                                estadoCell.PaddingLeft = 10f;
                                carreraTable.AddCell(estadoCell);
                            }
                            else
                            {
                                PdfPCell estadoCell = new PdfPCell(new Phrase(item.DESCRIPCION_ESTADO, Font5B));
                                estadoCell.BackgroundColor = BgAmarillo;
                                estadoCell.HorizontalAlignment = 1;
                                estadoCell.PaddingLeft = 10f;
                                carreraTable.AddCell(estadoCell);
                            }

                            PdfPCell fecturaCell = new PdfPCell(new Phrase(item.NUMERO_FACTURA, Font5));
                            fecturaCell.HorizontalAlignment = 1;
                            fecturaCell.PaddingLeft = 10f;
                            carreraTable.AddCell(fecturaCell);
                        }
                    }
                    document.Add(carreraTable);
                    #endregion

                    //Addtional Information
                    document.Close();
                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                return bytes;
            }
            catch (Exception ex)
            {
                return bytes;
            }
        }
        #endregion

        #region ImprimirNota
        public byte[] ImprimirNotaEstudianteCarrera(int ID_INSCRIP_DETALLE_CARRERA)
        {
            Inscipcion inscripcion = new Inscipcion();
            InscripcionDetallleCarrera inscripcionDetalle = new InscripcionDetallleCarrera();
            EstudianteNotaCarrera nota = new EstudianteNotaCarrera();
            List<EstudianteNotaCarrera> listNota = new List<EstudianteNotaCarrera>();
            Byte[] bytes = null;
            try
            {
                //DATOS
                inscripcion = inscripcion.ObtenerInscripcion(ID_INSCRIP_DETALLE_CARRERA);
                inscripcionDetalle = inscripcionDetalle.ObtenerDetalle(ID_INSCRIP_DETALLE_CARRERA);
                listNota = nota.ObtenerNotaCarrera(ID_INSCRIP_DETALLE_CARRERA);

                Document document = new Document(PageSize.A4, 20f, 20f, 25f, 25f);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    document.Open();

                    #region Cabecera
                    List<Cabecera> list = new List<Cabecera>();
                    list.Add(new Cabecera { Titulo = "Periodo: ", Valor = inscripcionDetalle.DESCRIPCION_PERIODO });
                    list.Add(new Cabecera { Titulo = "Carrera: ", Valor = inscripcionDetalle.DESCRIPCION_CARRERA });
                    list.Add(new Cabecera { Titulo = "Horario: ", Valor = inscripcionDetalle.HORA });
                    list.Add(new Cabecera { Titulo = "Documento: ", Valor = inscripcion.ID_INSCRIP });
                    list.Add(new Cabecera { Titulo = "Estudiante: ", Valor = inscripcion.APELLIDO_PATERNO_INSCRIP + " " + inscripcion.APELLIDO_MATERNO_INSCRIP + " " + inscripcion.PRIMER_NOMBRE_INSCRIP + " " + inscripcion.SEGUNDO_NOMBRE_INSCRIP });
                    document.Add(TablaCabecera("Libreta Estudiante", list));
                    #endregion
                    document.Add(TablaSeparador());
                    #region NotaFinal
                    PdfPTable notaFinalTable = new PdfPTable(3);
                    notaFinalTable.WidthPercentage = 75;
                    notaFinalTable.SetWidths(new float[] { 300, 75, 75 });
                    notaFinalTable.SpacingAfter = 20;

                    List<string> titulo = new List<string>();
                    titulo.Add("Detalle");
                    titulo.Add("Promedio");
                    titulo.Add("NOTA");

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont5B));
                        cell1.BackgroundColor = BgTable;
                        cell1.Padding = 5f;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        notaFinalTable.AddCell(cell1);
                    }

                    decimal final = 0M;
                    foreach (var item in listNota)
                    {
                        PdfPCell detalleCell = new PdfPCell(new Phrase(item.DESCRIPCION_NOTA_DETALLE, Font5));
                        detalleCell.HorizontalAlignment = 1;
                        detalleCell.Padding = 5f;
                        notaFinalTable.AddCell(detalleCell);

                        PdfPCell promedioCell = new PdfPCell(new Phrase(item.PROMEDIO.ToString(), Font5));
                        promedioCell.HorizontalAlignment = 1;
                        promedioCell.Padding = 5f;
                        notaFinalTable.AddCell(promedioCell);

                        PdfPCell notaCell = new PdfPCell(new Phrase(item.TOTAL.ToString(), Font5));
                        notaCell.HorizontalAlignment = 1;
                        notaCell.Padding = 5f;
                        notaFinalTable.AddCell(notaCell);

                        final = final + item.TOTAL.Value;
                    }
                    titulo = new List<string>();
                    titulo.Add("");
                    titulo.Add("NOTA FINAL");
                    titulo.Add(final.ToString());

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont5B));
                        cell1.BackgroundColor = BgTable;
                        cell1.Padding = 5f;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        notaFinalTable.AddCell(cell1);
                    }
                    document.Add(notaFinalTable);

                    #endregion

                    #region NotaDetalle
                    foreach (var item in listNota)
                    {
                        if (item.CONTADOR>1)
                        {
                            PdfPTable notaDetalleTable = new PdfPTable(4);
                            notaDetalleTable.WidthPercentage = 75;
                            notaDetalleTable.SpacingAfter = 20;

                            PdfPCell cell1 = new PdfPCell(new Phrase(item.DESCRIPCION_NOTA_DETALLE, titleFont5B));
                            cell1.BackgroundColor = BgTable;
                            cell1.Colspan = 4;
                            cell1.Padding = 5f;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            notaDetalleTable.AddCell(cell1);

                            titulo = new List<string>();
                            titulo.Add("COD.");
                            titulo.Add("Detalle");
                            titulo.Add("Nota");
                            titulo.Add("Valor");
                            foreach (var detalle in titulo)
                            {
                                PdfPCell cell2 = new PdfPCell(new Phrase(detalle, titleFont5B));
                                cell2.BackgroundColor = BgTable;
                                cell2.Padding = 5f;
                                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                                notaDetalleTable.AddCell(cell2);
                            }

                            foreach (var detalle2 in item.Detalle)
                            {
                                PdfPCell codCell = new PdfPCell(new Phrase(detalle2.ID_ESTUDIANTE_NOTA.ToString(), Font5));
                                codCell.HorizontalAlignment = 1;
                                codCell.Padding = 5f;
                                notaDetalleTable.AddCell(codCell);

                                PdfPCell detalleCell = new PdfPCell(new Phrase(detalle2.DESCRIPCION_PONDERACION.ToString(), Font5));
                                detalleCell.HorizontalAlignment = 1;
                                detalleCell.Padding = 5f;
                                notaDetalleTable.AddCell(detalleCell);

                                PdfPCell valorCell = new PdfPCell(new Phrase(detalle2.VALOR_NOTA.ToString(), Font5));
                                valorCell.HorizontalAlignment = 1;
                                valorCell.Padding = 5f;
                                notaDetalleTable.AddCell(valorCell);

                                PdfPCell notaCell = new PdfPCell(new Phrase(detalle2.NOTA.ToString(), Font5));
                                notaCell.HorizontalAlignment = 1;
                                notaCell.Padding = 5f;
                                notaDetalleTable.AddCell(notaCell);

                            }
                            titulo = new List<string>();
                            titulo.Add("");
                            titulo.Add("");
                            titulo.Add("NOTA");
                            titulo.Add(item.TOTAL.ToString());
                            foreach (var detalle in titulo)
                            {
                                PdfPCell cell2 = new PdfPCell(new Phrase(detalle, titleFont5B));
                                cell2.BackgroundColor = BgTable;
                                cell2.Padding = 5f;
                                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                                notaDetalleTable.AddCell(cell2);
                            }

                            document.Add(notaDetalleTable);
                        }

                    }
                    #endregion

                    document.Close();
                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                return bytes;
            }
            catch (Exception)
            {
                return bytes;
            }
        }
        #endregion

        #region ImprimirAsistencia
        public byte[] ImprimirAsistenciaEstudianteCarrera(int ID_INSCRIP_DETALLE_CARRERA)
        {
            Inscipcion inscripcion = new Inscipcion();
            InscripcionDetallleCarrera inscripcionDetalle = new InscripcionDetallleCarrera();
            EstudianteAsistenciaCarrera asistenciaCarrera = new EstudianteAsistenciaCarrera();
            List<EstudianteAsistenciaCarrera> listAsistencia = new List<EstudianteAsistenciaCarrera>();
            Byte[] bytes = null;
            try
            {
                //DATOS
                inscripcion = inscripcion.ObtenerInscripcion(ID_INSCRIP_DETALLE_CARRERA);
                inscripcionDetalle = inscripcionDetalle.ObtenerDetalle(ID_INSCRIP_DETALLE_CARRERA);
                listAsistencia = asistenciaCarrera.ObtenerAsistenciaCarrera(ID_INSCRIP_DETALLE_CARRERA);

                Document document = new Document(PageSize.A4, 20f, 20f, 25f, 25f);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    document.Open();

                    #region Cabecera
                    List<Cabecera> list = new List<Cabecera>();
                    list.Add(new Cabecera { Titulo = "Periodo: ", Valor = inscripcionDetalle.DESCRIPCION_PERIODO });
                    list.Add(new Cabecera { Titulo = "Carrera: ", Valor = inscripcionDetalle.DESCRIPCION_CARRERA });
                    list.Add(new Cabecera { Titulo = "Horario: ", Valor = inscripcionDetalle.HORA });
                    list.Add(new Cabecera { Titulo = "Documento: ", Valor = inscripcion.ID_INSCRIP });
                    list.Add(new Cabecera { Titulo = "Estudiante: ", Valor = inscripcion.APELLIDO_PATERNO_INSCRIP + " " + inscripcion.APELLIDO_MATERNO_INSCRIP + " " + inscripcion.PRIMER_NOMBRE_INSCRIP + " " + inscripcion.SEGUNDO_NOMBRE_INSCRIP });
                    document.Add(TablaCabecera("Asistencia Estudiante", list));
                    #endregion
                    document.Add(TablaSeparador());
                    #region Asistencia
                    PdfPTable asistenciaTable = new PdfPTable(8);
                    asistenciaTable.WidthPercentage = 100;
                    asistenciaTable.SetWidths(new float[] { 75, 80, 250, 200, 75, 100,150, 100});
                    asistenciaTable.SpacingAfter = 20;

                    List<string> titulo = new List<string>();
                    titulo.Add("COD.");
                    titulo.Add("Sede");
                    titulo.Add("Carrera");
                    titulo.Add("Materia");
                    titulo.Add("Paralelo");
                    titulo.Add("Fecha");
                    titulo.Add("Hora");
                    titulo.Add("Estado");

                    foreach (var item in titulo)
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase(item, titleFont5B));
                        cell1.BackgroundColor = BgTable;
                        cell1.Padding = 5f;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        asistenciaTable.AddCell(cell1);
                    }
                    int contador = 0;
                    foreach (var item in listAsistencia)
                    {
                        PdfPCell codCell = new PdfPCell(new Phrase(item.ID_ASISTENCIA.ToString(), Font5));
                        codCell.HorizontalAlignment = 1;
                        codCell.PaddingLeft = 5f;
                        asistenciaTable.AddCell(codCell);

                        PdfPCell sedeCell = new PdfPCell(new Phrase(item.DESCRIPCION_UNIVERSIDAD, Font5));
                        sedeCell.HorizontalAlignment = 1;
                        sedeCell.PaddingLeft = 5f;
                        asistenciaTable.AddCell(sedeCell);

                        PdfPCell carreraCell = new PdfPCell(new Phrase(item.DESCRIPCION_CARRERA, Font5));
                        carreraCell.HorizontalAlignment = 1;
                        carreraCell.PaddingLeft = 5f;
                        asistenciaTable.AddCell(carreraCell);

                        PdfPCell materiaCell = new PdfPCell(new Phrase(item.DESCRIPCION_MATERIA, Font5));
                        materiaCell.HorizontalAlignment = 1;
                        materiaCell.PaddingLeft = 5f;
                        asistenciaTable.AddCell(materiaCell);

                        PdfPCell paraleloCell = new PdfPCell(new Phrase(item.DESCRIPCION_PARALELO, Font5));
                        paraleloCell.HorizontalAlignment = 1;
                        paraleloCell.PaddingLeft = 5f;
                        asistenciaTable.AddCell(paraleloCell);

                        PdfPCell fechaCell = new PdfPCell(new Phrase(item.FECHA.Value.ToShortDateString(), Font5));
                        fechaCell.HorizontalAlignment = 1;
                        fechaCell.PaddingLeft = 5f;
                        asistenciaTable.AddCell(fechaCell);

                        PdfPCell horaCell = new PdfPCell(new Phrase(item.HORA, Font5));
                        horaCell.HorizontalAlignment = 1;
                        horaCell.PaddingLeft = 5f;
                        asistenciaTable.AddCell(horaCell);

                        if (item.ESTADO == true)
                        {
                            PdfPCell estadoCell = new PdfPCell(new Phrase("Asistencia", Font5B));
                            estadoCell.BackgroundColor = BgVerde;
                            estadoCell.HorizontalAlignment = 1;
                            estadoCell.PaddingLeft = 5f;
                            asistenciaTable.AddCell(estadoCell);
                        }
                        else                         {
                            PdfPCell estadoCell = new PdfPCell(new Phrase("Sin Asistencia", Font5B));
                            estadoCell.BackgroundColor = BgRojo;
                            estadoCell.HorizontalAlignment = 1;
                            estadoCell.PaddingLeft = 5f;
                            asistenciaTable.AddCell(estadoCell);
                            contador++;
                        }
                    }
                    document.Add(asistenciaTable);
                    #endregion

                    document.Add(new Paragraph("Total Faltas: "+contador.ToString(), titleFont10));

                    document.Close();
                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                return bytes;
            }
            catch (Exception)
            {
                return bytes;
            }
        }
        #endregion

        #endregion

        #region Auxiliares
        public static PdfPTable TablaCabecera(string Titulo, List<Cabecera> lista)
        {
            PdfPTable tablaCabecera = null;
            PdfPCell cell = null;
            Phrase phrase = null;

            tablaCabecera = new PdfPTable(2);
            tablaCabecera.TotalWidth = 500f;
            tablaCabecera.LockedWidth = true;
            tablaCabecera.SetWidths(new float[] { 0.3f, 0.7f });

            //Logo
            cell = ImageCell("~/assets/images/logo-academico.png", 20f, PdfPCell.ALIGN_LEFT);
            tablaCabecera.AddCell(cell);

            ////Datos Cabecera
            phrase = new Phrase();
            phrase.Add(new Chunk(Titulo.ToUpper() + "\n\n", titleFont12));
            foreach (var item in lista)
            {
                phrase.Add(new Chunk(item.Titulo + item.Valor + "\n\n", titleFont8));
            }
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            tablaCabecera.AddCell(cell);


            return tablaCabecera;
        }
        public static PdfPTable TablaSeparador()
        {
            /*SEPARADOR*/
            float[] anchoColumna = { 30 };
            PdfPTable separador = new PdfPTable(1);
            separador.SetTotalWidth(anchoColumna);
            separador.DefaultCell.Border = PdfTable.NO_BORDER;
            separador.DefaultCell.FixedHeight = 10;
            separador.AddCell(new Phrase("", Font8));
            return separador;
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
        public DataTable ToDataTable<T>(List<T> items)

        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)

            {

                //Setting column names as Property names

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)

            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)

                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }
        #endregion
    }
    public class Cabecera
    {
        public string Titulo { get; set; }
        public string Valor { get; set; }
    }

}