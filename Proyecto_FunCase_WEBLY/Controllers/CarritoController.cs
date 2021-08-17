using Microsoft.AspNet.Identity;
using Proyecto_FunCase_WEBLY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

                int indexExistente = getIndex(idProducto);
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

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));

            return View("AgregaCarrito");
        }

        public ActionResult FinalizarPedido()
        {
            if(Session["carrito"] != null)
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                if(compras != null && compras.Count > 0)
                {
                    Pedido pedido = new Pedido();

                    pedido.ClienteID = db.Clientes.Where(c => c.UserId == User.Identity.GetUserId()).FirstOrDefault().ClienteID;
                    pedido.EstatusPedido = "Iniciado";
                    pedido.EstatusPago = "Generado";
                    pedido.MetodosPagoID = db.MetodosPagos.Where(m => m.Nombre == "Stripe").FirstOrDefault().MetodosPagoID;

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

                        Funda_Diseno fd = new Funda_Diseno { Imagen = compra.Producto.ImagenFinal,
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
            }

            return View();
        }

        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i< compras.Count; i++)
            {
                if (compras[i].Producto.ProductoID == id)
                    return i;
            }

            return -1;
        }
    }

}
