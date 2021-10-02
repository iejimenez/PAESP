using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Preinscripcion
    {
        public int IdPresinscripcion { get;set; }

        public DateTime FechaDePreInscripcion { get; set; }

        public string NumeroRecibo { get; set; }

        public int IdPersona { get; set; }

        public Usuario Persona { get; set; }


    }
}
