using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class CarritoItem
    {

        public Producto Producto;
        public int Cantidad;

        public CarritoItem()
        {

        }

        public CarritoItem(Producto Producto, int Cantidad)
        {
            this.Producto = Producto;
            this.Cantidad = Cantidad;
        }

        public double calcularTotal()
        {
            return (double)(Producto.Precio * Cantidad);
        }

    }
}