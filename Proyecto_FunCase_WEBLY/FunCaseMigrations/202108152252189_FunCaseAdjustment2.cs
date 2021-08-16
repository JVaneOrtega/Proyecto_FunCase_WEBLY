namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID", c => c.Int());
            CreateIndex("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID");
            AddForeignKey("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID", "dbo.DetallesPedidoes", "DetallesPedidoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID", "dbo.DetallesPedidoes");
            DropIndex("dbo.Funda_Diseno", new[] { "DetallesPedidos_DetallesPedidoID" });
            DropColumn("dbo.Funda_Diseno", "DetallesPedidos_DetallesPedidoID");
        }
    }
}
