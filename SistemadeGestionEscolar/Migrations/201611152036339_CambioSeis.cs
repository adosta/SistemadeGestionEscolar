namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioSeis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calificacions",
                c => new
                    {
                        calificacionID = c.Int(nullable: false, identity: true),
                        parcial1 = c.Int(nullable: false),
                        parcial2 = c.Int(nullable: false),
                        parcial3 = c.Int(nullable: false),
                        final = c.Int(nullable: false),
                        numeroMatricula = c.Int(nullable: false),
                        claseID = c.Int(nullable: false),
                        clase_profesorID = c.Int(),
                    })
                .PrimaryKey(t => t.calificacionID)
                .ForeignKey("dbo.Alumnoes", t => t.numeroMatricula, cascadeDelete: true)
                .ForeignKey("dbo.Clases", t => t.claseID, cascadeDelete: true)
                .ForeignKey("dbo.Profesors", t => t.clase_profesorID)
                .Index(t => t.numeroMatricula)
                .Index(t => t.claseID)
                .Index(t => t.clase_profesorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificacions", "clase_profesorID", "dbo.Profesors");
            DropForeignKey("dbo.Calificacions", "claseID", "dbo.Clases");
            DropForeignKey("dbo.Calificacions", "numeroMatricula", "dbo.Alumnoes");
            DropIndex("dbo.Calificacions", new[] { "clase_profesorID" });
            DropIndex("dbo.Calificacions", new[] { "claseID" });
            DropIndex("dbo.Calificacions", new[] { "numeroMatricula" });
            DropTable("dbo.Calificacions");
        }
    }
}
