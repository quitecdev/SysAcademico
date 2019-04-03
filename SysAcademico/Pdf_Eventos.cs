using System;
using System.Collections.Generic;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SysAcademico
{
    public class Pdf_Eventos : PdfPageEventHelper
    {
        public PdfWriter PdfW = null;
        public Rectangle FormatoPagina = null;
        public string RutaPlantilla = string.Empty;

        public override void OnStartPage(PdfWriter writer, Document document)
        {



            ////Configuro La Pagina
            //Rectangle pageSize = new Rectangle(FormatoPagina);
            //document.SetPageSize(pageSize);

            //Agrego la Plantilla
            PdfReader readerTemp = new PdfReader(RutaPlantilla);
            PdfImportedPage plantilla = null;
            plantilla = PdfW.GetImportedPage(readerTemp, 1);
            PdfW.DirectContent.AddTemplate(plantilla, 1f, 0, 0, 1f, 0, 0);

            base.OnStartPage(writer, document);

        }
    }
}