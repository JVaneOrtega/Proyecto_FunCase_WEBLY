using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Imagen
    {
        public int ImagenID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string NombreImagen { get; set; }
        public string Ruta { get; set; }
        public virtual Designer Designer { get; set; }
    }
}