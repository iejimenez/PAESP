using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Recibo
    {
        public int IdRecibo { get; set; }
        public string NroRecibo { get; set; }
        public int IdConcepto { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Valor { get; set; }
        public int Estado { get; set; }
        public DateTime FechaReg { get; set; }

        public Concepto Concepto { get; set; }

    }
}
