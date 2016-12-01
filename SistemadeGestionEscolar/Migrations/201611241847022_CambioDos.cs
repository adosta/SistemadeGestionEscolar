namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioDos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "fechaNacimiento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "fechaNacimiento", c => c.DateTime(nullable: false));
        }
    }
}
