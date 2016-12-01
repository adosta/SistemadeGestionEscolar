namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioOcho : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "fechaDeNacimiento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "fechaDeNacimiento");
        }
    }
}
