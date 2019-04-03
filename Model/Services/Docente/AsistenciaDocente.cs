using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Model.Services.Docente
{
    public class AsistenciaDocente
    {
        public List<AsistenciaEstudiante> Estudiante { get; set; }
        public List<HorarioDetalle> Horario { get; set; }

        public AsistenciaActiva Activo { get; set; }

        public AsistenciaDocente ObtenerAsistencia(string ID_DOCENTE)
        {
           
            AsistenciaDocente asistencia = new AsistenciaDocente();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {

                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    asistencia.Activo = ctx.SP_DocenteObtenerAsistencia(ID_DOCENTE, null, outMensaje, outID)
                                       .Select(x => new AsistenciaActiva
                                       {
                                           ID_DOCENTE_ASISTENCIA = x.ID_DOCENTE_ASISTENCIA,
                                           ID_HORARIO_DETALLE = x.ID_HORARIO_DETALLE,
                                           OBSERVACION = x.OBSERVACION_ASISTENCIA,
                                          TIEMPO=x.TIEMPO
                                       }).FirstOrDefault();

                    if (asistencia.Activo != null)
                    {
                        asistencia.Estudiante = ctx.SP_DocenteObtenerAsistenciaEstudiantes(asistencia.Activo.ID_HORARIO_DETALLE, null, outMensaje, outID)
                        .Select(x => new AsistenciaEstudiante
                        {

                            ID_ASISTENCIA = x.ID_ASISTENCIA,
                            ID_ESTUDIANTE = x.ID_ESTUDIANTE,
                            APELLIDOS = x.APELLIDOS,
                            NOMBRES = x.NOMBRES,
                            FECHA = x.FECHA,
                            ID_HORARIO_DETALLE = x.ID_HORARIO_DETALLE,
                            ESTADO = x.ESTADO,
                            ID_PERIODO = x.ID_PERIODO
                        }).ToList();
                    }

                    asistencia.Horario = ctx.SP_DocenteHorarioDiario(ID_DOCENTE, null, outMensaje, outID)
                                         .Select(x => new HorarioDetalle
                                         {
                                             ID_HORARIO_DETALLE = x.ID_HORARIO_DETALLE,
                                             DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                             DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                             DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                             DESCRIPCION_PARALELO = x.DESCRIPCION_PARALELO,
                                             HORA = x.HORA,
                                             ESTADO_ASISTENCIA = x.ESTADO_ASISTENCIA
                                         }).ToList();

                }
                return asistencia;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return asistencia;
            }

        }

        public void GuardarAsistencia(AsistenciaDocente _asistencia)
        {
            CAS_DOCENTE_ASISTENCIA _docente = new CAS_DOCENTE_ASISTENCIA();
            CAS_ESTUDIANTE_ASISTENCIA _estudiante = new CAS_ESTUDIANTE_ASISTENCIA();
            /*Guardo Asistencia de Docente*/
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    _docente = ctx.CAS_DOCENTE_ASISTENCIA.Where(x => x.ID_DOCENTE_ASISTENCIA == _asistencia.Activo.ID_DOCENTE_ASISTENCIA).AsNoTracking().FirstOrDefault();
                    if(_asistencia.Activo.OBSERVACION!=null)
                    {
                        _docente.OBSERVACION_ASISTENCIA = _asistencia.Activo.OBSERVACION;
                    }
                    else
                    {
                        _docente.OBSERVACION_ASISTENCIA = "";
                    }
                    
                    _docente.FECHA_REGISTRO = DateTime.Now;
                    _docente.ESTADO_ASISTENCIA = 1;
                    ctx.Entry(_docente).State = EntityState.Modified;
                    ctx.SaveChanges();

                    foreach (var item in _asistencia.Estudiante)
                    {
                        _estudiante = ctx.CAS_ESTUDIANTE_ASISTENCIA.Where(x => x.ID_ASISTENCIA == item.ID_ASISTENCIA).AsNoTracking().FirstOrDefault();
                        _estudiante.ESTADO = item.ESTADO;
                        ctx.Entry(_estudiante).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }

        public AsistenciaActiva Tiempo(string ID_DOCENTE) {
            AsistenciaActiva activo = new AsistenciaActiva();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    activo = ctx.SP_DocenteObtenerAsistencia(ID_DOCENTE, null, outMensaje, outID)
                                       .Select(x => new AsistenciaActiva
                                       {
                                           ID_DOCENTE_ASISTENCIA = x.ID_DOCENTE_ASISTENCIA,
                                           ID_HORARIO_DETALLE = x.ID_HORARIO_DETALLE,
                                           OBSERVACION = x.OBSERVACION_ASISTENCIA,
                                           TIEMPO = x.TIEMPO
                                       }).FirstOrDefault();
                }
                return activo;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return activo;
            }
        }

    }

    public class AsistenciaEstudiante
    {
        public int ID_ASISTENCIA { get; set; }
        public string ID_ESTUDIANTE { get; set; }
        public string APELLIDOS { get; set; }
        public string NOMBRES { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<int> ID_HORARIO_DETALLE { get; set; }
        public Nullable<bool> ESTADO { get; set; }
        public int ID_PERIODO { get; set; }
    }

    public class HorarioDetalle
    {
        public int ID_HORARIO_DETALLE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public string HORA { get; set; }
        public Nullable<int> ESTADO_ASISTENCIA { get; set; }
    }

    public class AsistenciaActiva
    {
        public int ID_DOCENTE_ASISTENCIA { get; set; }
        public int ID_HORARIO_DETALLE { get; set; }
        public string OBSERVACION { get; set; }
        public string TIEMPO { get; set; }
    }
}
