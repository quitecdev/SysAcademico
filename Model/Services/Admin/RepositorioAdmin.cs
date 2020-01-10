using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Admin
{
    public class RepositorioAdmin
    {
        public int ID_CARRERA { get; set; }
        //public string DESCRIPCION_CARRERA { get; set; }
        public List<RepositorioSemana> Semana { get; set; }

        public List<RepositorioAdmin> ObtenerRepositorio( int ID_CRONOGRAMA)
        {
            List<RepositorioAdmin> RepositorioDocente = new List<RepositorioAdmin>();

            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));
                    RepositorioDocente.Add(new RepositorioAdmin
                    {
                        ID_CARRERA = ID_CARRERA,
                        //DESCRIPCION_CARRERA = item.DESCRIPCION_CARRERA,
                        Semana = ctx.SP_AdminRepositorioSemana(ID_CRONOGRAMA, outMensaje, outID)
                                .Select(x => new RepositorioSemana
                                {
                                    SEMANA_CRONOGRAMA = x.SEMANA_CRONOGRAMA,
                                    TEMA = x.TEMA,
                                    DESCRIPCION_SEMANA = x.DESCRIPCION_SEMANA,
                                    ID_CRONOGRAMA = x.ID_CRONOGRAMA,
                                    Carpeta = ctx.SP_AdminRepositorioCarpeta(x.SEMANA_CRONOGRAMA, x.ID_CRONOGRAMA, outMensaje, outID)
                                              .Select(b => new RepositorioCarpeta
                                              {
                                                  ID_CARPETA = b.ID_CARPETA,
                                                  DESCRIPCION_CARPETA = b.DESCRIPCION_CARPETA,
                                                  Adjunto = ctx.SP_AdminRepositorioAdjunto(x.SEMANA_CRONOGRAMA,b.ID_CARPETA, x.ID_CRONOGRAMA, outMensaje, outID)
                                                           .Select(y => new RepositorioAdjunto
                                                           {
                                                               ID_CRONOGRAMA_ADJUNTO = y.ID_CRONOGRAMA_ADJUNTO,
                                                               RUTA_ADJUNTO = y.RUTA_ADJUNTO,
                                                               ICONO_ADJUNTO = y.ICONO_ADJUNTO,
                                                               PESO_ADJUNTO = y.PESO_ADJUNTO,
                                                               NOMBRE_ADJUNTO = y.NOMBRE_ADJUNTO,
                                                               FECHA = y.FECHA,
                                                               FECHA_CRONOGRAMA = y.FECHA_CRONOGRAMA
                                                           }).ToList()
                                              }).ToList()
                                }).ToList()

                    });
                }
                return RepositorioDocente;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return RepositorioDocente;
            }

        }

    }

    public class RepositorioSemana
    {
        public Nullable<int> SEMANA_CRONOGRAMA { get; set; }
        public string TEMA { get; set; }
        public string DESCRIPCION_SEMANA { get; set; }
        public int ID_CRONOGRAMA { get; set; }
        public List<RepositorioCarpeta> Carpeta { get; set; }
    }

    public class RepositorioCarpeta
    {
        public int ID_CARPETA { get; set; }
        public string DESCRIPCION_CARPETA { get; set; }
        public List<RepositorioAdjunto> Adjunto { get; set; }

    }

    public class RepositorioAdjunto
    {
        public int ID_CRONOGRAMA_ADJUNTO { get; set; }
        public string RUTA_ADJUNTO { get; set; }
        public string ICONO_ADJUNTO { get; set; }
        public string PESO_ADJUNTO { get; set; }
        public string NOMBRE_ADJUNTO { get; set; }
        public string FECHA { get; set; }
        public Nullable<System.DateTime> FECHA_CRONOGRAMA { get; set; }
    }
}
