using Microsoft.AspNet.Identity;
using Proyecto_FunCase_WEBLY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize(Roles = "Empleado,Cliente")]
    public class PedidosController : Controller
    {
        FunCaseModelContext db = new FunCaseModelContext();
        // GET: Pedidos
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            Cliente cliente = db.Clientes.Where(c => c.UserId == currentUserId).FirstOrDefault();
            if(cliente != null)
            {
                return View(db.Pedidos.Where(p => p.ClienteID == cliente.ClienteID).ToList());
            }
            return View(db.Pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Pedidos.Find(id));
        }

        [Authorize(Roles = "Empleado")]
        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Pedidos.Find(id));
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pedido pedido = db.Pedidos.Find(id);
                pedido.EstatusPedido = "Cancelado";
                db.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]

        public JsonResult UpdatePayment(int idPedido, bool status, string paymentIntentId)
        {
            try
            {
                var pedido = db.Pedidos.Single(x => x.PedidoID == idPedido);

                if (status)
                {
                    pedido.EstatusPago = "Pagado";
                    pedido.Referencia = paymentIntentId;
                }
                else
                {                    
                    pedido.EstatusPago = "Rechazado";
                }

                db.SaveChanges();

                return Json(new { message = "Correcto", status = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { message = "Server Error", error = e.Message, trace = e.StackTrace, status = false});
            }
        }

        [HttpGet]
        public JsonResult ActualizarPedidoEnviado(int idPedido)
        {
            try
            {
                Pedido pedido = db.Pedidos.Find(idPedido);
                if(pedido != null)
                {
                    pedido.EstatusPedido = "Enviado";
                    db.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { response = true, mensaje = "Pedido enviado" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { response = false, mensaje = "Pedido no encontrado" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { response = false, mensaje = "Error del servidor" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ActualizarPedidoEntregado(int idPedido)
        {
            try
            {
                Pedido pedido = db.Pedidos.Find(idPedido);
                if (pedido != null)
                {
                    pedido.EstatusPedido = "Entregado";
                    db.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { response = true, mensaje = "Pedido enviado" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { response = false, mensaje = "Pedido no encontrado" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { response = false, mensaje = "Error del servidor" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
