namespace Estudiantes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clases",
                c => new
                    {
                        IdClase = c.Int(nullable: false, identity: true),
                        NombreClase = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdClase);
            
            CreateTable(
                "dbo.Calificacions",
                c => new
                    {
                        IdCalificacion = c.Int(nullable: false, identity: true),
                        IdEstudiante = c.Int(nullable: false),
                        IdClase = c.Int(nullable: false),
                        IdPeriodo = c.Int(nullable: false),
                        CalificacionFinal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCalificacion)
                .ForeignKey("dbo.Clases", t => t.IdClase, cascadeDelete: true)
                .ForeignKey("dbo.Estudiantes", t => t.IdEstudiante, cascadeDelete: true)
                .ForeignKey("dbo.Periodoes", t => t.IdPeriodo, cascadeDelete: true)
                .Index(t => t.IdEstudiante)
                .Index(t => t.IdClase)
                .Index(t => t.IdPeriodo);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        IdEstudiante = c.Int(nullable: false, identity: true),
                        Matricula = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Edad = c.Byte(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.IdEstudiante);
            
            CreateTable(
                "dbo.Periodoes",
                c => new
                    {
                        IdPeriodo = c.Int(nullable: false, identity: true),
                        NombrePeriodo = c.String(),
                    })
                .PrimaryKey(t => t.IdPeriodo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificacions", "IdPeriodo", "dbo.Periodoes");
            DropForeignKey("dbo.Calificacions", "IdEstudiante", "dbo.Estudiantes");
            DropForeignKey("dbo.Calificacions", "IdClase", "dbo.Clases");
            DropIndex("dbo.Calificacions", new[] { "IdPeriodo" });
            DropIndex("dbo.Calificacions", new[] { "IdClase" });
            DropIndex("dbo.Calificacions", new[] { "IdEstudiante" });
            DropTable("dbo.Periodoes");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Calificacions");
            DropTable("dbo.Clases");
        }
    }
}
