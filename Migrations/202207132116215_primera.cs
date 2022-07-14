namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NombreCarrera = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NombreMateria = c.String(nullable: false),
                        IdCarrera = c.Guid(nullable: false),
                        Semestre = c.Boolean(nullable: false),
                        Carrera_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carreras", t => t.Carrera_Id)
                .Index(t => t.Carrera_Id);
            
            CreateTable(
                "dbo.MateriaPorCorrelativas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdCarrera = c.Guid(nullable: false),
                        IdMateria = c.Guid(nullable: false),
                        IdPrimeraCorrelativa = c.Guid(nullable: false),
                        IdSegundaCorrelativa = c.Guid(nullable: false),
                        Carrera_Id = c.Guid(),
                        Materia_Id = c.Guid(),
                        Correlativa_Id = c.Guid(),
                        PrimeraCorrelativa_Id = c.Guid(),
                        SegundaCorrelativa_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carreras", t => t.Carrera_Id)
                .ForeignKey("dbo.Materias", t => t.Materia_Id)
                .ForeignKey("dbo.Correlativas", t => t.Correlativa_Id)
                .ForeignKey("dbo.Correlativas", t => t.PrimeraCorrelativa_Id)
                .ForeignKey("dbo.Correlativas", t => t.SegundaCorrelativa_Id)
                .Index(t => t.Carrera_Id)
                .Index(t => t.Materia_Id)
                .Index(t => t.Correlativa_Id)
                .Index(t => t.PrimeraCorrelativa_Id)
                .Index(t => t.SegundaCorrelativa_Id);
            
            CreateTable(
                "dbo.Correlativas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NombreCorrelativa = c.String(nullable: false),
                        IdCarrera = c.Guid(nullable: false),
                        Carrera_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carreras", t => t.Carrera_Id)
                .Index(t => t.Carrera_Id);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        IdCarrera = c.Guid(nullable: false),
                        IdMateria = c.Guid(nullable: false),
                        Carrera_Id = c.Guid(),
                        Materia_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carreras", t => t.Carrera_Id)
                .ForeignKey("dbo.Materias", t => t.Materia_Id)
                .Index(t => t.Carrera_Id)
                .Index(t => t.Materia_Id);
            
            CreateTable(
                "dbo.MateriasViewModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NombreMateria = c.String(),
                        Semestre = c.Boolean(nullable: false),
                        IdCarrera = c.Guid(nullable: false),
                        NombreCarrera = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Estudiantes", "Materia_Id", "dbo.Materias");
            DropForeignKey("dbo.Estudiantes", "Carrera_Id", "dbo.Carreras");
            DropForeignKey("dbo.MateriaPorCorrelativas", "SegundaCorrelativa_Id", "dbo.Correlativas");
            DropForeignKey("dbo.MateriaPorCorrelativas", "PrimeraCorrelativa_Id", "dbo.Correlativas");
            DropForeignKey("dbo.MateriaPorCorrelativas", "Correlativa_Id", "dbo.Correlativas");
            DropForeignKey("dbo.Correlativas", "Carrera_Id", "dbo.Carreras");
            DropForeignKey("dbo.MateriaPorCorrelativas", "Materia_Id", "dbo.Materias");
            DropForeignKey("dbo.MateriaPorCorrelativas", "Carrera_Id", "dbo.Carreras");
            DropForeignKey("dbo.Materias", "Carrera_Id", "dbo.Carreras");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Estudiantes", new[] { "Materia_Id" });
            DropIndex("dbo.Estudiantes", new[] { "Carrera_Id" });
            DropIndex("dbo.Correlativas", new[] { "Carrera_Id" });
            DropIndex("dbo.MateriaPorCorrelativas", new[] { "SegundaCorrelativa_Id" });
            DropIndex("dbo.MateriaPorCorrelativas", new[] { "PrimeraCorrelativa_Id" });
            DropIndex("dbo.MateriaPorCorrelativas", new[] { "Correlativa_Id" });
            DropIndex("dbo.MateriaPorCorrelativas", new[] { "Materia_Id" });
            DropIndex("dbo.MateriaPorCorrelativas", new[] { "Carrera_Id" });
            DropIndex("dbo.Materias", new[] { "Carrera_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MateriasViewModels");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Correlativas");
            DropTable("dbo.MateriaPorCorrelativas");
            DropTable("dbo.Materias");
            DropTable("dbo.Carreras");
        }
    }
}