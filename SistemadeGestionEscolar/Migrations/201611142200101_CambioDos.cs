namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioDos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carreras", "NombreCarrera", c => c.String());
            DropColumn("dbo.Carreras", "carrera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carreras", "carrera", c => c.String());
            DropColumn("dbo.Carreras", "NombreCarrera");
        }
    }
}
