using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Model.Services.Admin
{
    public class Inscipcion
    {

        [Display(Name = "Documento de Identidad")]
        [Required]
        public string ID_INSCRIP { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        public string APELLIDO_PATERNO_INSCRIP { get; set; }

        [Display(Name = "Apellido Materno")]
        public string APELLIDO_MATERNO_INSCRIP { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required]
        public string PRIMER_NOMBRE_INSCRIP { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SEGUNDO_NOMBRE_INSCRIP { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public Nullable<System.DateTime> FECHA_NACIMIENTO_INSCRIP { get; set; }

        [Display(Name = "Nacionalidad")]
        [Required]
        public string DESCRIPCION_NACIONALIDAD { get; set; }

        [Display(Name = "Estado Civil")]
        [Required]
        public Nullable<int> ID_ESTADO_CIVIL { get; set; }

        [Display(Name = "Ciudad")]
        [Required]
        public Nullable<int> ID_CIUDAD { get; set; }

        [Display(Name = "Dirección")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string DIRECCION { get; set; }

        [Display(Name = "Teléfono")]
        public string TELEF_INSCRIP { get; set; }

        [Display(Name = "Celular")]
        [Required]
        public string CEL_INSCRIP { get; set; }

        [Display(Name = "Teléfono Emergencia")]
        public string TELEF_EMER_INSCRIP { get; set; }

        public string IMG_INSCRIP { get; set; }
        public bool DOC_IDENTIDAD { get; set; }
        public bool PAPELETA_VOT { get; set; }
        public bool FOTOGRAFIA { get; set; }
        public bool  CERT_MEDICO { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string CORREO { get; set; }
        public Nullable<System.DateTime> FECHA_INSCRIPCION { get; set; }
        public bool ESTADO_INSCRIPCION_FECHA { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public Nullable<int> ID_GENERO { get; set; }

        [Display(Name = "Discapacidad")]
        public bool DISCAPACIDAD { get; set; }

        [Display(Name = "Tipo Discapacidad")]
        public string TIPO_DISCAPACIDAD { get; set; }

        [Display(Name = "Actividad Laboral")]
        public bool ACTIVIDAD_LABORAL { get; set; }

        Estudiante estudiante = new Estudiante();
        public void GuardarInscripcion(Inscipcion inscripcion)
        {
            CAS_INSCRIPCION _inscripcion = new CAS_INSCRIPCION();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    var foo = ctx.CAS_INSCRIPCION.Where(v => v.ID_INSCRIP == inscripcion.ID_INSCRIP).AsNoTracking().ToList();
                    var fooCount = foo.Count();
                    if (fooCount > 0)
                    {
                        _inscripcion.ID_INSCRIP = inscripcion.ID_INSCRIP;
                        _inscripcion.APELLIDO_PATERNO_INSCRIP = inscripcion.APELLIDO_PATERNO_INSCRIP.ToUpper();
                        _inscripcion.APELLIDO_MATERNO_INSCRIP = inscripcion.APELLIDO_MATERNO_INSCRIP!=null ? inscripcion.APELLIDO_MATERNO_INSCRIP.ToUpper() : inscripcion.APELLIDO_MATERNO_INSCRIP;
                        _inscripcion.PRIMER_NOMBRE_INSCRIP = inscripcion.PRIMER_NOMBRE_INSCRIP.ToUpper();
                        _inscripcion.SEGUNDO_NOMBRE_INSCRIP = inscripcion.SEGUNDO_NOMBRE_INSCRIP != null ? inscripcion.SEGUNDO_NOMBRE_INSCRIP.ToUpper() : inscripcion.SEGUNDO_NOMBRE_INSCRIP;
                        _inscripcion.FECHA_NACIMIENTO_INSCRIP = inscripcion.FECHA_NACIMIENTO_INSCRIP;
                        _inscripcion.DESCRIPCION_NACIONALIDAD = inscripcion.DESCRIPCION_NACIONALIDAD.ToUpper();
                        _inscripcion.ID_ESTADO_CIVIL = inscripcion.ID_ESTADO_CIVIL;
                        _inscripcion.ID_CIUDAD = inscripcion.ID_CIUDAD;
                        _inscripcion.ID_PROVINCIA = 1;
                        _inscripcion.DIRECCION = inscripcion.DIRECCION;
                        _inscripcion.TELEF_INSCRIP = inscripcion.TELEF_INSCRIP;
                        _inscripcion.CEL_INSCRIP = inscripcion.CEL_INSCRIP;
                        _inscripcion.TELEF_EMER_INSCRIP = inscripcion.TELEF_EMER_INSCRIP;
                        _inscripcion.IMG_INSCRIP = inscripcion.IMG_INSCRIP;
                        _inscripcion.DOC_IDENTIDAD = inscripcion.DOC_IDENTIDAD;
                        _inscripcion.PAPELETA_VOT = inscripcion.PAPELETA_VOT;
                        _inscripcion.FOTOGRAFIA = inscripcion.FOTOGRAFIA;
                        _inscripcion.CERT_MEDICO = inscripcion.CERT_MEDICO;
                        _inscripcion.CORREO = inscripcion.CORREO;
                        _inscripcion.FECHA_INSCRIPCION = DateTime.Now;
                        _inscripcion.ID_GENERO = inscripcion.ID_GENERO;
                        _inscripcion.ACTIVIDAD_LABORAL = inscripcion.ACTIVIDAD_LABORAL;
                        _inscripcion.DISCAPACIDAD = inscripcion.DISCAPACIDAD;
                        _inscripcion.TIPO_DISCAPACIDAD = inscripcion.TIPO_DISCAPACIDAD;

                        ctx.Entry(_inscripcion).State = EntityState.Modified;

                        estudiante.GuardarEstudiante(inscripcion);

                    }
                    else
                    {
                        _inscripcion.ID_INSCRIP = inscripcion.ID_INSCRIP;
                        _inscripcion.APELLIDO_PATERNO_INSCRIP = inscripcion.APELLIDO_PATERNO_INSCRIP.ToUpper();
                        _inscripcion.APELLIDO_MATERNO_INSCRIP = inscripcion.APELLIDO_MATERNO_INSCRIP != null ? inscripcion.APELLIDO_MATERNO_INSCRIP.ToUpper() : inscripcion.APELLIDO_MATERNO_INSCRIP;
                        _inscripcion.PRIMER_NOMBRE_INSCRIP = inscripcion.PRIMER_NOMBRE_INSCRIP.ToUpper();
                        _inscripcion.SEGUNDO_NOMBRE_INSCRIP = inscripcion.SEGUNDO_NOMBRE_INSCRIP != null ? inscripcion.SEGUNDO_NOMBRE_INSCRIP.ToUpper() : inscripcion.SEGUNDO_NOMBRE_INSCRIP;
                        _inscripcion.FECHA_NACIMIENTO_INSCRIP = inscripcion.FECHA_NACIMIENTO_INSCRIP;
                        _inscripcion.DESCRIPCION_NACIONALIDAD = inscripcion.DESCRIPCION_NACIONALIDAD.ToUpper();
                        _inscripcion.ID_ESTADO_CIVIL = inscripcion.ID_ESTADO_CIVIL;
                        _inscripcion.ID_CIUDAD = inscripcion.ID_CIUDAD;
                        _inscripcion.ID_PROVINCIA = 1;
                        _inscripcion.DIRECCION = inscripcion.DIRECCION;
                        _inscripcion.TELEF_INSCRIP = inscripcion.TELEF_INSCRIP;
                        _inscripcion.CEL_INSCRIP = inscripcion.CEL_INSCRIP;
                        _inscripcion.TELEF_EMER_INSCRIP = inscripcion.TELEF_EMER_INSCRIP;
                        _inscripcion.IMG_INSCRIP = inscripcion.IMG_INSCRIP;
                        _inscripcion.DOC_IDENTIDAD = inscripcion.DOC_IDENTIDAD;
                        _inscripcion.PAPELETA_VOT = inscripcion.PAPELETA_VOT;
                        _inscripcion.FOTOGRAFIA = inscripcion.FOTOGRAFIA;
                        _inscripcion.CERT_MEDICO = inscripcion.CERT_MEDICO;
                        _inscripcion.CORREO = inscripcion.CORREO;
                        _inscripcion.FECHA_INSCRIPCION = DateTime.Now;
                        _inscripcion.ID_GENERO = inscripcion.ID_GENERO;
                        _inscripcion.ACTIVIDAD_LABORAL = inscripcion.ACTIVIDAD_LABORAL;
                        _inscripcion.DISCAPACIDAD = inscripcion.DISCAPACIDAD;
                        _inscripcion.TIPO_DISCAPACIDAD = inscripcion.TIPO_DISCAPACIDAD;

                        ctx.Entry(_inscripcion).State = EntityState.Added;

                        estudiante.GuardarEstudiante(inscripcion);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public List<Inscipcion> BuscarInscripciones(string _ID_INSCRIP)
        {
            List<Inscipcion> inscripcion = new List<Inscipcion>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    inscripcion = ctx.CAS_INSCRIPCION.Where(x => x.ID_INSCRIP.Contains(_ID_INSCRIP))
                                 .Select(x => new Inscipcion
                                 {
                                     ID_INSCRIP = x.ID_INSCRIP

                                 }).ToList();
                }
                return inscripcion;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return inscripcion;
            }
        }

        InscripcionFecha fechaInscripcion = new InscripcionFecha();
        public Inscipcion ObtenerInscripcion(string _ID_INSCRIP)
        {
            Inscipcion inscripcion = new Inscipcion();

            try
            {
                using (var ctx = new CAS_DataEntities())
                {

                    if (_ID_INSCRIP != null)
                    {
                        inscripcion = ctx.CAS_INSCRIPCION.Where(x => x.ID_INSCRIP == _ID_INSCRIP)
                                      .Select(x => new Inscipcion
                                      {
                                          ID_INSCRIP = x.ID_INSCRIP,
                                          APELLIDO_PATERNO_INSCRIP = x.APELLIDO_PATERNO_INSCRIP,
                                          APELLIDO_MATERNO_INSCRIP = x.APELLIDO_MATERNO_INSCRIP,
                                          PRIMER_NOMBRE_INSCRIP = x.PRIMER_NOMBRE_INSCRIP,
                                          SEGUNDO_NOMBRE_INSCRIP = x.SEGUNDO_NOMBRE_INSCRIP,
                                          FECHA_NACIMIENTO_INSCRIP = x.FECHA_NACIMIENTO_INSCRIP,
                                          DESCRIPCION_NACIONALIDAD = x.DESCRIPCION_NACIONALIDAD,
                                          ID_ESTADO_CIVIL = x.ID_ESTADO_CIVIL,
                                          ID_CIUDAD = x.ID_CIUDAD,
                                          DIRECCION = x.DIRECCION,
                                          TELEF_INSCRIP = x.TELEF_INSCRIP,
                                          CEL_INSCRIP = x.CEL_INSCRIP,
                                          TELEF_EMER_INSCRIP = x.TELEF_EMER_INSCRIP,
                                          CORREO = x.CORREO,
                                          DOC_IDENTIDAD = x.DOC_IDENTIDAD ?? false,
                                          FOTOGRAFIA = x.FOTOGRAFIA ?? false,
                                          PAPELETA_VOT = x.PAPELETA_VOT ?? false,
                                          CERT_MEDICO = x.CERT_MEDICO ?? false,
                                          ID_GENERO = x.ID_GENERO,
                                          ACTIVIDAD_LABORAL=x.ACTIVIDAD_LABORAL ?? false,
                                          DISCAPACIDAD=x.DISCAPACIDAD ?? false,
                                          TIPO_DISCAPACIDAD=x.TIPO_DISCAPACIDAD
                                      }).FirstOrDefault();
                        inscripcion.ESTADO_INSCRIPCION_FECHA = fechaInscripcion.VerificarEstado();
                    }
                    else
                    {
                        inscripcion.ESTADO_INSCRIPCION_FECHA = fechaInscripcion.VerificarEstado();
                    }
                }
                return inscripcion;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return inscripcion;
            }
        }

        public Inscipcion ObtenerInscripcion(int ID_INSCRIP_DETALLE_CARRERA)
        {
            Inscipcion _inscripcion = new Inscipcion();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _inscripcion = (from inscripcion in ctx.CAS_INSCRIPCION
                                    join detalle in ctx.CAS_INSCRIPCION_DETALLE_CARRERA on inscripcion.ID_INSCRIP equals detalle.ID_INSCRIP
                                    where detalle.ID_INSCRIP_DETALLE_CARRERA == ID_INSCRIP_DETALLE_CARRERA
                                    select new Inscipcion() {
                                        ID_INSCRIP = inscripcion.ID_INSCRIP,
                                        APELLIDO_PATERNO_INSCRIP = inscripcion.APELLIDO_PATERNO_INSCRIP,
                                        APELLIDO_MATERNO_INSCRIP = inscripcion.APELLIDO_MATERNO_INSCRIP,
                                        PRIMER_NOMBRE_INSCRIP = inscripcion.PRIMER_NOMBRE_INSCRIP,
                                        SEGUNDO_NOMBRE_INSCRIP = inscripcion.SEGUNDO_NOMBRE_INSCRIP,
                                        FECHA_NACIMIENTO_INSCRIP = inscripcion.FECHA_NACIMIENTO_INSCRIP,
                                        DESCRIPCION_NACIONALIDAD = inscripcion.DESCRIPCION_NACIONALIDAD,
                                        ID_ESTADO_CIVIL = inscripcion.ID_ESTADO_CIVIL,
                                        ID_CIUDAD = inscripcion.ID_CIUDAD,
                                        DIRECCION = inscripcion.DIRECCION,
                                        TELEF_INSCRIP = inscripcion.TELEF_INSCRIP,
                                        CEL_INSCRIP = inscripcion.CEL_INSCRIP,
                                        TELEF_EMER_INSCRIP = inscripcion.TELEF_EMER_INSCRIP,
                                        CORREO = inscripcion.CORREO,
                                        DOC_IDENTIDAD = inscripcion.DOC_IDENTIDAD ?? false,
                                        FOTOGRAFIA = inscripcion.FOTOGRAFIA ?? false,
                                        PAPELETA_VOT = inscripcion.PAPELETA_VOT ?? false,
                                        CERT_MEDICO = inscripcion.CERT_MEDICO ?? false,
                                        ID_GENERO = inscripcion.ID_GENERO,
                                        ACTIVIDAD_LABORAL = inscripcion.ACTIVIDAD_LABORAL ?? false,
                                        DISCAPACIDAD = inscripcion.DISCAPACIDAD ?? false,
                                        TIPO_DISCAPACIDAD = inscripcion.TIPO_DISCAPACIDAD
                                    }
                                    ).FirstOrDefault();
                }
                return _inscripcion;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _inscripcion;
            }
        }

        private CAS_DataEntities db = new CAS_DataEntities();
        public List<CAS_ESTADO_CIVIL> cmb_EstadoCivil()
        {
            return db.CAS_ESTADO_CIVIL.ToList();
        }

        public CAS_ESTADO_CIVIL cmb_EstadoCivil(int ID_ESTADO_CIVIL)
        {
            return db.CAS_ESTADO_CIVIL.Where(x=>x.ID_ESTADO_CIVIL== ID_ESTADO_CIVIL).FirstOrDefault();
        }

        public List<CAS_UBICACION> cmb_Ciudad()
        {
            List<CAS_UBICACION> ubicacion = new List<CAS_UBICACION>();
            try
            {
                ubicacion = db.CAS_UBICACION.ToList();
                return ubicacion;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return ubicacion;
            }
        }

        public List<CAS_GENERO> cmb_Genero()
        {
            List<CAS_GENERO> genero = new List<CAS_GENERO>();
            try
            {
                genero = db.CAS_GENERO.ToList();
                return genero;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return genero;
            }
        }

        public bool ValidarInscripcion(string id_inscrip)
        {
            bool exite = false;
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    exite = ctx.CAS_INSCRIPCION.Where(x => x.ID_INSCRIP == id_inscrip).Any();
                }
                return exite;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return exite;
            }
        }
    }

    public class ListaInscripcion
    {
        public string ID_INSCRIP { get; set; }
        public string APELLIDO_PATERNO_INSCRIP { get; set; }
        public string APELLIDO_MATERNO_INSCRIP { get; set; }
        public string PRIMER_NOMBRE_INSCRIP { get; set; }
        public string SEGUNDO_NOMBRE_INSCRIP { get; set; }

        public List<ListaInscripcion> ObtenerInscripciones()
        {
            List<ListaInscripcion> list = new List<ListaInscripcion>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    list = ctx.CAS_INSCRIPCION
                           .Select(x => new ListaInscripcion
                           {
                               ID_INSCRIP = x.ID_INSCRIP,
                               APELLIDO_PATERNO_INSCRIP = x.APELLIDO_PATERNO_INSCRIP,
                               APELLIDO_MATERNO_INSCRIP = x.APELLIDO_MATERNO_INSCRIP,
                               PRIMER_NOMBRE_INSCRIP = x.PRIMER_NOMBRE_INSCRIP,
                               SEGUNDO_NOMBRE_INSCRIP = x.SEGUNDO_NOMBRE_INSCRIP
                           }).ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return list;
            }
        }
    }


    public class ModelInscripcion
    {
        [Display(Name = "Documento de Identidad")]
        [Required]
        public string ID_INSCRIP { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        public string APELLIDO_PATERNO_INSCRIP { get; set; }

        [Display(Name = "Apellido Materno")]
        public string APELLIDO_MATERNO_INSCRIP { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required]
        public string PRIMER_NOMBRE_INSCRIP { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SEGUNDO_NOMBRE_INSCRIP { get; set; }


        [Display(Name = "Nacionalidad")]
        [Required]
        public string DESCRIPCION_NACIONALIDAD { get; set; }


        [Display(Name = "Celular")]
        [Required]
        public string CEL_INSCRIP { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string CORREO { get; set; }

        [Display(Name = "Dirección")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string DIRECCION { get; set; }
    }
}
