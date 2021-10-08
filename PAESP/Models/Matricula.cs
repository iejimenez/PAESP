using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Matricula
    {
        public int IdMatricula { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCalendarioAcademico { get; set; }
        public int IdRecibo { get; set; }
        public int IdFuncionario { get; set; }
        public int IdPrograma { get; set; }
        public int NumeroAsignaturas { get; set; }
        public int TotalCreditos { get; set; }
        public DateTime FechaMatricula { get; set; }
        public int EstadoMatricula { get; set; }

        public CalendarioAcademico CalendarioAcademico { get; set; }
        public Estudiante Estudiante { get; set; }

    }
}
