using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Funda_Diseno
    {
        public int Funda_DisenoID { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        [Display(Name = "Valor Neto")]
        public double ValorNeto { get; set; }
        public int DetallePedidosID { get; set; }
        public virtual DetallesPedido DetallesPedidos { get; set; }

        public Funda_Diseno()
        {
            this.Imagen_Disenos = new HashSet<Imagen_Diseno>();
        }
        public virtual ICollection<Imagen_Diseno> Imagen_Disenos { get; set; }

    }
}