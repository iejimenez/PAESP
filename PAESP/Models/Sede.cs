using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Sede
    {
        [Key]
        public string Codigo { get; set; }

        public string NombreSede { get; set; }

        public virtual ICollection<Programa> Programas { get; set; }
    }
}
