namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(),
                        apellidoPaterno = c.String(),
                        apellidoMaterno = c.String(),
                        fechaNacimiento = c.DateTime(nullable: false),
                        especialidad = c.String(),
                        grado = c.String(),
                        rol = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        carreraPreferida = c.String(),
                        grupoID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupoes", t => t.grupoID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.grupoID);
            
            CreateTable(
                "dbo.Calificacions",
                c => new
                    {
                        calificacionID = c.Int(nullable: false, identity: true),
                        parcial1 = c.Int(nullable: false),
                        parcial2 = c.Int(nullable: false),
                        parcial3 = c.Int(nullable: false),
                        final = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                        claseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.calificacionID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Clases", t => t.claseID, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.claseID);
            
            CreateTable(
                "dbo.Clases",
                c => new
                    {
                        claseID = c.Int(nullable: false, identity: true),
                        profesorID = c.Int(nullable: false),
                        asignaturaID = c.Int(nullable: false),
                        grupoID = c.Int(nullable: false),
                        profesor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.claseID)
                .ForeignKey("dbo.Asignaturas", t => t.asignaturaID, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.grupoID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.profesor_Id)
                .Index(t => t.asignaturaID)
                .Index(t => t.grupoID)
                .Index(t => t.profesor_Id);
            
            CreateTable(
                "dbo.Asignaturas",
                c => new
                    {
                        asignaturaID = c.Int(nullable: false, identity: true),
                        nombreAsignatura = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.asignaturaID);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        grupoID = c.Int(nullable: false, identity: true),
                        nombreGrupo = c.String(),
                        carreraID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.grupoID)
                .ForeignKey("dbo.Carreras", t => t.carreraID, cascadeDelete: true)
                .Index(t => t.carreraID);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        carreraID = c.Int(nullable: false, identity: true),
                        NombreCarrera = c.String(),
                    })
                .PrimaryKey(t => t.carreraID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Clases", "profesor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clases", "grupoID", "dbo.Grupoes");
            DropForeignKey("dbo.Grupoes", "carreraID", "dbo.Carreras");
            DropForeignKey("dbo.AspNetUsers", "grupoID", "dbo.Grupoes");
            DropForeignKey("dbo.Calificacions", "claseID", "dbo.Clases");
            DropForeignKey("dbo.Clases", "asignaturaID", "dbo.Asignaturas");
            DropForeignKey("dbo.Calificacions", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Grupoes", new[] { "carreraID" });
            DropIndex("dbo.Clases", new[] { "profesor_Id" });
            DropIndex("dbo.Clases", new[] { "grupoID" });
            DropIndex("dbo.Clases", new[] { "asignaturaID" });
            DropIndex("dbo.Calificacions", new[] { "claseID" });
            DropIndex("dbo.Calificacions", new[] { "Id" });
            DropIndex("dbo.AspNetUsers", new[] { "grupoID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Carreras");
            DropTable("dbo.Grupoes");
            DropTable("dbo.Asignaturas");
            DropTable("dbo.Clases");
            DropTable("dbo.Calificacions");
            DropTable("dbo.AspNetUsers");
        }
    }
}
