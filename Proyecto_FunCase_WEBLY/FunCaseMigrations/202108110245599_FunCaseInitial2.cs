namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseInitial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetallesPedidoes", "Cliente_UserId", "dbo.Clientes");
            DropForeignKey("dbo.DetallesPedidoes", "Pedido_PedidoID", "dbo.Pedidoes");
            DropForeignKey("dbo.DetallesPedidoes", "Producto_ProductoID", "dbo.Productoes");
            DropIndex("dbo.DetallesPedidoes", new[] { "Cliente_UserId" });
            DropIndex("dbo.DetallesPedidoes", new[] { "Pedido_PedidoID" });
            DropIndex("dbo.DetallesPedidoes", new[] { "Producto_ProductoID" });
            AddColumn("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID", c => c.Int());
            CreateIndex("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID");
            AddForeignKey("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID", "dbo.DetallesPedidoes", "DetallesPedidoID");
            DropColumn("dbo.DetallesPedidoes", "Cliente_UserId");
            DropColumn("dbo.DetallesPedidoes", "Pedido_PedidoID");
            DropColumn("dbo.DetallesPedidoes", "Producto_ProductoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetallesPedidoes", "Producto_ProductoID", c => c.Int());
            AddColumn("dbo.DetallesPedidoes", "Pedido_PedidoID", c => c.Int());
            AddColumn("dbo.DetallesPedidoes", "Cliente_UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID", "dbo.DetallesPedidoes");
            DropIndex("dbo.Funda_Diseno", new[] { "DetallesPedidos_DetallesPedidoID" });
            DropColumn("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID");
            CreateIndex("dbo.DetallesPedidoes", "Producto_ProductoID");
            CreateIndex("dbo.DetallesPedidoes", "Pedido_PedidoID");
            CreateIndex("dbo.DetallesPedidoes", "Cliente_UserId");
            AddForeignKey("dbo.DetallesPedidoes", "Producto_ProductoID", "dbo.Productoes", "ProductoID");
            AddForeignKey("dbo.DetallesPedidoes", "Pedido_PedidoID", "dbo.Pedidoes", "PedidoID");
            AddForeignKey("dbo.DetallesPedidoes", "Cliente_UserId", "dbo.Clientes", "UserId");
        }
    }
}
