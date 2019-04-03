using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model.Data;

namespace Model.Services.Admin
{
    public class Login
    {

        public string ID_USUARIO { get; set; }

        [Required(ErrorMessage = "Ingrese su Username")]
        public string COD_USUARIO { get; set; }
        [Required(ErrorMessage = "Ingrese su Password")]
        [DataType(DataType.Password)]
        public string CLAVE_USUARIO { get; set; }
        public bool RECORDAR { get; set; }
        public int ID_ROL { get; set; }
        public string DESCRIPCION_ROL { get; set; }
        public Nullable<int> MODIFICAR_CLAVE { get; set; }
        public string IMAGEN { get; set; }

        public bool ValidarUsurio(Login login)
        {
            bool exite = false;
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    //exite = ctx.CAS_USUARIO.Where(x => x.USUARIO_CODIGO.Trim().ToLower() == login.USUARIO_CODIGO.Trim().ToLower() && x.USUARIO_CLAVE.Trim().ToLower() == login.USUARIO_CLAVE.Trim().ToLower() && x.USUARIO_ESTADO == 1).Any(); //validating the user name in tblLogin table whether the user name is exist or not  
                    exite = (from usuario in ctx.CAS_USUARIO
                             join rol in ctx.CAS_USUARIO_ROL on usuario.ID_USUARIO equals rol.ID_USUARIO
                             where usuario.COD_USUARIO.Trim() == login.COD_USUARIO.Trim() && usuario.CLAVE_USUARIO.Trim() == login.CLAVE_USUARIO.Trim() && rol.ID_ROL == 1 || rol.ID_ROL==5
                             select new
                             {
                                 ID_USUARIO = usuario.ID_USUARIO,
                                 COD_USUARIO = usuario.COD_USUARIO

                             }).ToList()
                             .Select(x => new CAS_USUARIO()
                             {
                                 ID_USUARIO = x.ID_USUARIO,
                                 COD_USUARIO = x.COD_USUARIO
                             }).Any();
                }
                return exite;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return exite;
            }
        }

        public Login Obtener(Login login)
        {
            Login _loginCredentials = new Login();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _loginCredentials = (from usuario in ctx.CAS_USUARIO.Where(x => x.COD_USUARIO == login.COD_USUARIO && x.CLAVE_USUARIO == login.CLAVE_USUARIO)
                                         join rolUsuario in ctx.CAS_USUARIO_ROL on usuario.ID_USUARIO equals rolUsuario.ID_USUARIO
                                         join rol in ctx.CAS_ROL on rolUsuario.ID_ROL equals rol.ID_ROL
                                         join personal in ctx.CAS_PERSONAL on usuario.ID_USUARIO equals personal.ID_PERSONAL
                                         select new Login
                                         {
                                             ID_USUARIO = usuario.ID_USUARIO,
                                             COD_USUARIO = usuario.COD_USUARIO,
                                             CLAVE_USUARIO = usuario.CLAVE_USUARIO,
                                             ID_ROL = rol.ID_ROL,
                                             DESCRIPCION_ROL = rol.DESCRIPCION_ROL,
                                             MODIFICAR_CLAVE=usuario.MODIFICAR_CLAVE,
                                             IMAGEN=personal.IMG_PERSONAL
                                         }

                            ).FirstOrDefault();
                }
                return _loginCredentials;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _loginCredentials;
            }
        }
    }
}
