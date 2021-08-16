using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public string ImagenFinal { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Total { get; set; }
        [Display(Name = "Estatus del Producto")]
        public char Estatus { get; set; }
        [Required]
        public int Stock { get; set; }
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }
        public int ModeloID { get; set; }
        public virtual Modelo Modelo { get; set; }

        public Producto ()
        {
            this.DetallesPedidos = new HashSet<DetallesPedido>();
        }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}