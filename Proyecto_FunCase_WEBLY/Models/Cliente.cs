using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdentitySample.Models;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaNacimiento { get; set; }
        [Required]
        [Display(Name = "Datos Personales")]
        public virtual Persona Persona { get; set; }
        [Display(Name = "Datos de Usuario")]
        public virtual ApplicationUser User { get; set; }
    }
}