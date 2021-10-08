using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Clases
{
    public interface IReportService
    {
        public byte[] GeneratePdfReport(string tipoReporte, int nroRecibo);
    }
}
