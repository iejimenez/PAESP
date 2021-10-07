using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Aula
    {

        [Key]
        public string CodigoAula { get; set; }
        public string NombreAula { get; set; }

        public string Bloque { get; set; }

        public int Estado { get; set; }
    }
}
