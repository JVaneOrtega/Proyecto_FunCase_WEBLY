namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using IdentitySample.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Proyecto_FunCase_WEBLY.Models;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto_FunCase_WEBLY.Models.FunCaseModelContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"FunCaseMigrations";
        }

        protected override void Seed(Proyecto_FunCase_WEBLY.Models.FunCaseModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var rolAdmin = new IdentityRole("Admin");
            context.Roles.AddOrUpdate(rolAdmin);
            context.SaveChanges();

            var rolCliente = new IdentityRole("Cliente");
            context.Roles.AddOrUpdate(rolCliente);
            context.SaveChanges();

            var rolEmpleado = new IdentityRole("Empleado");
            context.Roles.AddOrUpdate(rolEmpleado);
            context.SaveChanges();

            var rolDesigner = new IdentityRole("Diseñador");
            context.Roles.AddOrUpdate(rolDesigner);
            context.SaveChanges();
        }

    }
}
