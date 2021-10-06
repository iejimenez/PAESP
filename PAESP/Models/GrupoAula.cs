using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class GrupoAula
    {
        public int IdGrupoaula { get; set; }
        public int IdAula { get; set; }

        public int IdGrupo { get; set; }

        public int Dia { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public virtual Aula Aula { get; set; }

        public int Estado { get; set; }
    }
}
