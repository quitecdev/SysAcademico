using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model.Data;

namespace Model.Services.Docente
{
    public class ChangePassword
    {
        public string ID_USUARIO { get; set; }
        [Required(ErrorMessage = "Ingrese su Contraseñas")]
        [Display(Name = "Contraseña")]
        [StringLength(100, ErrorMessage = "Su {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string CLAVE_USUARIO { get; set; }
        [Compare("CLAVE_USUARIO",ErrorMessage = "Contraseñas ingresadas no coinciden")]
        [Required(ErrorMessage = "Ingrese su Contraseñas")]
        [DataType(DataType.Password)]
        public string CLAVE_VALIDAR { get; set; }

        public void CambiarContraseña(ChangePassword cambiar)
        {
            CAS_USUARIO usuario = new CAS_USUARIO();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    usuario=ctx.CAS_USUARIO.Where(x => x.ID_USUARIO == cambiar.ID_USUARIO).FirstOrDefault();
                    usuario.CLAVE_USUARIO = cambiar.CLAVE_USUARIO;
                    usuario.MODIFICAR_CLAVE = 1;
                    ctx.Entry(usuario).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }
    }
}
