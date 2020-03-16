using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data;
using System.Dynamic;
using System.Data.Entity;

namespace Model.Services.Docente
{
    public class Calificar
    {
        public List<Nota_Parcial> Parcial { get; set; }
        public List<Nota_Detalle> Nota_Detalla { get; set; }

        public List<Estudiante> Estudiante { get; set; }

        public Calificar ObtenerLibreta(int ID_PERIODO,int ID_SEDE, int ID_CARRERA, int ID_NOTA, int ID_INTERVALO_DETALLE, string ID_DOCENTE)
        {
            Calificar _calificar = new Calificar();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    _calificar.Parcial = ctx.SP_DocenteObtenerNotaParciales(ID_DOCENTE, ID_SEDE, ID_CARRERA, ID_NOTA, ID_PERIODO, ID_INTERVALO_DETALLE, outMensaje, outID)
                                         .Select(x => new Nota_Parcial
                                         {
                                             ID_NOTA_DETALLE = x.ID_NOTA_DETALLE,
                                             DESCRIPCION_NOTA_DETALLE = x.DESCRIPCION_NOTA_DETALLE,
                                             TOTAL = x.TOTAL.Value
                                         }).ToList();

                    _calificar.Nota_Detalla = ctx.SP_DocenteObtenerNotaDetalle(ID_DOCENTE, ID_SEDE, ID_CARRERA, ID_NOTA, ID_PERIODO, ID_INTERVALO_DETALLE, null, outMensaje, outID)
                                              .Select(x => new Nota_Detalle
                                              {
                                                  ID_PONDERACION = x.ID_PONDERACION,
                                                  DESCRIPCION_PONDERACION = x.DESCRIPCION_PONDERACION
                                              }).ToList();
                    
                    _calificar.Estudiante = ctx.SP_DocenteObtenerNotaEstudiante(ID_DOCENTE, ID_SEDE, ID_CARRERA, ID_NOTA, ID_PERIODO, ID_INTERVALO_DETALLE, outMensaje, outID)
                                                  .Select(x => new Estudiante
                                                  {
                                                      ID_ESTUDIANTE = x.ID_ESTUDIANTE,
                                                      APELLIDO_PATERNO_ESTUDIANTE = x.APELLIDO_PATERNO_ESTUDIANTE,
                                                      PRIMER_NOMBRE_ESTUDIANTE = x.PRIMER_NOMBRE_ESTUDIANTE,
                                                      NOTAS = ctx.SP_DocenteObtenerNotaDetalleEstudiante(ID_DOCENTE, ID_SEDE, ID_CARRERA, ID_NOTA, ID_PERIODO, ID_INTERVALO_DETALLE, x.ID_ESTUDIANTE, outMensaje, outID)
                                                              .Select(y => new Nota_Estudiante
                                                              {
                                                                  ID_ESTUDIANTE_NOTA = y.ID_ESTUDIANTE_NOTA,
                                                                  ID_PONDERACION = y.ID_PONDERACION,
                                                                  DESCRIPCION_PONDERACION = y.DESCRIPCION_PONDERACION,
                                                                  VALOR_NOTA = y.VALOR_NOTA.Value,
                                                                  ESTADO = y.ESTADO
                                                              }).ToList()
                                                  }).ToList();
                }

                return _calificar;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _calificar;
            }
        }

        public void ActulizarNota(int _ID_ESTUDIANTE_NOTA, decimal _VALOR_NOTA)
        {
            try
            {
                CAS_ESTUDIANTE_NOTA nota = new CAS_ESTUDIANTE_NOTA();
                using (var ctx = new CAS_DataEntities())
                {
                    nota = ctx.CAS_ESTUDIANTE_NOTA.Where(x => x.ID_ESTUDIANTE_NOTA == _ID_ESTUDIANTE_NOTA).AsNoTracking().FirstOrDefault();
                    nota.VALOR_NOTA = _VALOR_NOTA;
                    ctx.Entry(nota).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
            }
        }
    }

    public class Nota_Parcial
    {
        public int ID_NOTA_DETALLE { get; set; }
        public string DESCRIPCION_NOTA_DETALLE { get; set; }
        public Nullable<int> TOTAL { get; set; }
    }

    public class Nota_Detalle
    {
        public int ID_PONDERACION { get; set; }
        public string DESCRIPCION_PONDERACION { get; set; }
    }

    public class Estudiante
    {
        public string ID_ESTUDIANTE { get; set; }
        public string APELLIDO_PATERNO_ESTUDIANTE { get; set; }
        public string PRIMER_NOMBRE_ESTUDIANTE { get; set; }
        public List<Nota_Estudiante> NOTAS { get; set; }
    }

    public class Nota_Estudiante
    {
        public int ID_ESTUDIANTE_NOTA { get; set; }
        public int ID_PONDERACION { get; set; }
        public string DESCRIPCION_PONDERACION { get; set; }
        public Nullable<decimal> VALOR_NOTA { get; set; }
        public int ESTADO { get; set; }
    }
}
