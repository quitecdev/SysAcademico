//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Data
{
    using System;
    
    public partial class ObtenerEstudianteAsistenciaCarrera_Result
    {
        public int ID_ASISTENCIA { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string HORA { get; set; }
        public Nullable<bool> ESTADO { get; set; }
        public Nullable<int> ID_ASISTENCIA_JUSTIFICADA { get; set; }
    }
}
