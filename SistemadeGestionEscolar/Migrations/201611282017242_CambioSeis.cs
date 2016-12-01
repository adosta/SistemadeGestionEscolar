namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioSeis : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Grupo_grupoID" });
            DropColumn("dbo.AspNetUsers", "grupoID");
            RenameColumn(table: "dbo.AspNetUsers", name: "Grupo_grupoID", newName: "grupoID");
            AlterColumn("dbo.AspNetUsers", "grupoID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "grupoID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "grupoID" });
            AlterColumn("dbo.AspNetUsers", "grupoID", c => c.String());
            RenameColumn(table: "dbo.AspNetUsers", name: "grupoID", newName: "Grupo_grupoID");
            AddColumn("dbo.AspNetUsers", "grupoID", c => c.String());
            CreateIndex("dbo.AspNetUsers", "Grupo_grupoID");
        }
    }
}
