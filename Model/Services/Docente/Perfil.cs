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

namespace Model.Services.Docente
{
    public class Perfil
    {
        public string ID_DOCENTE { get; set; }
        [Required]
        [DisplayName("Apellido Paterno")]
        public string APELLIDO_PATERNO_DOCENTE { get; set; }
        [Required]
        [DisplayName("Apellido Materno")]
        public string APELLIDO_MATERNO_DOCENTE { get; set; }
        [Required]
        [DisplayName("Primer Nombre")]
        public string PRIMER_NOMBRE_DOCENTE { get; set; }
        [Required]
        [DisplayName("Segundo Nombre")]
        public string SEGUNDO_NOMBRE_DOCENTE { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO_DOCENTE { get; set; }
        public Nullable<int> ID_ESTADO_CIVIL { get; set; }
        public Nullable<int> ID_PROVINCIA { get; set; }
        [Required]
        [DisplayName("Dirección")]
        public string DIRECCION { get; set; }
        public string TELEF_DOCENTE { get; set; }
        [Required]
        [DisplayName("Celular")]
        public string CEL_DOCENTE { get; set; }
        public string IMG_DOCENTE { get; set; }
        [Required]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo ingresado no válido")]
        public string CORREO_DOCENTE { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO_DOCENTE { get; set; }
        public ChangePassword ViewClave { get; set; }


        public Perfil ObtenerPerfil(string _ID_DOCENTE)
        {
            ChangePassword clave = new ChangePassword();
            Perfil _pefril = new Perfil();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _pefril = ctx.CAS_DOCENTE.Where(x => x.ID_DOCENTE == _ID_DOCENTE)
                             .Select(x => new Perfil
                             {
                                 ID_DOCENTE = x.ID_DOCENTE,
                                 APELLIDO_PATERNO_DOCENTE=x.APELLIDO_PATERNO_DOCENTE,
                                 APELLIDO_MATERNO_DOCENTE=x.APELLIDO_MATERNO_DOCENTE,
                                 PRIMER_NOMBRE_DOCENTE=x.PRIMER_NOMBRE_DOCENTE,
                                 SEGUNDO_NOMBRE_DOCENTE=x.SEGUNDO_NOMBRE_DOCENTE,
                                 FECHA_NACIMIENTO_DOCENTE=x.FECHA_NACIMIENTO_DOCENTE,
                                 DIRECCION=x.DIRECCION,
                                 TELEF_DOCENTE=x.TELEF_DOCENTE,
                                 CEL_DOCENTE=x.CEL_DOCENTE,
                                 IMG_DOCENTE=(string.IsNullOrEmpty(x.IMG_DOCENTE) ? "~/assets/images/usuario.png" : x.IMG_DOCENTE),
                                 CORREO_DOCENTE=x.CORREO_DOCENTE,
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
            CAS_DOCENTE docente = new CAS_DOCENTE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    docente = ctx.CAS_DOCENTE.Where(x => x.ID_DOCENTE == perfil.ID_DOCENTE).AsNoTracking().FirstOrDefault();
                    docente.APELLIDO_PATERNO_DOCENTE = perfil.APELLIDO_PATERNO_DOCENTE;
                    docente.APELLIDO_MATERNO_DOCENTE = perfil.APELLIDO_MATERNO_DOCENTE;
                    docente.PRIMER_NOMBRE_DOCENTE = perfil.PRIMER_NOMBRE_DOCENTE;
                    docente.SEGUNDO_NOMBRE_DOCENTE = perfil.SEGUNDO_NOMBRE_DOCENTE;
                    docente.CORREO_DOCENTE = perfil.CORREO_DOCENTE;
                    docente.CEL_DOCENTE = perfil.CEL_DOCENTE;
                    docente.DIRECCION = perfil.DIRECCION;
                    docente.IMG_DOCENTE = perfil.IMG_DOCENTE;
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
