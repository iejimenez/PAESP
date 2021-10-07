using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class PaespContext : DbContext
    {
        public PaespContext(DbContextOptions<PaespContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Sede> Sedes { get; set; }

        public DbSet<Programa> Programas { get; set; }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<ProgramaMateria> ProgramaMaterias { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Grupo> Grupos { get; set; }

        public DbSet<GrupoEstudiante> GrupoEstudiantes {get;set;}

        public DbSet<GrupoAula> GrupoAulas { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
