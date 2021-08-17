namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Telefono", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Telefono", c => c.String(nullable: false));
        }
    }
}
