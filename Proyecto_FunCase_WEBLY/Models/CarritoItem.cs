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
        public Imagen Imagen;

        public CarritoItem()
        {

        }

        public CarritoItem(Producto Producto, int Cantidad, Imagen Imagen)
        {
            this.Producto = Producto;
            this.Cantidad = Cantidad;
            this.Imagen = Imagen;
        }

        public double calcularTotal()
        {
            return (double)(Producto.Total * Cantidad);
        }
    }
}