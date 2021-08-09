namespace Proyecto_FunCase_WEBLY.FunCaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunCaseInitial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.Designers", "Persona_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.DetallesPedidoes", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Direccions", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Funda_Diseno", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Imagens", "Designer_DesignerID", "dbo.Designers");
            DropIndex("dbo.Clientes", new[] { "Persona_PersonaID" });
            DropIndex("dbo.Designers", new[] { "Persona_PersonaID" });
            DropIndex("dbo.DetallesPedidoes", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Direccions", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Funda_Diseno", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Imagens", new[] { "Designer_DesignerID" });
            RenameColumn(table: "dbo.DetallesPedidoes", name: "Cliente_ClienteID", newName: "Cliente_UserId");
            RenameColumn(table: "dbo.Direccions", name: "Cliente_ClienteID", newName: "Cliente_UserId");
            RenameColumn(table: "dbo.Funda_Diseno", name: "Cliente_ClienteID", newName: "Cliente_UserId");
            RenameColumn(table: "dbo.Imagens", name: "Designer_DesignerID", newName: "Designer_UserId");
            DropPrimaryKey("dbo.Clientes");
            DropPrimaryKey("dbo.Designers");
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Designers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clientes", "ClienteID", c => c.Int(nullable: false));
            AlterColumn("dbo.Designers", "DesignerID", c => c.Int(nullable: false));
            AlterColumn("dbo.DetallesPedidoes", "Cliente_UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Direccions", "Cliente_UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Funda_Diseno", "Cliente_UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Imagens", "Designer_UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Clientes", "UserId");
            AddPrimaryKey("dbo.Designers", "UserId");
            CreateIndex("dbo.Clientes", "UserId");
            CreateIndex("dbo.Designers", "UserId");
            CreateIndex("dbo.DetallesPedidoes", "Cliente_UserId");
            CreateIndex("dbo.Direccions", "Cliente_UserId");
            CreateIndex("dbo.Funda_Diseno", "Cliente_UserId");
            CreateIndex("dbo.Imagens", "Designer_UserId");
            AddForeignKey("dbo.Clientes", "UserId", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.Designers", "UserId", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.DetallesPedidoes", "Cliente_UserId", "dbo.Clientes", "UserId");
            AddForeignKey("dbo.Direccions", "Cliente_UserId", "dbo.Clientes", "UserId");
            AddForeignKey("dbo.Funda_Diseno", "Cliente_UserId", "dbo.Clientes", "UserId");
            AddForeignKey("dbo.Imagens", "Designer_UserId", "dbo.Designers", "UserId");
            DropColumn("dbo.Clientes", "User_Email");
            DropColumn("dbo.Clientes", "User_Password");
            DropColumn("dbo.Clientes", "User_ConfirmPassword");
            DropColumn("dbo.Clientes", "Persona_PersonaID");
            DropColumn("dbo.Designers", "User_Email");
            DropColumn("dbo.Designers", "User_Password");
            DropColumn("dbo.Designers", "User_ConfirmPassword");
            DropColumn("dbo.Designers", "Persona_PersonaID");
            DropTable("dbo.Personas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido1 = c.String(nullable: false),
                        Apellido2 = c.String(nullable: false),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.PersonaID);
            
            AddColumn("dbo.Designers", "Persona_PersonaID", c => c.Int());
            AddColumn("dbo.Designers", "User_ConfirmPassword", c => c.String());
            AddColumn("dbo.Designers", "User_Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Designers", "User_Email", c => c.String(nullable: false));
            AddColumn("dbo.Clientes", "Persona_PersonaID", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "User_ConfirmPassword", c => c.String());
            AddColumn("dbo.Clientes", "User_Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Clientes", "User_Email", c => c.String(nullable: false));
            DropForeignKey("dbo.Imagens", "Designer_UserId", "dbo.Designers");
            DropForeignKey("dbo.Funda_Diseno", "Cliente_UserId", "dbo.Clientes");
            DropForeignKey("dbo.Direccions", "Cliente_UserId", "dbo.Clientes");
            DropForeignKey("dbo.DetallesPedidoes", "Cliente_UserId", "dbo.Clientes");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Designers", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Clientes", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.Imagens", new[] { "Designer_UserId" });
            DropIndex("dbo.Funda_Diseno", new[] { "Cliente_UserId" });
            DropIndex("dbo.Direccions", new[] { "Cliente_UserId" });
            DropIndex("dbo.DetallesPedidoes", new[] { "Cliente_UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Designers", new[] { "UserId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Clientes", new[] { "UserId" });
            DropPrimaryKey("dbo.Designers");
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Imagens", "Designer_UserId", c => c.Int());
            AlterColumn("dbo.Funda_Diseno", "Cliente_UserId", c => c.Int());
            AlterColumn("dbo.Direccions", "Cliente_UserId", c => c.Int());
            AlterColumn("dbo.DetallesPedidoes", "Cliente_UserId", c => c.Int());
            AlterColumn("dbo.Designers", "DesignerID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Clientes", "ClienteID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Designers", "UserId");
            DropColumn("dbo.Clientes", "UserId");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            AddPrimaryKey("dbo.Designers", "DesignerID");
            AddPrimaryKey("dbo.Clientes", "ClienteID");
            RenameColumn(table: "dbo.Imagens", name: "Designer_UserId", newName: "Designer_DesignerID");
            RenameColumn(table: "dbo.Funda_Diseno", name: "Cliente_UserId", newName: "Cliente_ClienteID");
            RenameColumn(table: "dbo.Direccions", name: "Cliente_UserId", newName: "Cliente_ClienteID");
            RenameColumn(table: "dbo.DetallesPedidoes", name: "Cliente_UserId", newName: "Cliente_ClienteID");
            CreateIndex("dbo.Imagens", "Designer_DesignerID");
            CreateIndex("dbo.Funda_Diseno", "Cliente_ClienteID");
            CreateIndex("dbo.Direccions", "Cliente_ClienteID");
            CreateIndex("dbo.DetallesPedidoes", "Cliente_ClienteID");
            CreateIndex("dbo.Designers", "Persona_PersonaID");
            CreateIndex("dbo.Clientes", "Persona_PersonaID");
            AddForeignKey("dbo.Imagens", "Designer_DesignerID", "dbo.Designers", "DesignerID");
            AddForeignKey("dbo.Funda_Diseno", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
            AddForeignKey("dbo.Direccions", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
            AddForeignKey("dbo.DetallesPedidoes", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
            AddForeignKey("dbo.Designers", "Persona_PersonaID", "dbo.Personas", "PersonaID");
            AddForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas", "PersonaID", cascadeDelete: true);
        }
    }
}
