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
    
    public partial class DocenteObtenerAsistenciaEstudiantes_Result
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
}
