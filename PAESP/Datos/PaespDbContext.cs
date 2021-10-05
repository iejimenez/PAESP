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


        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<CalendarioAcademico> calendarioAcademicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

        }
    }
}
