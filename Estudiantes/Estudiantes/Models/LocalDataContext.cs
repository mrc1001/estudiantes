using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Estudiantes.Models
{
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Estudiantes.Models.ORM.Estudiante> Estudiantes { get; set; }

        public System.Data.Entity.DbSet<Estudiantes.Models.ORM.Clase> Clases { get; set; }

        public System.Data.Entity.DbSet<Estudiantes.Models.ORM.Calificacion> Calificacions { get; set; }

        public System.Data.Entity.DbSet<Estudiantes.Models.ORM.Periodo> Periodoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        
    }
}