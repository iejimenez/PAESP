using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Aula
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAula { get; set; }
        public string CodigoAula { get; set; }
        public string NombreAula { get; set; }

        public string Bloque { get; set; }

        public int Estado { get; set; }
    }
}
