namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Direccions", "Estatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Pedidoes", "EstatusPedido", c => c.String());
            AddColumn("dbo.Pedidoes", "EstatusPago", c => c.String());
            AddColumn("dbo.Imagens", "Estatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Productoes", "Estatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Modeloes", "Estatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Marcas", "Estatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.MetodosPagoes", "Estatus", c => c.Boolean(nullable: false, defaultValue: true));
            AlterColumn("dbo.Marcas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.MetodosPagoes", "Nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MetodosPagoes", "Nombre", c => c.String());
            AlterColumn("dbo.Marcas", "Nombre", c => c.String());
            DropColumn("dbo.MetodosPagoes", "Estatus");
            DropColumn("dbo.Marcas", "Estatus");
            DropColumn("dbo.Modeloes", "Estatus");
            DropColumn("dbo.Productoes", "Estatus");
            DropColumn("dbo.Imagens", "Estatus");
            DropColumn("dbo.Pedidoes", "EstatusPago");
            DropColumn("dbo.Pedidoes", "EstatusPedido");
            DropColumn("dbo.Direccions", "Estatus");
        }
    }
}
