namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alumnoes", "grupoID", "dbo.Grupoes");
            DropIndex("dbo.Alumnoes", new[] { "grupoID" });
            AlterColumn("dbo.Alumnoes", "grupoID", c => c.Int());
            CreateIndex("dbo.Alumnoes", "grupoID");
            AddForeignKey("dbo.Alumnoes", "grupoID", "dbo.Grupoes", "grupoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumnoes", "grupoID", "dbo.Grupoes");
            DropIndex("dbo.Alumnoes", new[] { "grupoID" });
            AlterColumn("dbo.Alumnoes", "grupoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Alumnoes", "grupoID");
            AddForeignKey("dbo.Alumnoes", "grupoID", "dbo.Grupoes", "grupoID", cascadeDelete: true);
        }
    }
}
