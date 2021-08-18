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
        public ApplicationUser UsuarioRegistro { get; set; }
        public int Cantidad { get; set; }
        public int PrecioCompra { get; set; }
        public string NotaCompra { get; set; }
        public string FotoTicket { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        public int ProveedorID { get; set; }
        public Proveedor Proveedor {get; set;}
    }
}