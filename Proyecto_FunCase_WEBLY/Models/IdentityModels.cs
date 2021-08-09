using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Proyecto_FunCase_WEBLY.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
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
        public virtual DbSet<DetallesPedido> DetallePedidos { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Funda_Diseno> Funda_Disenos { get; set; }
        public virtual DbSet<Imagen> Imagenes { get; set; }
        public virtual DbSet<Imagen_Diseno> Imagen_Disenos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Material> Materiales { get; set; }
        public virtual DbSet<MetodosPago> MetodosPagos { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
    }
}