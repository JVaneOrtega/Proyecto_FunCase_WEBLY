using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Compras
    {
        public int ComprasID { get; set; }
        public DateTime FechaCompra { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser UsuarioRegistro { get; set; }
        public string NotaCompra { get; set; }
        public string FotoTicket { get; set; }
        public double Total { get; set; }
        public int ProveedorID { get; set; }
        public virtual Proveedor Proveedor {get; set;}

        public Compras()
        {
            this.DetalleCompras = new HashSet<DetalleCompra>();
        }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}