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

namespace Model.Services.Estudiante
{
    public class Perfil
    {
        public string ID_ESTUDIANTE { get; set; }
        [Required]
        [DisplayName("Apellido Paterno")]
        public string APELLIDO_PATERNO_ESTUDIANTE { get; set; }
        [Required]
        [DisplayName("Apellido Materno")]
        public string APELLIDO_MATERNO_ESTUDIANTE { get; set; }
        [Required]
        [DisplayName("Primer Nombre")]
        public string PRIMER_NOMBRE_ESTUDIANTE { get; set; }
        [Required]
        [DisplayName("Segundo Nombre")]
        public string SEGUNDO_NOMBRE_ESTUDIANTE { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO_ESTUDIANTE { get; set; }
        public Nullable<int> ID_ESTADO_CIVIL { get; set; }
        public Nullable<int> ID_PROVINCIA { get; set; }
        [Required]
        [DisplayName("Dirección")]
        public string DIRECCION { get; set; }
        public string TELEF_ESTUDIANTE { get; set; }
        [Required]
        [DisplayName("Celular")]
        public string CEL_ESTUDIANTE { get; set; }
        public string IMG_ESTUDIANTE { get; set; }
        [Required]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo ingresado no válido")]
        public string CORREO_ESTUDIANTE { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO_ESTUDIANTE { get; set; }
        public ChangePassword ViewClave { get; set; }


        public Perfil ObtenerPerfil(string _ID_ESTUDIANTE)
        {
            ChangePassword clave = new ChangePassword();
            Perfil _pefril = new Perfil();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _pefril = ctx.CAS_ESTUDIANTE.Where(x => x.ID_ESTUDIANTE == _ID_ESTUDIANTE)
                             .Select(x => new Perfil
                             {
                                 ID_ESTUDIANTE = x.ID_ESTUDIANTE,
                                 APELLIDO_PATERNO_ESTUDIANTE=x.APELLIDO_PATERNO_ESTUDIANTE,
                                 APELLIDO_MATERNO_ESTUDIANTE=x.APELLIDO_MATERNO_ESTUDIANTE,
                                 PRIMER_NOMBRE_ESTUDIANTE=x.PRIMER_NOMBRE_ESTUDIANTE,
                                 SEGUNDO_NOMBRE_ESTUDIANTE=x.SEGUNDO_NOMBRE_ESTUDIANTE,
                                 FECHA_NACIMIENTO_ESTUDIANTE=x.FECHA_NACIMIENTO_ESTUDIANTE,
                                 DIRECCION=x.DIRECCION,
                                 TELEF_ESTUDIANTE=x.TELEF_ESTUDIANTE,
                                 CEL_ESTUDIANTE=x.CEL_ESTUDIANTE,
                                 IMG_ESTUDIANTE=(string.IsNullOrEmpty(x.IMG_ESTUDIANTE) ? "~/assets/images/usuario.png" : x.IMG_ESTUDIANTE),
                                 CORREO_ESTUDIANTE=x.CORREO_ESTUDIANTE,
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
            CAS_ESTUDIANTE docente = new CAS_ESTUDIANTE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    docente = ctx.CAS_ESTUDIANTE.Where(x => x.ID_ESTUDIANTE == perfil.ID_ESTUDIANTE).AsNoTracking().FirstOrDefault();
                    docente.APELLIDO_PATERNO_ESTUDIANTE = perfil.APELLIDO_PATERNO_ESTUDIANTE;
                    docente.APELLIDO_MATERNO_ESTUDIANTE = perfil.APELLIDO_MATERNO_ESTUDIANTE;
                    docente.PRIMER_NOMBRE_ESTUDIANTE = perfil.PRIMER_NOMBRE_ESTUDIANTE;
                    docente.SEGUNDO_NOMBRE_ESTUDIANTE = perfil.SEGUNDO_NOMBRE_ESTUDIANTE;
                    docente.CORREO_ESTUDIANTE = perfil.CORREO_ESTUDIANTE;
                    docente.CEL_ESTUDIANTE = perfil.CEL_ESTUDIANTE;
                    docente.DIRECCION = perfil.DIRECCION;
                    docente.IMG_ESTUDIANTE = perfil.IMG_ESTUDIANTE;
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
