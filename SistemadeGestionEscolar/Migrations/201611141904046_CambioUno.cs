namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioUno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoPaterno", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoMaterno", c => c.String());
            AddColumn("dbo.AspNetUsers", "especialidad", c => c.String());
            AddColumn("dbo.AspNetUsers", "grado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "grado");
            DropColumn("dbo.AspNetUsers", "especialidad");
            DropColumn("dbo.AspNetUsers", "apellidoMaterno");
            DropColumn("dbo.AspNetUsers", "apellidoPaterno");
            DropColumn("dbo.AspNetUsers", "nombre");
        }
    }
}
