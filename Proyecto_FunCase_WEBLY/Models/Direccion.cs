using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Direccion
    {
        public int DireccionID { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        [Display(Name = "Num. Ext.")]
        public string NumeroExt { get; set; }
        [Display(Name = "Num. Int.")]
        public string NumeroInt { get; set; }
        [Required]
        public string Colonia { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }
        [Display(Name = "Estatus de la Dirección")]
        public bool Estatus { get; set; }

        public string NombreDireccion
        {
            get
            {
                return String.Format("{0} {1} {2}, {3}, {4}", Calle, NumeroExt, NumeroInt, Colonia, CodigoPostal);
            }
        }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
    }
}