using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Funda_Diseno
    {
        public int Funda_DisenoID { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        [Display(Name = "Valor Neto")]
        public double ValorNeto { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual DetallesPedido DetallesPedidos { get; set; }

    }
}