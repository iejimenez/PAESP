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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
