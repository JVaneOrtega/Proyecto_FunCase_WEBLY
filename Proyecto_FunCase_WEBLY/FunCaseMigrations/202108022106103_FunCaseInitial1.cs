namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseInitial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas");
            DropIndex("dbo.Clientes", new[] { "Persona_PersonaID" });
            AddColumn("dbo.DetallesPedidoes", "Pedido_PedidoID", c => c.Int());
            AlterColumn("dbo.Clientes", "Persona_PersonaID", c => c.Int(nullable: false));
            AlterColumn("dbo.Personas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "Apellido1", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "Apellido2", c => c.String(nullable: false));
            CreateIndex("dbo.Clientes", "Persona_PersonaID");
            CreateIndex("dbo.DetallesPedidoes", "Pedido_PedidoID");
            AddForeignKey("dbo.DetallesPedidoes", "Pedido_PedidoID", "dbo.Pedidoes", "PedidoID");
            AddForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas", "PersonaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.DetallesPedidoes", "Pedido_PedidoID", "dbo.Pedidoes");
            DropIndex("dbo.DetallesPedidoes", new[] { "Pedido_PedidoID" });
            DropIndex("dbo.Clientes", new[] { "Persona_PersonaID" });
            AlterColumn("dbo.Personas", "Apellido2", c => c.String());
            AlterColumn("dbo.Personas", "Apellido1", c => c.String());
            AlterColumn("dbo.Personas", "Nombre", c => c.String());
            AlterColumn("dbo.Clientes", "Persona_PersonaID", c => c.Int());
            DropColumn("dbo.DetallesPedidoes", "Pedido_PedidoID");
            CreateIndex("dbo.Clientes", "Persona_PersonaID");
            AddForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas", "PersonaID");
        }
    }
}
