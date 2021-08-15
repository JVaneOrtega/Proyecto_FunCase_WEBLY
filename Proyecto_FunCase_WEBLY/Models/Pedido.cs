﻿using System;
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
        public char EstatusPedido { get; set; }
        [Display(Name = "Estatus del Pago")]
        public char EstatusPago { get; set; }
        public string Referencia { get; set; }
        public double Descuento { get; set; }
        public virtual MetodosPago MetodoPago { get; set; }
    }
}