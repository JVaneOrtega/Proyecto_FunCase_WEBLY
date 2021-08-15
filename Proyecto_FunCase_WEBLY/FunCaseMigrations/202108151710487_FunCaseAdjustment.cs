namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetallesPedidoes", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.DetallesPedidoes", new[] { "Cliente_ClienteID" });
            AddColumn("dbo.DetallesPedidoes", "PrecioUnitario", c => c.Double(nullable: false));
            AddColumn("dbo.Pedidoes", "Cliente_ClienteID", c => c.Int());
            CreateIndex("dbo.Pedidoes", "Cliente_ClienteID");
            AddForeignKey("dbo.Pedidoes", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
            DropColumn("dbo.DetallesPedidoes", "Cliente_ClienteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetallesPedidoes", "Cliente_ClienteID", c => c.Int());
            DropForeignKey("dbo.Pedidoes", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Pedidoes", new[] { "Cliente_ClienteID" });
            DropColumn("dbo.Pedidoes", "Cliente_ClienteID");
            DropColumn("dbo.DetallesPedidoes", "PrecioUnitario");
            CreateIndex("dbo.DetallesPedidoes", "Cliente_ClienteID");
            AddForeignKey("dbo.DetallesPedidoes", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
        }
    }
}
