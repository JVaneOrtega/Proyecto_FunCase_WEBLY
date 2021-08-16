using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class MetodosPago
    {
        public int MetodosPagoID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Estatus del Método de Pago")]
        public bool Estatus { get; set; }

        public MetodosPago()
        {
            this.Pedidos = new HashSet<Pedido>();
        }

        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}