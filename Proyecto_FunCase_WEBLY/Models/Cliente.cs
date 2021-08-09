using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentitySample.Models;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [Display(Name = "Datos de Usuario")]
        [Key]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}