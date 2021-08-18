using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public string Create(long pago)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51HGCWwCm1gD1SlZxTmCbw2u2jIHAwNwVi6GV3DnqS2KLPB7gDti8vmKFZZ8QR6W23cTmw61KXpFUoPvw9j7R1SDf00r6HHHuXp";
                var paymentIntents = new PaymentIntentService();

                var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions

                {

                    Amount = (pago * 100),

                    Currency = "mxn",

                });

                return paymentIntent.ClientSecret;
            }
            catch (Exception)
            {
                throw;
            }

        }       

    }
}