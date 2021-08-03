using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Persona
    {
        
        public int PersonaID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string Apellido1 { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
    }
}