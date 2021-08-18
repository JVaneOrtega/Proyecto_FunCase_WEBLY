﻿using Microsoft.AspNet.Identity;
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

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]

        public JsonResult UpdatePayment(Payment payment)
        {
            try
            {
                var pedido = db.Pedidos.Single(x => x.PedidoID == payment.idPedido);

                if (payment.status)
                {
                    pedido.EstatusPago = "Pagado";
                    pedido.Referencia = payment.paymentIntentId;
                }
                else
                {                    
                    pedido.EstatusPago = "Rechazado";
                }

                db.SaveChanges();

                return Json(new { message = "Correcto", status = true });
            }
            catch(Exception e)
            {
                return Json(new { message = "Server Error", error = e.Message, trace = e.StackTrace, status = false, paymentR = payment });
            }
        }
    }
}
