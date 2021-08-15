﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Designer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesignerID { get; set; }
        [Display(Name = "Nombre de Presentación")]
        public string NombrePresentacion { get; set; }

        [Required]
        [Display(Name = "Datos de Usuario")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}