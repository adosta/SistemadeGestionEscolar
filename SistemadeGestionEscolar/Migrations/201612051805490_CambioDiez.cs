namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioDiez : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clases", "profesor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Clases", new[] { "profesor_Id" });
            RenameColumn(table: "dbo.Clases", name: "profesor_Id", newName: "Id");
            AlterColumn("dbo.Clases", "Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Clases", "Id");
            AddForeignKey("dbo.Clases", "Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Clases", "profesorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clases", "profesorID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Clases", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Clases", new[] { "Id" });
            AlterColumn("dbo.Clases", "Id", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Clases", name: "Id", newName: "profesor_Id");
            CreateIndex("dbo.Clases", "profesor_Id");
            AddForeignKey("dbo.Clases", "profesor_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
