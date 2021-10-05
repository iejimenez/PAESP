using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class CalendarioAcademico
    {
        public int IdCalendarioAcademico { get; set; }
        public int IdPeriodo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Semestre { get; set; }
        public int academicYear { get; set; }

        public List<Matricula> Matriculas { get; set; }
    }
}
