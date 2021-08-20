namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAjusteCompra : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleCompras", "Compras_ComprasID", "dbo.Compras");
            DropIndex("dbo.DetalleCompras", new[] { "Compras_ComprasID" });
            RenameColumn(table: "dbo.DetalleCompras", name: "Compras_ComprasID", newName: "ComprasID");
            AlterColumn("dbo.DetalleCompras", "ComprasID", c => c.Int(nullable: false));
            CreateIndex("dbo.DetalleCompras", "ComprasID");
            AddForeignKey("dbo.DetalleCompras", "ComprasID", "dbo.Compras", "ComprasID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleCompras", "ComprasID", "dbo.Compras");
            DropIndex("dbo.DetalleCompras", new[] { "ComprasID" });
            AlterColumn("dbo.DetalleCompras", "ComprasID", c => c.Int());
            RenameColumn(table: "dbo.DetalleCompras", name: "ComprasID", newName: "Compras_ComprasID");
            CreateIndex("dbo.DetalleCompras", "Compras_ComprasID");
            AddForeignKey("dbo.DetalleCompras", "Compras_ComprasID", "dbo.Compras", "ComprasID");
        }
    }
}
