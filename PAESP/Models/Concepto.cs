using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Concepto
    {
        public int IdConcepto { get; set; }
        public string CodigoConcepto { get; set; }
        public string TipoConcepto { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public List<Recibo> Recibos { get; set; }
    }
}
