using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string Apellido1 { get; set; }

        [Display(Name = "Apellido Materno")]
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}