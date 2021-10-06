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


        public DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }
        public DbSet<Recibo> Recibos { get; set; }

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
        }
    }
}
