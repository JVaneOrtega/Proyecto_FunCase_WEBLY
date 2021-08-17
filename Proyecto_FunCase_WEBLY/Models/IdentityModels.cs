using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Proyecto_FunCase_WEBLY.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        [MinLength(10),MaxLength(10)]
        public string Telefono { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Designer> Designers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("FunCaseEntities")
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            //Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Designer> Designers { get; set; }
    }
}