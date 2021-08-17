namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materials", "Precio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materials", "Precio", c => c.Double(nullable: false));
        }
    }
}
