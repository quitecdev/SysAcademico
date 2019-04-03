using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class Usuario
    {
        public string ID_USUARIO { get; set; }
        public string COD_USUARIO { get; set; }
        public string CLAVE_USUARIO { get; set; }
        public Nullable<int> ESTADO_USUARIO { get; set; }
        public Nullable<int> MODIFICAR_CLAVE { get; set; }

        public void ModificarClave(string _ID_USUARIO)
        {
            CAS_USUARIO usuario = new CAS_USUARIO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    usuario = ctx.CAS_USUARIO.Where(v => v.ID_USUARIO == _ID_USUARIO).AsNoTracking().FirstOrDefault();
                    usuario.MODIFICAR_CLAVE = 0;
                    usuario.CLAVE_USUARIO = CrearPassword(8);
                    ctx.Entry(usuario).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }
    }
}
