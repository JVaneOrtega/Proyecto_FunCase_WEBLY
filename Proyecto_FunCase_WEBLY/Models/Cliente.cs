using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentitySample.Models;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class Cliente
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Estatus del Cliente")]
        public bool Estatus;
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public Cliente ()
        {
            this.Direcciones = new HashSet<Direccion>();
            this.Pedidos = new HashSet<Pedido>();
        }

        public virtual ICollection<Direccion> Direcciones { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }

}