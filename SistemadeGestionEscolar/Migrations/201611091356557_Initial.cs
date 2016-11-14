namespace SistemadeGestionEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        numeroMatricula = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        apellidoPaterno = c.String(nullable: false),
                        apellidoMaterno = c.String(nullable: false),
                        fechaDeNacimiento = c.DateTime(nullable: false),
                        grupoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.numeroMatricula)
                .ForeignKey("dbo.Grupoes", t => t.grupoID, cascadeDelete: true)
                .Index(t => t.grupoID);
            
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
                        carrera = c.String(),
                    })
                .PrimaryKey(t => t.carreraID);
            
            CreateTable(
                "dbo.Clases",
                c => new
                    {
                        claseID = c.Int(nullable: false, identity: true),
                        profesorID = c.Int(nullable: false),
                        asignaturaID = c.Int(nullable: false),
                        grupoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.claseID)
                .ForeignKey("dbo.Asignaturas", t => t.asignaturaID, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.grupoID, cascadeDelete: true)
                .ForeignKey("dbo.Profesors", t => t.profesorID, cascadeDelete: true)
                .Index(t => t.profesorID)
                .Index(t => t.asignaturaID)
                .Index(t => t.grupoID);
            
            CreateTable(
                "dbo.Asignaturas",
                c => new
                    {
                        asignaturaID = c.Int(nullable: false, identity: true),
                        nombreAsignatura = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.asignaturaID);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        profesorID = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        apellidoPaterno = c.String(nullable: false),
                        apellidoMaterno = c.String(nullable: false),
                        fechaDeNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.profesorID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Clases", "profesorID", "dbo.Profesors");
            DropForeignKey("dbo.Clases", "grupoID", "dbo.Grupoes");
            DropForeignKey("dbo.Clases", "asignaturaID", "dbo.Asignaturas");
            DropForeignKey("dbo.Grupoes", "carreraID", "dbo.Carreras");
            DropForeignKey("dbo.Alumnoes", "grupoID", "dbo.Grupoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Clases", new[] { "grupoID" });
            DropIndex("dbo.Clases", new[] { "asignaturaID" });
            DropIndex("dbo.Clases", new[] { "profesorID" });
            DropIndex("dbo.Grupoes", new[] { "carreraID" });
            DropIndex("dbo.Alumnoes", new[] { "grupoID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Profesors");
            DropTable("dbo.Asignaturas");
            DropTable("dbo.Clases");
            DropTable("dbo.Carreras");
            DropTable("dbo.Grupoes");
            DropTable("dbo.Alumnoes");
        }
    }
}
