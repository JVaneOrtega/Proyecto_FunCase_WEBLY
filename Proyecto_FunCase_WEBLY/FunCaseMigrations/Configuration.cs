namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using IdentitySample.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Proyecto_FunCase_WEBLY.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto_FunCase_WEBLY.Models.FunCaseModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"FunCaseMigrations";
        }

        protected override void Seed(Proyecto_FunCase_WEBLY.Models.FunCaseModelContext context)
        {
            try
            {
                var roleAdmin = context.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
                if (roleAdmin == null)
                {
                    roleAdmin = context.Roles.Add(new IdentityRole { Name = "Admin" });
                }

                var roleEmpleado = context.Roles.Where(r => r.Name == "Empleado").FirstOrDefault();
                if (roleEmpleado == null)
                {
                    context.Roles.Add(new IdentityRole { Name = "Empleado" });
                }

                var roleCliente = context.Roles.Where(r => r.Name == "Cliente").FirstOrDefault();
                if (roleCliente == null)
                {
                    context.Roles.Add(new IdentityRole { Name = "Cliente" });
                }

                var roleDesigner = context.Roles.Where(r => r.Name == "Diseñador").FirstOrDefault();
                if (roleDesigner == null)
                {
                    context.Roles.Add(new IdentityRole { Name = "Diseñador" });
                }

                var userAdmin = context.Users.Where(u => u.Email == "admin@example.com").FirstOrDefault();
                if (userAdmin == null)
                {
                    const string name = "admin@example.com";
                    const string password = "Admin@123456";
                    var hasher = new PasswordHasher();
                    userAdmin = context.Users.Add(new ApplicationUser { Nombre = "Admin", Apellido1 = "A", Apellido2 = "D", Telefono = "4771234567", UserName = name, Email = name, EmailConfirmed = true, PasswordHash = hasher.HashPassword(password), SecurityStamp = Guid.NewGuid().ToString() });
                    context.UserRoles.Add(new IdentityUserRole { UserId = userAdmin.Id, RoleId = roleAdmin.Id });
                }

                context.Estados.Add(new Estado { Nombre = "Aguascalientes" });
                context.Estados.Add(new Estado { Nombre = "Baja California" });
                context.Estados.Add(new Estado { Nombre = "Baja California Sur" });
                context.Estados.Add(new Estado { Nombre = "Campeche" });
                context.Estados.Add(new Estado { Nombre = "Chiapas" });
                context.Estados.Add(new Estado { Nombre = "Chihuahua" });
                context.Estados.Add(new Estado { Nombre = "Ciudad de México" });
                context.Estados.Add(new Estado { Nombre = "Coahuila" });
                context.Estados.Add(new Estado { Nombre = "Colima" });
                context.Estados.Add(new Estado { Nombre = "Durango" });
                context.Estados.Add(new Estado { Nombre = "Estado de México" });
                context.Estados.Add(new Estado { Nombre = "Guanajuato" });
                context.Estados.Add(new Estado { Nombre = "Guerrero" });
                context.Estados.Add(new Estado { Nombre = "Hidalgo" });
                context.Estados.Add(new Estado { Nombre = "Jalisco" });
                context.Estados.Add(new Estado { Nombre = "Michoacán" });
                context.Estados.Add(new Estado { Nombre = "Morelos" });
                context.Estados.Add(new Estado { Nombre = "Nayarit" });
                context.Estados.Add(new Estado { Nombre = "Nuevo León" });
                context.Estados.Add(new Estado { Nombre = "Oaxaca" });
                context.Estados.Add(new Estado { Nombre = "Puebla" });
                context.Estados.Add(new Estado { Nombre = "Querétaro" });
                context.Estados.Add(new Estado { Nombre = "Quintana Roo" });
                context.Estados.Add(new Estado { Nombre = "San Luis Potosí" });
                context.Estados.Add(new Estado { Nombre = "Sinaloa" });
                context.Estados.Add(new Estado { Nombre = "Sonora" });
                context.Estados.Add(new Estado { Nombre = "Tabasco" });
                context.Estados.Add(new Estado { Nombre = "Tamaulipas" });
                context.Estados.Add(new Estado { Nombre = "Tlaxcala" });
                context.Estados.Add(new Estado { Nombre = "Veracruz" });
                context.Estados.Add(new Estado { Nombre = "Yucatán" });
                context.Estados.Add(new Estado { Nombre = "Zacatecas" });

                var stripe = context.MetodosPagos.Where(m => m.Nombre == "Stripe").FirstOrDefault();
                if(stripe == null)
                {
                    context.MetodosPagos.Add(new MetodosPago { Nombre = "Stripe" });
                }

                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}