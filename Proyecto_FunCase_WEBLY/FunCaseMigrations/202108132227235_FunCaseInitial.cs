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
                        NumeroInt = c.String(nullable: false),
                        Colonia = c.String(),
                        CodigoPostal = c.String(nullable: false),
                        Cliente_ClienteID = c.Int(),
                        Estado_EstadoID = c.Int(),
                    })
                .PrimaryKey(t => t.DireccionID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .ForeignKey("dbo.Estadoes", t => t.Estado_EstadoID)
                .Index(t => t.Cliente_ClienteID)
                .Index(t => t.Estado_EstadoID);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EstadoID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                        Telefono = c.String(),
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
                "dbo.Designers",
                c => new
                    {
                        DesignerID = c.Int(nullable: false, identity: true),
                        NombrePresentacion = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DesignerID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "dbo.DetallesPedidoes",
                c => new
                    {
                        DetallesPedidoID = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Cliente_ClienteID = c.Int(),
                        Pedido_PedidoID = c.Int(),
                        Producto_ProductoID = c.Int(),
                    })
                .PrimaryKey(t => t.DetallesPedidoID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_PedidoID)
                .ForeignKey("dbo.Productoes", t => t.Producto_ProductoID)
                .Index(t => t.Cliente_ClienteID)
                .Index(t => t.Pedido_PedidoID)
                .Index(t => t.Producto_ProductoID);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        Referencia = c.String(),
                        Descuento = c.Double(nullable: false),
                        MetodoPago_MetodosPagoID = c.Int(),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.MetodosPagoes", t => t.MetodoPago_MetodosPagoID)
                .Index(t => t.MetodoPago_MetodosPagoID);
            
            CreateTable(
                "dbo.MetodosPagoes",
                c => new
                    {
                        MetodosPagoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.MetodosPagoID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        ImagenFinal = c.String(nullable: false),
                        Nombre = c.String(),
                        Total = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        Material_MaterialID = c.Int(),
                        Modelo_ModeloID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Materials", t => t.Material_MaterialID)
                .ForeignKey("dbo.Modeloes", t => t.Modelo_ModeloID)
                .Index(t => t.Material_MaterialID)
                .Index(t => t.Modelo_ModeloID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Color = c.String(),
                        Precio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialID);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        ModeloID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Ancho = c.Double(nullable: false),
                        Alto = c.Double(nullable: false),
                        Grosor = c.Double(nullable: false),
                        ImagenReferencia = c.String(),
                        Marca_MarcaID = c.Int(),
                    })
                .PrimaryKey(t => t.ModeloID)
                .ForeignKey("dbo.Marcas", t => t.Marca_MarcaID)
                .Index(t => t.Marca_MarcaID);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.Funda_Diseno",
                c => new
                    {
                        Funda_DisenoID = c.Int(nullable: false, identity: true),
                        Imagen = c.String(),
                        ValorNeto = c.Double(nullable: false),
                        Cliente_ClienteID = c.Int(),
                        Producto_ProductoID = c.Int(),
                    })
                .PrimaryKey(t => t.Funda_DisenoID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .ForeignKey("dbo.Productoes", t => t.Producto_ProductoID)
                .Index(t => t.Cliente_ClienteID)
                .Index(t => t.Producto_ProductoID);
            
            CreateTable(
                "dbo.Imagen_Diseno",
                c => new
                    {
                        Imagen_DisenoID = c.Int(nullable: false, identity: true),
                        FundaDiseno_Funda_DisenoID = c.Int(),
                        Imagen_ImagenID = c.Int(),
                    })
                .PrimaryKey(t => t.Imagen_DisenoID)
                .ForeignKey("dbo.Funda_Diseno", t => t.FundaDiseno_Funda_DisenoID)
                .ForeignKey("dbo.Imagens", t => t.Imagen_ImagenID)
                .Index(t => t.FundaDiseno_Funda_DisenoID)
                .Index(t => t.Imagen_ImagenID);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        ImagenID = c.Int(nullable: false, identity: true),
                        NombreImagen = c.String(nullable: false),
                        Ruta = c.String(),
                        Designer_DesignerID = c.Int(),
                    })
                .PrimaryKey(t => t.ImagenID)
                .ForeignKey("dbo.Designers", t => t.Designer_DesignerID)
                .Index(t => t.Designer_DesignerID);
            
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
            DropForeignKey("dbo.Imagen_Diseno", "Imagen_ImagenID", "dbo.Imagens");
            DropForeignKey("dbo.Imagens", "Designer_DesignerID", "dbo.Designers");
            DropForeignKey("dbo.Imagen_Diseno", "FundaDiseno_Funda_DisenoID", "dbo.Funda_Diseno");
            DropForeignKey("dbo.Funda_Diseno", "Producto_ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Funda_Diseno", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.DetallesPedidoes", "Producto_ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "Modelo_ModeloID", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "Marca_MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Productoes", "Material_MaterialID", "dbo.Materials");
            DropForeignKey("dbo.DetallesPedidoes", "Pedido_PedidoID", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "MetodoPago_MetodosPagoID", "dbo.MetodosPagoes");
            DropForeignKey("dbo.DetallesPedidoes", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogIns", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Designers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clientes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Direccions", "Estado_EstadoID", "dbo.Estadoes");
            DropForeignKey("dbo.Direccions", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Imagens", new[] { "Designer_DesignerID" });
            DropIndex("dbo.Imagen_Diseno", new[] { "Imagen_ImagenID" });
            DropIndex("dbo.Imagen_Diseno", new[] { "FundaDiseno_Funda_DisenoID" });
            DropIndex("dbo.Funda_Diseno", new[] { "Producto_ProductoID" });
            DropIndex("dbo.Funda_Diseno", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Modeloes", new[] { "Marca_MarcaID" });
            DropIndex("dbo.Productoes", new[] { "Modelo_ModeloID" });
            DropIndex("dbo.Productoes", new[] { "Material_MaterialID" });
            DropIndex("dbo.Pedidoes", new[] { "MetodoPago_MetodosPagoID" });
            DropIndex("dbo.DetallesPedidoes", new[] { "Producto_ProductoID" });
            DropIndex("dbo.DetallesPedidoes", new[] { "Pedido_PedidoID" });
            DropIndex("dbo.DetallesPedidoes", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogIns", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Designers", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Direccions", new[] { "Estado_EstadoID" });
            DropIndex("dbo.Direccions", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Clientes", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Imagens");
            DropTable("dbo.Imagen_Diseno");
            DropTable("dbo.Funda_Diseno");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Materials");
            DropTable("dbo.Productoes");
            DropTable("dbo.MetodosPagoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetallesPedidoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogIns");
            DropTable("dbo.Designers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Direccions");
            DropTable("dbo.Clientes");
        }
    }
}
