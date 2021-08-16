namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modeloes", "Nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modeloes", "Nombre", c => c.String());
        }
    }
}
