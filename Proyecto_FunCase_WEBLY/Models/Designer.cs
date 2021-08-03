using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Designer
    {
        public int DesignerID { get; set; }
        public string nombrePresentacion { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}