
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.DTOS
{
    public class EstudianteDto
    {
        public int IdEstudiante { get; set; }
        public DateTime FEchaInscripcion { get; set; }
        public int IdUsuario { get; set; }

        public UsuarioDto Usuario { get; set; }
    }
}
