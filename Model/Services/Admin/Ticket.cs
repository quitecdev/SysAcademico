using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;

namespace Model.Services.Admin
{
    public class Ticket
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha { get; set; }
        public string Image { get; set; }
        public string cod { get; set; }


        public Ticket ObtenerDatos(string cod)
        {
            Ticket ticket = new Ticket();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ticket = (from detalle in ctx.CAS_EVENTO_REGISTRO_DETALLE
                              join registro in ctx.CAS_EVENTO_REGISTRO on detalle.EVENTO_REGISTRO_CORREO equals registro.EVENTO_REGISTRO_CORREO
                              join evento in ctx.CAS_EVENTO on detalle.ID_EVENTO equals evento.ID_EVENTO
                              where detalle.CODE_BAR == cod
                              select new Ticket()
                              {
                                  Nombre=registro.EVENTO_REGISTRO_NOMBRES.ToUpper(),
                                  Apellido=registro.EVENTO_REGISTRO_APELLIDOS.ToUpper(),
                                  Fecha=evento.FECHA_EVENTO.ToString(),
                                  Image=detalle.IMAGE_CODE_BAR,
                                  cod=detalle.CODE_BAR
                              }
                            ).FirstOrDefault();
                }
                return ticket;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return ticket;
            }

        }
    }

}
