using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using Model.Services.Estudiante;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web;
using System.IO;
using System.Security.Cryptography;

namespace Model.Services.Estudiante
{  
    public class TareaDetalle
    {
        public int ID_ESTUDIANTE_TAREA { get; set; }
        public Nullable<int> ID_TAREA { get; set; }
        public string ID_ESTUDIANTE { get; set; }

        [Display(Name = "Archivo")]
        [Required]
        public HttpPostedFileBase ADJUNTO_TAREA { get; set; }
        public Nullable<System.DateTime> FECHA_TAREA { get; set; }
        public Nullable<decimal> NOTA_TAREA { get; set; }
        public string ADJUNTO_NOMBRE { get; set; }
        [Display(Name = "Comentario")]
        [AllowHtml]
        public string OBSERVACION_TAREA { get; set; }
        public string TEMA_TAREA { get; set; }
        public string DESCRIPCION_TAREA { get; set; }
        public List<CAS_TAREA_ADJUNTO> Adjuntos { get; set; }


        public TareaDetalle ObtenerDetalleTarea(int ID_ESTUDIANTE_TAREA)
        {
            TareaDetalle detalle = new TareaDetalle();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    detalle = (from tareaDetalle in ctx.CAS_ESTUDIANTE_TAREA
                               join tarea in ctx.CAS_TAREAS on tareaDetalle.ID_TAREA equals tarea.ID_TAREA
                               where tareaDetalle.ID_ESTUDIANTE_TAREA == ID_ESTUDIANTE_TAREA
                               select new TareaDetalle()
                               {
                                   ID_ESTUDIANTE_TAREA= tareaDetalle.ID_ESTUDIANTE_TAREA,
                                   ID_TAREA = tarea.ID_TAREA,
                                   TEMA_TAREA = tarea.TEMA_TAREA,
                                   DESCRIPCION_TAREA = tarea.DESCRIPCION_TAREA,
                                   FECHA_TAREA=tarea.FECHA_FIN_TAREA,
                                   Adjuntos = ctx.CAS_TAREA_ADJUNTO.Where(x=>x.ID_TAREA==tarea.ID_TAREA).ToList()
                               }
                             ).FirstOrDefault();
                }
                return detalle;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return detalle;
            }
        }

        public void GuardarDetalle(TareaDetalle tarea)
        {
            CAS_ESTUDIANTE_TAREA _tarea = new CAS_ESTUDIANTE_TAREA();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _tarea = ctx.CAS_ESTUDIANTE_TAREA.Where(x => x.ID_ESTUDIANTE_TAREA == tarea.ID_ESTUDIANTE_TAREA).AsNoTracking().FirstOrDefault();

                    if (tarea.ADJUNTO_TAREA != null && tarea.ADJUNTO_TAREA.ContentLength > 0)
                    {
                        string directorio = "~/Adjuntos/" + MD5(_tarea.ID_ESTUDIANTE);

                        string verificar = HttpContext.Current.Server.MapPath(directorio);
                        if (!Directory.Exists(verificar))
                        {
                            Directory.CreateDirectory(verificar);
                        }

                        var fileName = Path.GetFileName(tarea.ADJUNTO_TAREA.FileName);
                        var path = Path.Combine(HttpContext.Current.Server.MapPath(directorio), fileName);
                        tarea.ADJUNTO_TAREA.SaveAs(path);

                        _tarea.ADJUNTO_TAREA= directorio + "/" + fileName;
                        _tarea.ADJUNTO_NOMBRE = fileName;
                        _tarea.FECHA_TAREA = DateTime.Now;
                        _tarea.OBSERVACION_TAREA = _tarea.OBSERVACION_TAREA;

                        ctx.Entry(_tarea).State = EntityState.Modified;

                        ctx.SaveChanges();
                    }


                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        private string MD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }

    }
}
