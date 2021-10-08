using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class ProgramaMateria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProgramaMateria { get; set; }

        public string CodigoPrograma { get; set; }

        public int IdMateria { get; set; }

        [ForeignKey("CodigoPrograma")]
        public virtual Programa Programa { get; set; }

        [ForeignKey("IdMateria")]
        public virtual Materia Materia { get; set; }

        public int Estado { get; set; }
    }
}
