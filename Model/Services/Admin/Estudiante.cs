using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Model.Services.Admin
{
    public class Estudiante
    {
        [Display(Name = "Documento de Identidad")]
        [Required]
        public string ID_ESTUDIANTE { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        public string APELLIDO_PATERNO_ESTUDIANTE { get; set; }

        [Display(Name = "Apellido Materno")]
        public string APELLIDO_MATERNO_ESTUDIANTE { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required]
        public string PRIMER_NOMBRE_ESTUDIANTE { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SEGUNDO_NOMBRE_ESTUDIANTE { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO_ESTUDIANTE { get; set; }
        public Nullable<int> ID_ESTADO_CIVIL { get; set; }
        public Nullable<int> ID_PROVINCIA { get; set; }
        public string DIRECCION { get; set; }
        public string TELEF_ESTUDIANTE { get; set; }

        [Display(Name = "Celular")]
        [Required]
        public string CEL_ESTUDIANTE { get; set; }
        public string IMG_ESTUDIANTE { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string CORREO_ESTUDIANTE { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO_ESTUDIANTE { get; set; }

        public string COD_USUARIO { get; set; }
        public string CLAVE_USUARIO { get; set; }
        public Nullable<int> MODIFICAR_CLAVE { get; set; }

        public List<Estudiante> ObtenerEstudiantes()
        {
            List<Estudiante> _estudiantes = new List<Estudiante>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _estudiantes = (from estudiante in ctx.CAS_ESTUDIANTE
                                    join usuario in ctx.CAS_USUARIO on estudiante.ID_ESTUDIANTE equals usuario.ID_USUARIO
                                    select new Estudiante
                                    {
                                        ID_ESTUDIANTE = estudiante.ID_ESTUDIANTE,
                                        APELLIDO_PATERNO_ESTUDIANTE = estudiante.APELLIDO_PATERNO_ESTUDIANTE,
                                        APELLIDO_MATERNO_ESTUDIANTE = estudiante.APELLIDO_MATERNO_ESTUDIANTE,
                                        PRIMER_NOMBRE_ESTUDIANTE = estudiante.PRIMER_NOMBRE_ESTUDIANTE,
                                        SEGUNDO_NOMBRE_ESTUDIANTE = estudiante.SEGUNDO_NOMBRE_ESTUDIANTE,
                                        FECHA_NACIMIENTO_ESTUDIANTE = estudiante.FECHA_NACIMIENTO_ESTUDIANTE,
                                        ID_ESTADO_CIVIL = estudiante.ID_ESTADO_CIVIL,
                                        ID_PROVINCIA = estudiante.ID_PROVINCIA,
                                        DIRECCION = estudiante.DIRECCION,
                                        TELEF_ESTUDIANTE = estudiante.TELEF_ESTUDIANTE,
                                        CEL_ESTUDIANTE = estudiante.CEL_ESTUDIANTE,
                                        IMG_ESTUDIANTE = estudiante.IMG_ESTUDIANTE,
                                        CORREO_ESTUDIANTE = estudiante.CORREO_ESTUDIANTE,
                                        FECHA_INGRESO_ESTUDIANTE = estudiante.FECHA_INGRESO_ESTUDIANTE,
                                        COD_USUARIO=usuario.COD_USUARIO,
                                        CLAVE_USUARIO = usuario.CLAVE_USUARIO,
                                        MODIFICAR_CLAVE = usuario.MODIFICAR_CLAVE
                                    }).ToList();
                }

                return _estudiantes;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _estudiantes;
            }
        }

        public Estudiante ObtenerEstudiante(string _ID_ESTUDIANTE)
        {
            Estudiante _estudiantes = new Estudiante();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _estudiantes = ctx.CAS_ESTUDIANTE.Where(x => x.ID_ESTUDIANTE == _ID_ESTUDIANTE)
                                   .Select(x => new Estudiante
                                   {
                                       ID_ESTUDIANTE = x.ID_ESTUDIANTE,
                                       APELLIDO_PATERNO_ESTUDIANTE = x.APELLIDO_PATERNO_ESTUDIANTE,
                                       APELLIDO_MATERNO_ESTUDIANTE = x.APELLIDO_MATERNO_ESTUDIANTE,
                                       PRIMER_NOMBRE_ESTUDIANTE = x.PRIMER_NOMBRE_ESTUDIANTE,
                                       SEGUNDO_NOMBRE_ESTUDIANTE = x.SEGUNDO_NOMBRE_ESTUDIANTE,
                                       FECHA_NACIMIENTO_ESTUDIANTE = x.FECHA_NACIMIENTO_ESTUDIANTE,
                                       ID_ESTADO_CIVIL = x.ID_ESTADO_CIVIL,
                                       ID_PROVINCIA = x.ID_PROVINCIA,
                                       DIRECCION = x.DIRECCION,
                                       TELEF_ESTUDIANTE = x.TELEF_ESTUDIANTE,
                                       CEL_ESTUDIANTE = x.CEL_ESTUDIANTE,
                                       IMG_ESTUDIANTE = x.IMG_ESTUDIANTE,
                                       CORREO_ESTUDIANTE = x.CORREO_ESTUDIANTE,
                                       FECHA_INGRESO_ESTUDIANTE = x.FECHA_INGRESO_ESTUDIANTE,
                                   }).FirstOrDefault();
                }

                return _estudiantes;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _estudiantes;
            }
        }



        public void GuardarEstudiante(Inscipcion inscripcion)
        {
            CAS_ESTUDIANTE _estudiante = new CAS_ESTUDIANTE();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    var foo = ctx.CAS_ESTUDIANTE.Where(v => v.ID_ESTUDIANTE == inscripcion.ID_INSCRIP).AsNoTracking().ToList();
                    var fooCount = foo.Count();
                    if (fooCount > 0)
                    {
                        _estudiante = ctx.CAS_ESTUDIANTE.Where(v => v.ID_ESTUDIANTE == inscripcion.ID_INSCRIP).FirstOrDefault();
                        _estudiante.ID_ESTUDIANTE = inscripcion.ID_INSCRIP;
                        _estudiante.APELLIDO_PATERNO_ESTUDIANTE = inscripcion.APELLIDO_PATERNO_INSCRIP;
                        _estudiante.APELLIDO_MATERNO_ESTUDIANTE = inscripcion.APELLIDO_MATERNO_INSCRIP != null ? inscripcion.APELLIDO_MATERNO_INSCRIP.ToUpper() : inscripcion.APELLIDO_MATERNO_INSCRIP;
                        _estudiante.PRIMER_NOMBRE_ESTUDIANTE = inscripcion.PRIMER_NOMBRE_INSCRIP;
                        _estudiante.SEGUNDO_NOMBRE_ESTUDIANTE = inscripcion.SEGUNDO_NOMBRE_INSCRIP != null ? inscripcion.SEGUNDO_NOMBRE_INSCRIP.ToUpper() : inscripcion.SEGUNDO_NOMBRE_INSCRIP;
                        _estudiante.FECHA_NACIMIENTO_ESTUDIANTE = inscripcion.FECHA_NACIMIENTO_INSCRIP;
                        _estudiante.ID_ESTADO_CIVIL = inscripcion.ID_ESTADO_CIVIL;
                        _estudiante.ID_PROVINCIA = inscripcion.ID_CIUDAD;
                        _estudiante.DIRECCION = inscripcion.DIRECCION;
                        _estudiante.TELEF_ESTUDIANTE = inscripcion.TELEF_INSCRIP;
                        _estudiante.CEL_ESTUDIANTE = inscripcion.CEL_INSCRIP;
                        _estudiante.IMG_ESTUDIANTE = _estudiante.IMG_ESTUDIANTE;
                        _estudiante.CORREO_ESTUDIANTE = inscripcion.CORREO;

                        ctx.Entry(_estudiante).State = EntityState.Modified;
                    }
                    else
                    {
                        _estudiante.ID_ESTUDIANTE = inscripcion.ID_INSCRIP;
                        _estudiante.APELLIDO_PATERNO_ESTUDIANTE = inscripcion.APELLIDO_PATERNO_INSCRIP;
                        _estudiante.APELLIDO_MATERNO_ESTUDIANTE = inscripcion.APELLIDO_MATERNO_INSCRIP != null ? inscripcion.APELLIDO_MATERNO_INSCRIP.ToUpper() : inscripcion.APELLIDO_MATERNO_INSCRIP;
                        _estudiante.PRIMER_NOMBRE_ESTUDIANTE = inscripcion.PRIMER_NOMBRE_INSCRIP;
                        _estudiante.SEGUNDO_NOMBRE_ESTUDIANTE = inscripcion.SEGUNDO_NOMBRE_INSCRIP != null ? inscripcion.SEGUNDO_NOMBRE_INSCRIP.ToUpper() : inscripcion.SEGUNDO_NOMBRE_INSCRIP;
                        _estudiante.FECHA_NACIMIENTO_ESTUDIANTE = inscripcion.FECHA_NACIMIENTO_INSCRIP;
                        _estudiante.ID_ESTADO_CIVIL = inscripcion.ID_ESTADO_CIVIL;
                        _estudiante.ID_PROVINCIA = inscripcion.ID_CIUDAD;
                        _estudiante.DIRECCION = inscripcion.DIRECCION;
                        _estudiante.TELEF_ESTUDIANTE = inscripcion.TELEF_INSCRIP;
                        _estudiante.CEL_ESTUDIANTE = inscripcion.CEL_INSCRIP;
                        _estudiante.CORREO_ESTUDIANTE = inscripcion.CORREO;

                        ctx.Entry(_estudiante).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public void GuardarEstudiante(Estudiante _estudiante)
        {
            CAS_ESTUDIANTE estudiante = new CAS_ESTUDIANTE();
            CAS_INSCRIPCION inscripcion = new CAS_INSCRIPCION();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    estudiante = ctx.CAS_ESTUDIANTE.Where(x => x.ID_ESTUDIANTE == _estudiante.ID_ESTUDIANTE).AsNoTracking().FirstOrDefault();
                    estudiante.APELLIDO_PATERNO_ESTUDIANTE = _estudiante.APELLIDO_PATERNO_ESTUDIANTE;
                    estudiante.APELLIDO_MATERNO_ESTUDIANTE = _estudiante.APELLIDO_MATERNO_ESTUDIANTE;
                    estudiante.PRIMER_NOMBRE_ESTUDIANTE = _estudiante.PRIMER_NOMBRE_ESTUDIANTE;
                    estudiante.SEGUNDO_NOMBRE_ESTUDIANTE = _estudiante.SEGUNDO_NOMBRE_ESTUDIANTE;
                    estudiante.CEL_ESTUDIANTE = _estudiante.CEL_ESTUDIANTE;
                    estudiante.CORREO_ESTUDIANTE = _estudiante.CORREO_ESTUDIANTE;
                    ctx.Entry(estudiante).State = EntityState.Modified;

                    inscripcion = ctx.CAS_INSCRIPCION.Where(x => x.ID_INSCRIP == _estudiante.ID_ESTUDIANTE).AsNoTracking().FirstOrDefault();
                    inscripcion.APELLIDO_PATERNO_INSCRIP = _estudiante.APELLIDO_PATERNO_ESTUDIANTE;
                    inscripcion.APELLIDO_MATERNO_INSCRIP = _estudiante.APELLIDO_MATERNO_ESTUDIANTE;
                    inscripcion.PRIMER_NOMBRE_INSCRIP = _estudiante.PRIMER_NOMBRE_ESTUDIANTE;
                    inscripcion.SEGUNDO_NOMBRE_INSCRIP = _estudiante.SEGUNDO_NOMBRE_ESTUDIANTE;
                    inscripcion.CEL_INSCRIP = _estudiante.CEL_ESTUDIANTE;
                    inscripcion.CORREO = _estudiante.CORREO_ESTUDIANTE;
                    ctx.Entry(inscripcion).State = EntityState.Modified;

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
