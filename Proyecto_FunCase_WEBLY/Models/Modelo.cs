﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Modelo
    {
        public int ModeloID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Ancho { get; set; }
        [Required]
        public double Alto { get; set; }
        [Required]
        public double Grosor { get; set; }
        [Display(Name = "Imagen de Referencia")]
        public string ImagenReferencia { get; set; }
        [Display(Name = "Estatus del Modelo")]
        public bool Estatus { get; set; }
        [Display(Name = "Marca")]
        public int MarcaID { get; set; }
        public virtual Marca Marca { get; set; }

        public Modelo()
        {
            this.Productos = new HashSet<Producto>();
        }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}