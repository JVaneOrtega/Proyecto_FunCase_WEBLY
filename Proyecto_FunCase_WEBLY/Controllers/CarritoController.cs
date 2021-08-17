using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class CarritoController : Controller
    {
        private FunCaseModelContext db = new FunCaseModelContext();

        [HttpPost]
        public JsonResult AgregaCarrito(int idProducto, int idImagen, int cantidad)
        {
            if(Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.Productos.Find(idProducto), cantidad, db.Imagenes.Find(idImagen)));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];

                int indexExistente = getIndex(idProducto, idImagen);
                if(indexExistente == -1)
                {
                    compras.Add(new CarritoItem(db.Productos.Find(idProducto), cantidad, db.Imagenes.Find(idImagen)));
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

        public ActionResult Delete(int idProducto, int idImagen)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(idProducto, idImagen));

            return View("AgregaCarrito");
        }

        [Authorize(Roles = "Cliente")]
        [HttpGet]
        public ActionResult ConfirmarPedido()
        {
            if(Session["carrito"] != null) {
                string currentUserId = User.Identity.GetUserId();
                Cliente cliente = db.Clientes.Single(c => c.UserId == currentUserId);

                ViewBag.DireccionID = new SelectList(db.Direcciones.Where(d => d.ClienteID == cliente.ClienteID), "DireccionID", "Calle,NumExt");
                ViewBag.MetodosPagoID = new SelectList(db.MetodosPagos, "MetodosPagoID", "Nombre");
                ViewBag.Producto = 1;
            } else
            {
                ViewBag.Productos = 0;
            }

            return View();
        }
        
        [HttpPost]
        public ActionResult FinalizarPedido(Pedido pedido)
        {
            if(Session["carrito"] != null)
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                if(compras != null && compras.Count > 0)
                {

                    string currentUserId = User.Identity.GetUserId();
                    double total = compras.Sum(x => x.Producto.Total * x.Cantidad);

                    pedido.ClienteID = db.Clientes.Where(c => c.UserId == currentUserId).FirstOrDefault().ClienteID;
                    pedido.EstatusPedido = "Generado";
                    pedido.EstatusPago = "Generado";
                    pedido.Total = total;

                    db.Pedidos.Add(pedido);
                    db.SaveChanges();

                    List<DetallesPedido> detalles = new List<DetallesPedido>();
                    foreach(var compra in compras)
                    {
                        DetallesPedido dp = new DetallesPedido { ProductoID = compra.Producto.ProductoID,
                                                                 PrecioUnitario = compra.Producto.Total,
                                                                 Cantidad = compra.Cantidad,
                                                                 PedidoID = pedido.PedidoID };
                        db.DetallePedidos.Add(dp);
                        db.SaveChanges();

                        Producto producto = db.Productos.Single(p => p.ProductoID == compra.Producto.ProductoID);
                        producto.Stock -= compra.Cantidad;
                        db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        Funda_Diseno fd = new Funda_Diseno { Imagen = compra.Imagen.Ruta,
                                                             ValorNeto = compra.Producto.Total,
                                                             DetallesPedidoID = dp.DetallesPedidoID };
                        db.Funda_Disenos.Add(fd);
                        db.SaveChanges();

                        Imagen_Diseno id = new Imagen_Diseno { ImagenID = compra.Imagen.ImagenID,
                                                               Funda_DisenoID = fd.Funda_DisenoID };

                        db.Imagen_Disenos.Add(id);
                        db.SaveChanges();
                    }
                    
                }

                RedirectToAction("Index");
            }

            return View();
        }

        private int getIndex(int idProducto, int idImagen)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.ProductoID == idProducto && compras[i].Imagen.ImagenID == idImagen)
                    return i;
            }

            return -1;
        }
    }

}
