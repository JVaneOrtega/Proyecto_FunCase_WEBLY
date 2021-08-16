using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Marca
    {
        public int MarcaID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Estatus de la Marca")]
        public bool Estatus { get; set; }

        public Marca()
        {
            this.Modelos = new HashSet<Modelo>();
        }

        public virtual ICollection<Modelo> Modelos { get; set; }

    }
}