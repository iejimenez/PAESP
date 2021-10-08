using Microsoft.AspNetCore.Mvc;
using PAESP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult Generate([FromQuery] string tipo, string Id )
        {          
            var pdfFile = _reportService.GeneratePdfReport(tipo, int.Parse(Id));
            return File(pdfFile,
            "application/octet-stream", "SimplePdf.pdf");
        }
    }
}
