namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "TieneRelieve", c => c.Boolean(nullable: false));
            AddColumn("dbo.Materials", "Estatus", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "Estatus");
            DropColumn("dbo.Materials", "TieneRelieve");
        }
    }
}
