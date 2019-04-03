using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;
using System.Web;

namespace Model.Services.Admin
{
    public class Perfil
    {
        public string ID_PERSONAL { get; set; }
        [Required]
        [DisplayName("Apellido Paterno")]
        public string APELLIDO_PATERNO_PERSONAL { get; set; }
        [Required]
        [DisplayName("Apellido Materno")]
        public string APELLIDO_MATERNO_PERSONAL { get; set; }
        [Required]
        [DisplayName("Primer Nombre")]
        public string PRIMER_NOMBRE_PERSONAL { get; set; }
        [Required]
        [DisplayName("Segundo Nombre")]
        public string SEGUNDO_NOMBRE_PERSONAL { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO_PERSONAL { get; set; }
        public Nullable<int> ID_ESTADO_CIVIL { get; set; }
        public Nullable<int> ID_PROVINCIA { get; set; }
        [Required]
        [DisplayName("Dirección")]
        public string DIRECCION { get; set; }
        public string TELEF_PERSONAL { get; set; }
        [Required]
        [DisplayName("Celular")]
        public string CEL_PERSONAL { get; set; }
        public string IMG_PERSONAL { get; set; }
        [Required]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo ingresado no válido")]
        public string CORREO_PERSONAL { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO_PERSONAL { get; set; }
        public ChangePassword ViewClave { get; set; }


        public Perfil ObtenerPerfil(string _ID_PERSONAL)
        {
            ChangePassword clave = new ChangePassword();
            Perfil _pefril = new Perfil();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _pefril = ctx.CAS_PERSONAL.Where(x => x.ID_PERSONAL == _ID_PERSONAL)
                             .Select(x => new Perfil
                             {
                                 ID_PERSONAL = x.ID_PERSONAL,
                                 APELLIDO_PATERNO_PERSONAL=x.APELLIDO_PATERNO_PERSONAL,
                                 APELLIDO_MATERNO_PERSONAL=x.APELLIDO_MATERNO_PERSONAL,
                                 PRIMER_NOMBRE_PERSONAL=x.PRIMER_NOMBRE_PERSONAL,
                                 SEGUNDO_NOMBRE_PERSONAL=x.SEGUNDO_NOMBRE_PERSONAL,
                                 FECHA_NACIMIENTO_PERSONAL=x.FECHA_NACIMIENTO_PERSONAL,
                                 DIRECCION=x.DIRECCION,
                                 TELEF_PERSONAL=x.TELEF_PERSONAL,
                                 CEL_PERSONAL=x.CEL_PERSONAL,
                                 IMG_PERSONAL=(string.IsNullOrEmpty(x.IMG_PERSONAL) ? "~/assets/images/usuario.png" : x.IMG_PERSONAL),
                                 CORREO_PERSONAL=x.CORREO_PERSONAL,
                             }).FirstOrDefault();
                }

                _pefril.ViewClave = clave;
                return _pefril;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _pefril;
            }
        }

        public void GuardarPerfil(Perfil perfil)
        {
            CAS_PERSONAL docente = new CAS_PERSONAL();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    docente = ctx.CAS_PERSONAL.Where(x => x.ID_PERSONAL == perfil.ID_PERSONAL).AsNoTracking().FirstOrDefault();
                    docente.APELLIDO_PATERNO_PERSONAL = perfil.APELLIDO_PATERNO_PERSONAL;
                    docente.APELLIDO_MATERNO_PERSONAL = perfil.APELLIDO_MATERNO_PERSONAL;
                    docente.PRIMER_NOMBRE_PERSONAL = perfil.PRIMER_NOMBRE_PERSONAL;
                    docente.SEGUNDO_NOMBRE_PERSONAL = perfil.SEGUNDO_NOMBRE_PERSONAL;
                    docente.CORREO_PERSONAL = perfil.CORREO_PERSONAL;
                    docente.CEL_PERSONAL = perfil.CEL_PERSONAL;
                    docente.DIRECCION = perfil.DIRECCION;
                    docente.IMG_PERSONAL = perfil.IMG_PERSONAL;
                    ctx.Entry(docente).State = EntityState.Modified;
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
