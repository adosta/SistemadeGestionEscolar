namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioCuatro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alumnoes", "NombreCarrera", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alumnoes", "NombreCarrera");
        }
    }
}
