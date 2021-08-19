namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseDetallesCompra : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compras", "ProductoID", "dbo.Productoes");
            DropIndex("dbo.Compras", new[] { "ProductoID" });
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        DetalleCompraID = c.Int(nullable: false, identity: true),
                        ProductoID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioCompra = c.Double(nullable: false),
                        Compras_ComprasID = c.Int(),
                    })
                .PrimaryKey(t => t.DetalleCompraID)
                .ForeignKey("dbo.Productoes", t => t.ProductoID, cascadeDelete: true)
                .ForeignKey("dbo.Compras", t => t.Compras_ComprasID)
                .Index(t => t.ProductoID)
                .Index(t => t.Compras_ComprasID);
            
            AddColumn("dbo.Compras", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Compras", "Total", c => c.Double(nullable: false));
            DropColumn("dbo.Compras", "Cantidad");
            DropColumn("dbo.Compras", "PrecioCompra");
            DropColumn("dbo.Compras", "ProductoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Compras", "ProductoID", c => c.Int(nullable: false));
            AddColumn("dbo.Compras", "PrecioCompra", c => c.Int(nullable: false));
            AddColumn("dbo.Compras", "Cantidad", c => c.Int(nullable: false));
            DropForeignKey("dbo.DetalleCompras", "Compras_ComprasID", "dbo.Compras");
            DropForeignKey("dbo.DetalleCompras", "ProductoID", "dbo.Productoes");
            DropIndex("dbo.DetalleCompras", new[] { "Compras_ComprasID" });
            DropIndex("dbo.DetalleCompras", new[] { "ProductoID" });
            DropColumn("dbo.Compras", "Total");
            DropColumn("dbo.Compras", "UserId");
            DropTable("dbo.DetalleCompras");
            CreateIndex("dbo.Compras", "ProductoID");
            AddForeignKey("dbo.Compras", "ProductoID", "dbo.Productoes", "ProductoID", cascadeDelete: true);
        }
    }
}
