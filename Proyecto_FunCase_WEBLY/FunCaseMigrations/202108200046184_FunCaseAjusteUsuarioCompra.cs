namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAjusteUsuarioCompra : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Compras", new[] { "UsuarioRegistro_Id" });
            DropColumn("dbo.Compras", "UserId");
            RenameColumn(table: "dbo.Compras", name: "UsuarioRegistro_Id", newName: "UserId");
            AlterColumn("dbo.Compras", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Compras", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Compras", new[] { "UserId" });
            AlterColumn("dbo.Compras", "UserId", c => c.String());
            RenameColumn(table: "dbo.Compras", name: "UserId", newName: "UsuarioRegistro_Id");
            AddColumn("dbo.Compras", "UserId", c => c.String());
            CreateIndex("dbo.Compras", "UsuarioRegistro_Id");
        }
    }
}
