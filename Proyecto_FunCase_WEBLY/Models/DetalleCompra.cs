using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class DetalleCompra
    {
        public int DetalleCompraID { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double PrecioCompra { get; set; }
        public int ComprasID { get; set; }
        public virtual Compras Compra { get; set; }

    }
}