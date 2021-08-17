namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Direccions", "NumeroInt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Direccions", "NumeroInt", c => c.String(nullable: false));
        }
    }
}
