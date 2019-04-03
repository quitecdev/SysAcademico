using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.ComponentModel.DataAnnotations;

namespace Model.Services.Estudiante
{
    public class Sugerencia
    {
        public string ID_USUARIO { get; set; }

        [Required]
        [Display(Name ="Asunto")]
        public string ASUNTO { get; set; }

        [Required]
        [Display(Name = "Mensaje")]
        [DataType(DataType.MultilineText)]
        public string MENSAJE { get; set; }
    }
}
