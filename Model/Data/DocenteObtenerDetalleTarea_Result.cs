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
    
    public partial class DocenteObtenerDetalleTarea_Result
    {
        public int ID_TAREA { get; set; }
        public int ID_SEDE { get; set; }
        public string DESCRIPCION_UNIVERSIDAD { get; set; }
        public int ID_CARRERA { get; set; }
        public string DESCRIPCION_CARRERA { get; set; }
        public int ID_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public int ID_PARALELO { get; set; }
        public string DESCRIPCION_PARALELO { get; set; }
        public int ID_INTERVALO_DETALLE { get; set; }
        public string HORARIO { get; set; }
        public string TEMA_TAREA { get; set; }
        public string DESCRIPCION_TAREA { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION_TAREA { get; set; }
        public Nullable<System.DateTime> FECHA_FIN_TAREA { get; set; }
        public Nullable<int> ID_PERIODO { get; set; }
    }
}