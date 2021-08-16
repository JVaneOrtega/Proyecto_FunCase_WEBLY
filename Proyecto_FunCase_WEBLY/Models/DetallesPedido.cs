using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class DetallesPedido
    {
        public int DetallesPedidoID { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = "Precio Unitario")]
        public double PrecioUnitario { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
        public int PedidoID { get; set; }
        public virtual Pedido Pedido { get; set; }

        public DetallesPedido()
        {
            this.Funda_Disenos = new HashSet<Funda_Diseno>();
        }

        public virtual ICollection<Funda_Diseno> Funda_Disenos { get; set; }
    }
}