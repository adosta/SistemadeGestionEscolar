namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioSiete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alumnoes", "carreraPreferida", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alumnoes", "carreraPreferida");
        }
    }
}
