namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseDireccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Direccions", "Ciudad", c => c.String(nullable: false));
            AlterColumn("dbo.Direccions", "Colonia", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Direccions", "Colonia", c => c.String());
            DropColumn("dbo.Direccions", "Ciudad");
        }
    }
}
