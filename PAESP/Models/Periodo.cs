using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Periodo
    {

        public int IdPeriodo { get; set; }
        public string Descripcion { get; set; }
        public int Unidad { get; set; }

        public List<CalendarioAcademico> CalendarioAcademicos { get; set; }
    }
}
