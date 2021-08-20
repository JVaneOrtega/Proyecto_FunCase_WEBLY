using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Proveedor
    {
        public int ProveedorID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        public string Empresa { get; set; }
        public bool Estatus { get; set; }

        public string NombreCompleto
        {
            get
            {
                return String.Format("{0} {1} {2} / {3}", Nombre, Apellido1, Apellido2, Email);
            }
        }
    }
}