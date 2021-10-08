using Microsoft.EntityFrameworkCore;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Datos
{
    public class PaespDbContext : DbContext
    {
        public PaespDbContext()
        {

        }

        public PaespDbContext(DbContextOptions<PaespDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<Preinscripcion> Preinscripcions { get; set; }
        public DbSet<Configuraciones> configuraciones { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<CalendarioAcademico> CalendarioAcademicos { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Grupo> Grupos { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        public DbSet<GrupoAula> GrupoAulas { get; set; }

        public DbSet<GrupoEstudiante> GrupoEstudiantes { get; set; }

        public DbSet<Materia> Materias { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concepto>(entity => {
                entity.HasKey(e => e.IdConcepto);
            });

            modelBuilder.Entity<TipoIdentificacion>(entity => {
                entity.HasKey(e => e.IdTipo);
            });

            modelBuilder.Entity<Recibo>(entity => {
                entity.HasKey(e => e.IdRecibo);

                entity.HasOne(d => d.Concepto)
                   .WithMany(p => p.Recibos)
                   .HasForeignKey(d => d.IdConcepto);
            });

            modelBuilder.Entity<Preinscripcion>(entity => {
                entity.HasKey(e => e.IdPresinscripcion);

            });

            modelBuilder.Entity<Configuraciones>(entity => {
                entity.HasKey(e => e.IdConfig);

            });

            modelBuilder.Entity<Usuario>(entity => {
                entity.HasKey(e => e.IdUsuario);

            });

            modelBuilder.Entity<Estado>(entity => {
                entity.HasKey(e => e.IdEstado);
            });

            modelBuilder.Entity<Estudiante>(student =>
            {
                student.HasKey(e => e.IdEstudiante);
                student.HasOne<Usuario>("Usuario")
                .WithMany()
                .HasForeignKey("IdUsuario");

            });

            modelBuilder.Entity<Periodo>(periodo =>
            {
                periodo.HasKey(e => e.IdPeriodo);
            });

            modelBuilder.Entity<CalendarioAcademico>(calendario =>
            {
                calendario.HasKey(e => e.IdCalendarioAcademico);

                calendario.HasOne(d => d.Periodo)
                 .WithMany(p => p.CalendarioAcademicos)
                 .HasForeignKey(d => d.IdCalendarioAcademico);

            });

            modelBuilder.Entity<GrupoEstudiante>()
                .HasOne<Grupo>()
                .WithMany(e => e.Estudiantes)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GrupoEstudiante>()
                .HasOne<Estudiante>()
                .WithMany(g => g.Grupos)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Estudiante>()
                .HasMany<GrupoEstudiante>()
                .WithOne(e => e.Estudiante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grupo>()
               .HasMany<GrupoEstudiante>()
               .WithOne(g => g.Grupo)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Materia>()
                .HasMany<Grupo>()
                .WithOne(g => g.Materia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grupo>()
                .HasOne<Materia>()
                .WithMany(g => g.Grupos)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public Usuario GetUser(string user, string pass)
        {
            Usuario userResult = this.Usuarios.Where(u => u.Cedula == user && u.Contraseña == pass).FirstOrDefault();
            return userResult;
        }

        public Profesor GetProfesorByIdUser (int iduser)
        {
            return this.Profesores.Where(p => p.IdUsuario == iduser).FirstOrDefault();
        }

        public List<Grupo> GetGruposByProfesor(int idprofesor)
        {
            List<Grupo> grupos = this.Grupos.Where(g=>g.IdProfesor == idprofesor).ToList();

            return grupos;
        } 

        public Materia GetMateria(int idmateria)
        {
            Materia materia = this.Materias.Where(m => m.IdMateria == idmateria).FirstOrDefault();
            return materia;
        }
    }
}
