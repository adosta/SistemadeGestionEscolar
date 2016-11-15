namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioCinco : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Alumnoes", "NombreCarrera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alumnoes", "NombreCarrera", c => c.String(nullable: false));
        }
    }
}
