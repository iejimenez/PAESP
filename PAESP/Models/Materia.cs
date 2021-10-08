
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Materia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMateria { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public int Creditos { get; set; }

        public ICollection<Grupo> Grupos { get; set; }

        public ICollection<ProgramaMateria> Programas { get; set; }
    }
}
