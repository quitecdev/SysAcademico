using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data;
using System.Dynamic;

namespace Model.Services.Docente
{
    public class Notas
    {
        public List<EstudianteNota> NotaEstudiante { get; set; }
        //public List<Parcial> NotaParcial { get; set; }
        //public List<NotaDetalleParcial> NotaDetalleParcial { get; set; }

        public Notas ObtenerNota(int ID_SEDE, int ID_CARRERA, int ID_NOTA, int ID_INTERVALO_DETALLE, string ID_DOCENTE)
        {
            Notas _nota = new Notas();
            //List<NotaDetalleParcial> detalle = new List<NotaDetalleParcial>();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    _nota.NotaEstudiante = ctx.SP_DocenteObtenerEstudianteNota(ID_DOCENTE, ID_SEDE, ID_CARRERA, ID_NOTA, null, ID_INTERVALO_DETALLE, null, outMensaje, outID)
                                         .Select(x => new EstudianteNota
                                         {
                                             ID_ESTUDIANTE = x.ID_ESTUDIANTE,
                                             APELLIDO_PATERNO_ESTUDIANTE = x.APELLIDO_PATERNO_ESTUDIANTE,
                                             APELLIDO_MATERNO_ESTUDIANTE = x.APELLIDO_MATERNO_ESTUDIANTE,
                                             PRIMER_NOMBRE_ESTUDIANTE = x.PRIMER_NOMBRE_ESTUDIANTE,
                                             SEGUNDO_NOMBRE_ESTUDIANTE = x.SEGUNDO_NOMBRE_ESTUDIANTE,
                                             NotaParcialEstudiante = ctx.SP_DocenteObtenerEstudianteParcial(ID_SEDE, ID_CARRERA, ID_NOTA, null, ID_INTERVALO_DETALLE, ID_DOCENTE, x.ID_ESTUDIANTE, outMensaje, outID)
                                                                      .Select(y => new Parcial {
                                                                          ID_NOTA_DETALLE = y.ID_NOTA_DETALLE,
                                                                          DESCRIPCION_NOTA_DETALLE = y.DESCRIPCION_NOTA_DETALLE,
                                                                          NotaDetalle = ctx.SP_DocenteObtenerEstudianteValor(ID_SEDE, ID_CARRERA, ID_NOTA, null, ID_INTERVALO_DETALLE, ID_DOCENTE, x.ID_ESTUDIANTE, y.ID_NOTA_DETALLE, outMensaje, outID)
                                                                                         .Select(z => new NotaDetalleParcial {
                                                                                             ID_PONDERACION=z.ID_PONDERACION,
                                                                                             ID_ESTUDIANTE_NOTA=z.ID_ESTUDIANTE_NOTA,
                                                                                             DESCRIPCION_PONDERACION=z.DESCRIPCION_PONDERACION,
                                                                                             VALOR_NOTA=z.VALOR_NOTA,
                                                                                             ESTADO=z.ESTADO
                                                                                         }).ToList()
                                                                      }).ToList()
                                         }).ToList();
                    return _nota;
                }
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return _nota;
            }
        }
    }

    public class EstudianteNota
    {
        public string ID_ESTUDIANTE { get; set; }
        public string APELLIDO_PATERNO_ESTUDIANTE { get; set; }
        public string APELLIDO_MATERNO_ESTUDIANTE { get; set; }
        public string PRIMER_NOMBRE_ESTUDIANTE { get; set; }
        public string SEGUNDO_NOMBRE_ESTUDIANTE { get; set; }
        public List<Parcial> NotaParcialEstudiante { get; set; }
    }



    public class Parcial
    {
        public int ID_NOTA_DETALLE { get; set; }
        public string DESCRIPCION_NOTA_DETALLE { get; set; }
        public List<NotaDetalleParcial> NotaDetalle { get; set; }
    }

    public class NotaDetalleParcial
    {
        public int ID_PONDERACION { get; set; }
        public int ID_ESTUDIANTE_NOTA { get; set; }
        public string DESCRIPCION_PONDERACION { get; set; }
        public Nullable<decimal> VALOR_NOTA { get; set; }
        public int ESTADO { get; set; }
    }
}
