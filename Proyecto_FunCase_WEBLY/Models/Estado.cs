using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Estado
    {
        public int EstadoID { get; set; }
        [Required]
        [Display(Name = "Nombre Estado")]
        public string Nombre { get; set; }

        public Estado()
        {
            this.Direcciones = new HashSet<Direccion>();
        }

        public virtual ICollection<Direccion> Direcciones { get; set; }
    }
}