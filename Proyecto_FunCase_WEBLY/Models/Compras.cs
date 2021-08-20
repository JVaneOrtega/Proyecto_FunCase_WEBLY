using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Compras
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComprasID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Compra")]
        public DateTime FechaCompra { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [Display(Name = "Nota")]
        public string NotaCompra { get; set; }
        [Display(Name = "Foto del Ticket")]
        public string FotoTicket { get; set; }
        [Required]
        public double Total { get; set; }
        public string EstatusCompra { get; set; }
        public int ProveedorID { get; set; }
        public virtual Proveedor Proveedor {get; set;}

        public Compras()
        {
            this.DetalleCompras = new HashSet<DetalleCompra>();
        }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}