namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseAdjustment3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Apellido1", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Apellido1", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Nombre", c => c.String());
        }
    }
}
