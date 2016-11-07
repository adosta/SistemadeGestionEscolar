namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grupoclase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clases", "Grupo_grupoID", "dbo.Grupoes");
            DropIndex("dbo.Clases", new[] { "Grupo_grupoID" });
            RenameColumn(table: "dbo.Clases", name: "Grupo_grupoID", newName: "grupoID");
            AlterColumn("dbo.Clases", "grupoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Clases", "grupoID");
            AddForeignKey("dbo.Clases", "grupoID", "dbo.Grupoes", "grupoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clases", "grupoID", "dbo.Grupoes");
            DropIndex("dbo.Clases", new[] { "grupoID" });
            AlterColumn("dbo.Clases", "grupoID", c => c.Int());
            RenameColumn(table: "dbo.Clases", name: "grupoID", newName: "Grupo_grupoID");
            CreateIndex("dbo.Clases", "Grupo_grupoID");
            AddForeignKey("dbo.Clases", "Grupo_grupoID", "dbo.Grupoes", "grupoID");
        }
    }
}
