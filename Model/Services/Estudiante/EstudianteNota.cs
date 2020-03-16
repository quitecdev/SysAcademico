using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;


namespace Model.Services.Estudiante
{
    public class EstudianteNota
    {
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public List<Promedio> PROMEDIO_ESTUDIANTE { get; set; }

        public List<Parcial> PARCIAL { get; set; }


        CarreraEstudiante carreraEstudiante = new CarreraEstudiante();
        public List<EstudianteNota> ObtenerNota(string ID_ESTUDIANTE)
        {
            List<EstudianteNota> lista_notas = new List<EstudianteNota>();
            try
            {
                var carrera = carreraEstudiante.ObtenerCarreraEstudiante(ID_ESTUDIANTE);
                foreach (var item in carrera)
                {

                    using (var ctx = new CAS_DataEntities())
                    {
                        ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                        ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                        lista_notas.Add(new EstudianteNota
                        {
                            ID_CARRERA = item.ID_CARRERA,
                            DESCRIPCION_CARRERA = item.DESCRIPCION_CARRERA,
                            PROMEDIO_ESTUDIANTE = ctx.SP_EstudianteObtenerPromedio(ID_ESTUDIANTE, item.ID_PERIODO, item.ID_CARRERA, outMensaje, outID)
                                                .Select(x => new Promedio
                                                {
                                                    ID_NOTA_DETALLE = x.ID_NOTA_DETALLE,
                                                    DESCRIPCION_NOTA_DETALLE = x.DESCRIPCION_NOTA_DETALLE,
                                                    PORCENTAJE = x.PORCENTAJE,
                                                    PROMEDIO = x.PROMEDIO,
                                                    NOTA = x.NOTA,
                                                    NOTA_FINAL=x.NOTA_FINAL

                                                }).ToList(),
                            PARCIAL = ctx.SP_EstudianteObtenerNotaParciales(item.ID_CARRERA, item.ID_TIPO_INTERVALO, item.ID_PERIODO, outMensaje, outID)
                                    .Select(x => new Parcial
                                    {
                                        ID_NOTA = x.ID_NOTA,
                                        ID_NOTA_DETALLE = x.ID_NOTA_DETALLE,
                                        DESCRIPCION_NOTA_DETALLE = x.DESCRIPCION_NOTA_DETALLE,
                                        TOTAL = x.TOTAL,
                                        NOTA_DETALLE = ctx.SP_EstudianteObtenerNotaDetalle(x.ID_NOTA_DETALLE, ID_ESTUDIANTE, item.ID_PERIODO, outMensaje, outID)
                                                     .Select(y => new NotaDetalle
                                                     {
                                                         ID_ESTUDIANTE_NOTA = y.ID_ESTUDIANTE_NOTA,
                                                         ID_PONDERACION = y.ID_PONDERACION,
                                                         DESCRIPCION_PONDERACION = y.DESCRIPCION_PONDERACION,
                                                         VALOR_NOTA = y.VALOR_NOTA,
                                                         VALOR_PONDERACION = y.VALOR_PONDERACION,
                                                         PARCIAL = y.PARCIAL
                                                     }).ToList()
                                    }).ToList()

                        });

                    }

                }


                return lista_notas;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                throw;
            }
        }

    }

    public class Promedio
    {
        public int ID_NOTA_DETALLE { get; set; }
        public string DESCRIPCION_NOTA_DETALLE { get; set; }
        public Nullable<int> PORCENTAJE { get; set; }
        public Nullable<decimal> PROMEDIO { get; set; }
        public Nullable<decimal> NOTA { get; set; }
        public Nullable<decimal> NOTA_FINAL { get; set; }
    }

    public class Parcial
    {
        public int ID_NOTA { get; set; }
        public int ID_NOTA_DETALLE { get; set; }
        public string DESCRIPCION_NOTA_DETALLE { get; set; }
        public Nullable<int> TOTAL { get; set; }
        public List<NotaDetalle> NOTA_DETALLE { get; set; }
    }

    public class NotaDetalle
    {
        public int ID_ESTUDIANTE_NOTA { get; set; }
        public int ID_PONDERACION { get; set; }
        public string DESCRIPCION_PONDERACION { get; set; }
        public Nullable<decimal> VALOR_NOTA { get; set; }
        public Nullable<decimal> VALOR_PONDERACION { get; set; }
        public Nullable<decimal> PARCIAL { get; set; }
    }

}
