using Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AfsEncripta;

namespace Model.Services.Admin
{
    public class EventoRegistro
    {
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EVENTO_REGISTRO_CORREO { get; set; }
        [Display(Name = "Nombres")]
        [Required]
        public string EVENTO_REGISTRO_NOMBRES { get; set; }
        [Display(Name = "Apellidos")]
        [Required]
        public string EVENTO_REGISTRO_APELLIDOS { get; set; }
        [Display(Name = "Movil")]
        [Required]
        public string EVENTO_REGISTRO_MOVIL { get; set; }

        //[Required]
        //[Display(Name = "Campus")]
        //public Nullable<int> ID_SEDE { get; set; }

        //[Required]
        //[Display(Name = "Hora")]
        //public Nullable<int> ID_EVENTO_HORA { get; set; }

        //[Required]
        //[Display(Name = "Fecha")]
        //public Nullable<System.DateTime> FECHA_EVENTO { get; set; }

        //[Required]
        //[Display(Name = "Especialidad")]
        //public int ID_EVENTO { get; set; }

        public List<CAS_EVENTO_HORA> ObtenerHora()
        {
            List<CAS_EVENTO_HORA> sede = new List<CAS_EVENTO_HORA>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    sede = ctx.CAS_EVENTO_HORA.ToList();
                    return sede;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return sede;
            }
        }


        public List<HORA> ObtenerFecha(int _ID_SEDE, string _ID_HORA)
        {
            List<HORA> hora = new List<HORA>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    var a = (from evento in ctx.CAS_EVENTO
                             where evento.ID_SEDE == _ID_SEDE && evento.ID_HORA == _ID_HORA
                             select evento.FECHA_EVENTO.ToString()
                            ).ToList().Distinct();

                    foreach (var item in a)
                    {
                        hora.Add(new HORA { FECHA_EVENTO = item });
                    }
                    return hora;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return hora;
            }
        }

        public List<EVENTO> ObtenerEvento(int _ID_SEDE, string _ID_HORA, string _FECHA_EVENTO)
        {
            List<EVENTO> hora = new List<EVENTO>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    var a = (from evento in ctx.CAS_EVENTO
                             where evento.ID_SEDE == _ID_SEDE && evento.ID_HORA == _ID_HORA && evento.FECHA_EVENTO.ToString() == _FECHA_EVENTO
                             select evento
                            ).ToList().Distinct();

                    foreach (var item in a)
                    {
                        hora.Add(new EVENTO { ID_EVENTO = item.ID_EVENTO, EVENTO_DESCRIPCIÓN = item.EVENTO_DESCRIPCIÓN });
                    }
                    return hora;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return hora;
            }
        }



        public string GuardarDetalle(EventoRegistro _evento)
        {
            Encripta _en = new Encripta();
            CAS_EVENTO_REGISTRO _registro = new CAS_EVENTO_REGISTRO();
            CAS_EVENTO_REGISTRO_DETALLE _detalle = new CAS_EVENTO_REGISTRO_DETALLE();
            int id = 0;
            string bar_code = _en.HashString(_evento.EVENTO_REGISTRO_CORREO + "25");
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    var foo = ctx.CAS_EVENTO_REGISTRO.Where(v => v.EVENTO_REGISTRO_CORREO == _evento.EVENTO_REGISTRO_CORREO).Any();
                    if (!foo)
                    {
                        _registro.EVENTO_REGISTRO_APELLIDOS = _evento.EVENTO_REGISTRO_APELLIDOS;
                        _registro.EVENTO_REGISTRO_NOMBRES = _evento.EVENTO_REGISTRO_NOMBRES;
                        _registro.EVENTO_REGISTRO_CORREO = _evento.EVENTO_REGISTRO_CORREO;
                        _registro.EVENTO_REGISTRO_MOVIL = _evento.EVENTO_REGISTRO_MOVIL;
                        ctx.Entry(_registro).State = EntityState.Added;
                        ctx.SaveChanges();
                    }

                    var foo2 = ctx.CAS_EVENTO_REGISTRO_DETALLE.Where(v => v.EVENTO_REGISTRO_CORREO == _evento.EVENTO_REGISTRO_CORREO && v.ID_EVENTO == 25).Any();
                    if (!foo2)
                    {



                        System.IO.MemoryStream stream = new System.IO.MemoryStream();
                        BarcodeLib.Barcode Codigobar = new BarcodeLib.Barcode();
                        Codigobar.IncludeLabel = true;
                        System.Drawing.Image img = Codigobar.Encode(BarcodeLib.TYPE.CODE128, bar_code.ToString(), Color.Black, Color.White, 550, 100);
                        img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        var image_code = "data:image/png;base64," + Convert.ToBase64String(stream.ToArray(), 0, stream.ToArray().Length);


                        _detalle.EVENTO_REGISTRO_CORREO = _evento.EVENTO_REGISTRO_CORREO;
                        _detalle.ID_EVENTO = 25;
                        _detalle.CODE_BAR = bar_code;
                        _detalle.IMAGE_CODE_BAR = image_code;
                        _detalle.ESTADO = false;
                        ctx.Entry(_detalle).State = EntityState.Added;
                        ctx.SaveChanges();
                        id = _detalle.ID_EVENTO_REGISTRO_DETALLE;
                        if (id != 0)
                        {
                            var a = ctx.SP_NotificadorEvento(id);
                            return bar_code;
                        }
                        return null;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return bar_code;
            }
        }

    }

    public class HORA
    {
        public string FECHA_EVENTO { get; set; }
    }

    public class EVENTO
    {
        public int ID_EVENTO { get; set; }
        public string EVENTO_DESCRIPCIÓN { get; set; }
    }

}
