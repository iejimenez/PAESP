using Microsoft.AspNetCore.Mvc;
using PAESP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class CalendarioAcademicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListCalendarios() 
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult SaveCalendario() 
        {
            AjaxData Retorno = new AjaxData();
            try
            {

            }
            catch (Exception ex)
            {

                throw;

            }
            return Json(Retorno);
        }
    }
}
