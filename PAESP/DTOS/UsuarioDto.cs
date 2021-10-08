using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.DTOS
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Cedula { get; set; }
        public string TipodeIdentificacion { get; set; }

        public string Nombres { get; set; }

        public string Apeliidos { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Ciudad { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }
    }
}
