using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Programa
    {
        [Key]
        public string Codigo { get; set; }

        public string NombrePograma { get; set; }

        public int Semestres { get; set; }

        public ICollection<ProgramaMateria> Materias { get; set; }
    }
}
