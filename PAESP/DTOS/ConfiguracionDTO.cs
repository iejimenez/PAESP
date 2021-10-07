using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.DTOS
{
    public class TiposIdenticacionDTO
    {
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
    }

    public class PreinscripcionDTO
    {
        public string IdPresinscripcion { get; set; }

        public DateTime FechaDePreInscripcion { get; set; }

        public string NumeroRecibo { get; set; }

        public string IdPersona { get; set; }

        public Usuario Persona { get; set; }
    }
}
