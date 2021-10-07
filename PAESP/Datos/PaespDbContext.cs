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
        }
    }
}
