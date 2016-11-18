namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calificacion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calificacions", "clase_profesorID", "dbo.Profesors");
            DropIndex("dbo.Calificacions", new[] { "claseID" });
            DropIndex("dbo.Calificacions", new[] { "clase_profesorID" });
            DropColumn("dbo.Calificacions", "claseID");
            RenameColumn(table: "dbo.Calificacions", name: "clase_profesorID", newName: "claseID");
            AlterColumn("dbo.Calificacions", "claseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Calificacions", "claseID");
            AddForeignKey("dbo.Calificacions", "claseID", "dbo.Clases", "claseID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificacions", "claseID", "dbo.Clases");
            DropIndex("dbo.Calificacions", new[] { "claseID" });
            AlterColumn("dbo.Calificacions", "claseID", c => c.Int());
            RenameColumn(table: "dbo.Calificacions", name: "claseID", newName: "clase_profesorID");
            AddColumn("dbo.Calificacions", "claseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Calificacions", "clase_profesorID");
            CreateIndex("dbo.Calificacions", "claseID");
            AddForeignKey("dbo.Calificacions", "clase_profesorID", "dbo.Profesors", "profesorID");
        }
    }
}
