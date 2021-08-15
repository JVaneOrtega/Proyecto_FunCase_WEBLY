using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Proyecto_FunCase_WEBLY.Models
{
    public class FunCaseModelContext : DbContext
    {
        public FunCaseModelContext() : base("name=FunCaseEntities") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogIns").HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles").HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles").HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        }

        public virtual DbSet<IdentityUserLogin> UserLogin { get; set; }
        public virtual DbSet<IdentityRole> Roles { get; set; }
        public virtual DbSet<IdentityUserRole> UserRoles { get; set; }
        public virtual DbSet<IdentityUserClaim> UserClaims { get; set; }
        public virtual DbSet<ApplicationUser> Users { get; set; }
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