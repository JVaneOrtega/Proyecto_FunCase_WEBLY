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
        [Required]
        public string Ruta { get; set; }
        [Display(Name = "Estatus de la Imagen")]
        public bool Estatus { get; set; }
        public int DesignerID { get; set; }
        public virtual Designer Designer { get; set; }

        public Imagen ()
        {
            this.Imagen_Disenos = new HashSet<Imagen_Diseno>();
        }
        public virtual ICollection<Imagen_Diseno> Imagen_Disenos { get; set; }
    }
}