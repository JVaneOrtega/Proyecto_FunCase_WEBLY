﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Payment
    {
        public int idPedido;
        public string paymentIntentId;
        public bool status;
    }
}