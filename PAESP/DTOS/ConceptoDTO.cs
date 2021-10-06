using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.DTOS
{
    public class ConceptoDTO
    {
        public int IdConcepto { get; set; }
        public string CodigoConcepto { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
