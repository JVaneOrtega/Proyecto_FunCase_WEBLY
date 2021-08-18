namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseCompras1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        ComprasID = c.Int(nullable: false, identity: true),
                        FechaCompra = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioCompra = c.Int(nullable: false),
                        NotaCompra = c.String(),
                        FotoTicket = c.String(),
                        ProductoID = c.Int(nullable: false),
                        ProveedorID = c.Int(nullable: false),
                        UsuarioRegistro_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ComprasID)
                .ForeignKey("dbo.Productoes", t => t.ProductoID, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioRegistro_Id)
                .Index(t => t.ProductoID)
                .Index(t => t.ProveedorID)
                .Index(t => t.UsuarioRegistro_Id);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        ProveedorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                        Empresa = c.String(),
                    })
                .PrimaryKey(t => t.ProveedorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "UsuarioRegistro_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Compras", "ProveedorID", "dbo.Proveedors");
            DropForeignKey("dbo.Compras", "ProductoID", "dbo.Productoes");
            DropIndex("dbo.Compras", new[] { "UsuarioRegistro_Id" });
            DropIndex("dbo.Compras", new[] { "ProveedorID" });
            DropIndex("dbo.Compras", new[] { "ProductoID" });
            DropTable("dbo.Proveedors");
            DropTable("dbo.Compras");
        }
    }
}
