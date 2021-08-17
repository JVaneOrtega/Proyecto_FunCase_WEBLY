namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        FechaNacimiento = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        DireccionID = c.Int(nullable: false, identity: true),
                        Calle = c.String(nullable: false),
                        NumeroExt = c.String(nullable: false),
                        NumeroInt = c.String(),
                        Colonia = c.String(),
                        CodigoPostal = c.String(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Estadoes", t => t.EstadoID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoID);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        EstatusPedido = c.String(),
                        EstatusPago = c.String(),
                        Referencia = c.String(),
                        Descuento = c.Double(nullable: false),
                        MetodosPagoID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        DireccionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Direccions", t => t.DireccionID, cascadeDelete: false)
                .ForeignKey("dbo.MetodosPagoes", t => t.MetodosPagoID, cascadeDelete: true)
                .Index(t => t.MetodosPagoID)
                .Index(t => t.ClienteID)
                .Index(t => t.DireccionID);
            
            CreateTable(
                "dbo.DetallesPedidoes",
                c => new
                    {
                        DetallesPedidoID = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                        ProductoID = c.Int(nullable: false),
                        PedidoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetallesPedidoID)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoID, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoID, cascadeDelete: true)
                .Index(t => t.ProductoID)
                .Index(t => t.PedidoID);
            
            CreateTable(
                "dbo.Funda_Diseno",
                c => new
                    {
                        Funda_DisenoID = c.Int(nullable: false, identity: true),
                        Imagen = c.String(nullable: false),
                        ValorNeto = c.Double(nullable: false),
                        DetallesPedidoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Funda_DisenoID)
                .ForeignKey("dbo.DetallesPedidoes", t => t.DetallesPedidoID, cascadeDelete: true)
                .Index(t => t.DetallesPedidoID);
            
            CreateTable(
                "dbo.Imagen_Diseno",
                c => new
                    {
                        Imagen_DisenoID = c.Int(nullable: false, identity: true),
                        Funda_DisenoID = c.Int(nullable: false),
                        ImagenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Imagen_DisenoID)
                .ForeignKey("dbo.Funda_Diseno", t => t.Funda_DisenoID, cascadeDelete: true)
                .ForeignKey("dbo.Imagens", t => t.ImagenID, cascadeDelete: true)
                .Index(t => t.Funda_DisenoID)
                .Index(t => t.ImagenID);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        ImagenID = c.Int(nullable: false, identity: true),
                        NombreImagen = c.String(nullable: false),
                        Ruta = c.String(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                        DesignerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImagenID)
                .ForeignKey("dbo.Designers", t => t.DesignerID, cascadeDelete: true)
                .Index(t => t.DesignerID);
            
            CreateTable(
                "dbo.Designers",
                c => new
                    {
                        DesignerID = c.Int(nullable: false, identity: true),
                        NombrePresentacion = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DesignerID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(nullable: false),
                        Apellido1 = c.String(nullable: false),
                        Apellido2 = c.String(),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogIns",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        ImagenFinal = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Total = c.Double(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                        Stock = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        ModeloID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Materials", t => t.MaterialID, cascadeDelete: true)
                .ForeignKey("dbo.Modeloes", t => t.ModeloID, cascadeDelete: true)
                .Index(t => t.MaterialID)
                .Index(t => t.ModeloID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        TieneRelieve = c.Boolean(nullable: false),
                        Color = c.String(),
                        Precio = c.Double(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialID);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        ModeloID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Ancho = c.Double(nullable: false),
                        Alto = c.Double(nullable: false),
                        Grosor = c.Double(nullable: false),
                        ImagenReferencia = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        MarcaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModeloID)
                .ForeignKey("dbo.Marcas", t => t.MarcaID, cascadeDelete: true)
                .Index(t => t.MarcaID);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.MetodosPagoes",
                c => new
                    {
                        MetodosPagoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MetodosPagoID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pedidoes", "MetodosPagoID", "dbo.MetodosPagoes");
            DropForeignKey("dbo.Pedidoes", "DireccionID", "dbo.Direccions");
            DropForeignKey("dbo.Productoes", "ModeloID", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Productoes", "MaterialID", "dbo.Materials");
            DropForeignKey("dbo.DetallesPedidoes", "ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.DetallesPedidoes", "PedidoID", "dbo.Pedidoes");
            DropForeignKey("dbo.Imagen_Diseno", "ImagenID", "dbo.Imagens");
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogIns", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Designers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clientes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Imagens", "DesignerID", "dbo.Designers");
            DropForeignKey("dbo.Imagen_Diseno", "Funda_DisenoID", "dbo.Funda_Diseno");
            DropForeignKey("dbo.Funda_Diseno", "DetallesPedidoID", "dbo.DetallesPedidoes");
            DropForeignKey("dbo.Pedidoes", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Direccions", "EstadoID", "dbo.Estadoes");
            DropForeignKey("dbo.Direccions", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Modeloes", new[] { "MarcaID" });
            DropIndex("dbo.Productoes", new[] { "ModeloID" });
            DropIndex("dbo.Productoes", new[] { "MaterialID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogIns", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Designers", new[] { "UserId" });
            DropIndex("dbo.Imagens", new[] { "DesignerID" });
            DropIndex("dbo.Imagen_Diseno", new[] { "ImagenID" });
            DropIndex("dbo.Imagen_Diseno", new[] { "Funda_DisenoID" });
            DropIndex("dbo.Funda_Diseno", new[] { "DetallesPedidoID" });
            DropIndex("dbo.DetallesPedidoes", new[] { "PedidoID" });
            DropIndex("dbo.DetallesPedidoes", new[] { "ProductoID" });
            DropIndex("dbo.Pedidoes", new[] { "DireccionID" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteID" });
            DropIndex("dbo.Pedidoes", new[] { "MetodosPagoID" });
            DropIndex("dbo.Direccions", new[] { "EstadoID" });
            DropIndex("dbo.Direccions", new[] { "ClienteID" });
            DropIndex("dbo.Clientes", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MetodosPagoes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Materials");
            DropTable("dbo.Productoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogIns");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Designers");
            DropTable("dbo.Imagens");
            DropTable("dbo.Imagen_Diseno");
            DropTable("dbo.Funda_Diseno");
            DropTable("dbo.DetallesPedidoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Direccions");
            DropTable("dbo.Clientes");
        }
    }
}
