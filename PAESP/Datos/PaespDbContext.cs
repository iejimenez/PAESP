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

        public DbSet<Estudiante> Estudiantes {get;set;}


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

            modelBuilder.Entity<GrupoEstudiante>()
                .HasOne<Grupo>()
                .WithMany(e=>e.Estudiantes)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GrupoEstudiante>()
                .HasOne<Estudiante>()
                .WithMany(g => g.Grupos)
                .OnDelete(DeleteBehavior.Restrict);
            
            
            modelBuilder.Entity<Estudiante>()
                .HasMany<GrupoEstudiante>()
                .WithOne(e=>e.Estudiante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grupo>()
               .HasMany<GrupoEstudiante>()
               .WithOne(g=>g.Grupo)
               .OnDelete(DeleteBehavior.Restrict);
        }

        public Usuario GetUser(string user, string pass)
        {
            Usuario userResult = this.Usuarios.Where(u => u.Cedula == user && u.Contraseña == pass).FirstOrDefault();
            return userResult;
        }
    }
}
