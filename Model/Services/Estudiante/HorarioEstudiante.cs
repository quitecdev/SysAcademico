using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Entity.Core.Objects;

namespace Model.Services.Estudiante
{
    public class HorarioEstudiante
    {

        public List<EstudianteCarreraMateria> CarreraMateria { get; set; }
        public List<DetalleHorario> Horario { get; set; }

        public HorarioEstudiante ObtenerHorario(string ID_ESTUDIANTE)
        {
            HorarioEstudiante horario = new HorarioEstudiante();
            try
            {
                using (var ctx = new CAS_DataEntities())
                {
                    ObjectParameter outID = new ObjectParameter("outID", typeof(int));
                    ObjectParameter outMensaje = new ObjectParameter("outMensaje", typeof(string));

                    horario.CarreraMateria = ctx.SP_EstudianteObtenerCarreraMateria(ID_ESTUDIANTE, null, outMensaje, outID)
                            .Select(x => new EstudianteCarreraMateria
                            {
                                DESCRIPCION_CARRERA = x.DESCRIPCION_CARRERA,
                                COD_CARRERA = x.COD_CARRERA,
                                DESCRIPCION_MATERIA = x.DESCRIPCION_MATERIA,
                                COD_MATERIA = x.COD_MATERIA,
                                DESCRIPCION_UNIVERSIDAD = x.DESCRIPCION_UNIVERSIDAD,
                                COD_SEDE = x.COD_SEDE,
                                DESCRIPCION_PARALELO=x.DESCRIPCION_PARALELO

                            }).ToList();

                    horario.Horario = ctx.SP_EstudianteObtenerHorario(ID_ESTUDIANTE, null, outMensaje, outID)
                                    .Select(x => new DetalleHorario
                                    {
                                        HORIA_DIA = x.HORIA_DIA,
                                        LUNES = x.LUNES,
                                        MARTES = x.MARTES,
                                        MIERCOLES = x.MIERCOLES,
                                        JUEVES = x.JUEVES,
                                        VIERNES = x.VIERNES,
                                        SABADO = x.SABADO,
                                    }).ToList();
                }
                return horario;
            }
            catch (Exception ex)
            {
                ServicesTrackError.RegistrarError(ex);
                return horario;
            }
        }

    }

    public partial class DetalleHorario
    {
        public string HORIA_DIA { get; set; }
        public string LUNES { get; set; }
        public string MARTES { get; set; }
        public string MIERCOLES { get; set; }
        public string JUEVES { get; set; }
        public string VIERNES { get; set; }
        public string SABADO { get; set; }
    }

    public class EstudianteCarreraMateria
    {
        public string DESCRIPCION_CARRERA { get; set; }
        public string COD_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string COD_MATERIA { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string COD_SEDE { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
    }
}
