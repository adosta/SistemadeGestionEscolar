namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioCinco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "grupoID", "dbo.Grupoes");
            DropIndex("dbo.AspNetUsers", new[] { "grupoID" });
            AddColumn("dbo.AspNetUsers", "Grupo_grupoID", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "grupoID", c => c.String());
            CreateIndex("dbo.AspNetUsers", "Grupo_grupoID");
            AddForeignKey("dbo.AspNetUsers", "Grupo_grupoID", "dbo.Grupoes", "grupoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Grupo_grupoID", "dbo.Grupoes");
            DropIndex("dbo.AspNetUsers", new[] { "Grupo_grupoID" });
            AlterColumn("dbo.AspNetUsers", "grupoID", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Grupo_grupoID");
            CreateIndex("dbo.AspNetUsers", "grupoID");
            AddForeignKey("dbo.AspNetUsers", "grupoID", "dbo.Grupoes", "grupoID");
        }
    }
}
