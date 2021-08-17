using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class CarritoController : Controller
    {
        private CarritoBDEntities ce = new CarritoBDEntities();

        // POST: Método de Acción que permite agregar un nuevo producto al carrito
        [HttpPost]
        //public ActionResult AgregaCarrito(int id)
        public JsonResult AgregaCarrito(int id, int cantidad)
        {
            //Verificamos si la variable de sesión "carrito" ya existe.
            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(ce.Producto.Find(id), cantidad));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];

                int indexExistente = getIndex(id);
                if (indexExistente == -1)
                {
                    compras.Add(new CarritoItem(ce.Producto.Find(id), cantidad));
                }
                else
                {
                    compras[indexExistente].Cantidad += cantidad;
                }
                Session["carrito"] = compras;
            }
            return Json(new { response = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AgregaCarrito()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));

            return View("AgregaCarrito");
        }

        public ActionResult FinalizarCompra()
        {
            if (Session["carrito"] != null)
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                if (compras != null && compras.Count > 0)
                {
                    Venta nuevaVenta = new Venta();
                    nuevaVenta.DiaVenta = DateTime.Now;
                    nuevaVenta.Subtotal = compras.Sum(x => x.Producto.Precio * x.Cantidad);
                    nuevaVenta.Iva = nuevaVenta.Subtotal * 0.16;
                    nuevaVenta.Total = nuevaVenta.Iva + nuevaVenta.Subtotal;
                    nuevaVenta.ListaVenta = (from Producto in compras
                                             select new ListaVenta
                                             {
                                                 ProductoId = Producto.Producto.Id,
                                                 Cantidad = Producto.Cantidad,
                                                 Total = (Producto.Producto.Precio * Producto.Cantidad)
                                             }).ToList();
                    ce.Venta.Add(nuevaVenta);
                    ce.SaveChanges();
                }
            }

            return View();
        }

        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.Id == id)
                    return i;
            }

            return -1;
        }

        // GET: ProductoCarrito
        public ActionResult IndexProducto()
        {
            return View(ce.Producto.ToList().OrderBy(x => x.Nombre));
        }
    }
}