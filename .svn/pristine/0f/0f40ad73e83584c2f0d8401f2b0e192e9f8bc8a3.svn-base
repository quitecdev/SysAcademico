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
   public class ForgotPassword
    {
        public string ID_USUARIO { get; set; }
        [Required(ErrorMessage = "Ingrese su Username o Correo")]
        public string COD_USUARIO { get; set; }

        public bool ValidarUsurio(ForgotPassword recuperar)
        {
            bool exite = false;
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    //exite = ctx.CAS_USUARIO.Where(x => x.USUARIO_CODIGO.Trim().ToLower() == login.USUARIO_CODIGO.Trim().ToLower() && x.USUARIO_CLAVE.Trim().ToLower() == login.USUARIO_CLAVE.Trim().ToLower() && x.USUARIO_ESTADO == 1).Any(); //validating the user name in tblLogin table whether the user name is exist or not  
                    exite = (from usuario in ctx.CAS_USUARIO
                             join rol in ctx.CAS_USUARIO_ROL on usuario.ID_USUARIO equals rol.ID_USUARIO
                             join docent in ctx.CAS_DOCENTE on usuario.ID_USUARIO equals docent.ID_DOCENTE
                             where usuario.COD_USUARIO.Trim() == recuperar.COD_USUARIO.Trim()
                                   || docent.CORREO_DOCENTE.Trim() == recuperar.COD_USUARIO.Trim()
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

        public ForgotPassword Obtener(ForgotPassword login)
        {
            ForgotPassword _loginCredentials = new ForgotPassword();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _loginCredentials = (from usuario in ctx.CAS_USUARIO
                                         join rol in ctx.CAS_USUARIO_ROL on usuario.ID_USUARIO equals rol.ID_USUARIO
                                         join docent in ctx.CAS_DOCENTE on usuario.ID_USUARIO equals docent.ID_DOCENTE
                                         where usuario.COD_USUARIO.Trim() == login.COD_USUARIO.Trim()
                                               || docent.CORREO_DOCENTE.Trim() == login.COD_USUARIO.Trim()
                                         && rol.ID_ROL == 7
                                         select new ForgotPassword
                                         {
                                             ID_USUARIO = usuario.ID_USUARIO,
                                             COD_USUARIO = usuario.COD_USUARIO,
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

        public void Enviar(ForgotPassword login)
        {
            try
            {
                using (var ctx=new CAS_DataEntities())
                {
                    ctx.SP_NotificadorEnviaClave(login.ID_USUARIO);
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }
    }
}
