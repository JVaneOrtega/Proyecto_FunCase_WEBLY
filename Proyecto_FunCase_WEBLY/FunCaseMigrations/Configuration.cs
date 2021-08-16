namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using IdentitySample.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

                var roleDesigner = context.Roles.Where(r => r.Name == "Dise�ador").FirstOrDefault();
                if (roleDesigner == null)
                {
                    context.Roles.Add(new IdentityRole { Name = "Dise�ador" });
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
