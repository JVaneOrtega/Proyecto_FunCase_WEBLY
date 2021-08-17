using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public double Total { get; set; }
        [Display(Name = "Estatus del Pedido")]
        public string EstatusPedido { get; set; }
        [Display(Name = "Estatus del Pago")]
        public string EstatusPago { get; set; }
        public string Referencia { get; set; }
        public double Descuento { get; set; }
        public int MetodosPagoID { get; set; }
        public virtual MetodosPago MetodoPago { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int DireccionID { get; set; }
        public virtual Direccion Direccion { get; set; }

        public Pedido ()
        {
            this.DetallesPedidos = new HashSet<DetallesPedido>();
        }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}