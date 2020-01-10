using Model.Services.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Data;


namespace CAS_ADMIN.Models
{
    public class FileUpload
    {

        RutaAdjunto _ruta = new RutaAdjunto();
        CronogramaAdjunto _adjunto = new CronogramaAdjunto();
        public void GuardarArchivoRepositorio(HttpPostedFileBase file, int carpeta, int id_cronograma_detalle)
        {
            try
            {
                ObtenerRutaAdjunto_Result rutaAdjunt = new ObtenerRutaAdjunto_Result();
                rutaAdjunt = _ruta.ObtenerRuta(id_cronograma_detalle);

                CronogramaAdjunto adjuntoGuardar = new CronogramaAdjunto();

                string directorio;

                if (String.IsNullOrEmpty(rutaAdjunt.TEMA))
                {
                    directorio = "~/Repositorio/" + rutaAdjunt.DESCRIPCION_PERIODO + "/" + rutaAdjunt.COD_CARRERA + "/" + rutaAdjunt.DIA;
                }
                else
                {
                    directorio = "~/Repositorio/" + rutaAdjunt.DESCRIPCION_PERIODO + "/" + rutaAdjunt.COD_CARRERA + "/" + rutaAdjunt.TEMA + "/" + rutaAdjunt.DIA;
                }
                

                string verificar = HttpContext.Current.Server.MapPath(directorio);
                if (!Directory.Exists(verificar))
                {
                    Directory.CreateDirectory(verificar);
                }

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath(directorio), fileName);
                string tipo = Path.GetExtension(file.FileName);

                long fileSizeInBytes = file.ContentLength;
                string fileSize = string.Format("{0:0.00} MB", (fileSizeInBytes / 1024f) / 1024f);

                string icon = "";
                switch (tipo)
                {
                    case ".gif":
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        icon = "fa fa-file-image-o";
                        break;
                    case ".odt":
                    case ".doc":
                    case ".docx":
                        icon = "fa fa-file-word-o";
                        break;
                    case ".odp":
                    case ".ppt":
                        icon = "fa fa-file-powerpoint-o";
                        break;
                    case ".ods":
                    case ".xls":
                        icon = "fa fa-file-excel-o";
                        break;
                    case ".pdf":
                        icon = "fa fa-file-pdf-o";
                        break;
                    case ".cda":
                    case ".mp3":
                    case ".ogg":
                    case ".wav":
                        icon = "fa fa-file-sound-o";
                        break;
                    case ".avi":
                    case ".mpg":
                    case ".mpeg":
                    case ".wmv":
                    case ".mov":
                    case ".ogv":
                    case ".mp4":
                        icon = "zmdi zmdi-collection-video";
                        break;
                    case ".rar":
                    case ".zip":
                    case ".tar":
                    case ".tgz":
                        icon = "fa fa-file-zip-o";
                        break;
                    default:
                        icon = "zmdi zmdi-attachment";
                        break;
                }
                file.SaveAs(path);

                adjuntoGuardar.ID_CRONOGRAMA_DETALLE = id_cronograma_detalle;
                adjuntoGuardar.RUTA_ADJUNTO = directorio+"/"+fileName;
                adjuntoGuardar.ICONO_ADJUNTO = icon;
                adjuntoGuardar.PESO_ADJUNTO = fileSize;
                adjuntoGuardar.NOMBRE_ADJUNTO = fileName;
                adjuntoGuardar.ID_CARPETA = carpeta;
                _adjunto.GuardarAdjunto(adjuntoGuardar);


            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

    }
}