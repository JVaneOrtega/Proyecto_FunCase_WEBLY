using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Material
    {
        public int MaterialID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Tiene Relieve")]
        public bool TieneRelieve { get; set; }
        public string Color { get; set; }

        [Display(Name = "Estatus del Material")]
        public bool Estatus { get; set; }

        public Material()
        {
            this.Productos = new HashSet<Producto>();
        }

        public virtual ICollection<Producto> Productos { get; set; }

    }
}