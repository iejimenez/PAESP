using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.DTOS
{
    public class GrupoEstudianteDto
    {
        public int IdGrupoEstudiante { get; set; }


        public int IdGrupo { get; set; }
        public int IdEstudiante { get; set; }

        public double PrimerCorte { get; set; }
        public double SegundoCorte { get; set; }

        public double TercerCorte { get; set; }


        public double Ponderado { get { return Math.Round((PrimerCorte * 0.3) + (SegundoCorte * 0.3) + (TercerCorte * 0.4), 2); } }

        public int Estado { get; set; }

        public virtual EstudianteDto Estudiante { get; set; }
    }
}
