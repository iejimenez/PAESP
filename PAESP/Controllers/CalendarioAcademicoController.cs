using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAESP.Clases;
using PAESP.Models;
using PAESP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class CalendarioAcademicoController : Controller
    {
        private readonly CalendarioService _calendarioService;
        public CalendarioAcademicoController(CalendarioService calendarioService)
        {
            _calendarioService = calendarioService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListCalendarios() 
        {
            AjaxData retornos = new AjaxData();
            try
            {
                List<CalendarioAcademico> calendarios = _calendarioService.Listcalendarios();
                if (calendarios.Count > 0)
                {
                    retornos.Is_Error = false;
                    retornos.Objeto = calendarios;
                }
                else {
                    retornos.Is_Error = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(retornos);
        }

        [HttpPost]
        public JsonResult SaveCalendario(IFormCollection collection) 
        {
            AjaxData Retorno = new AjaxData();
            try
            {
                CalendarioAcademico calendario = new CalendarioAcademico()
                {                  
                    IdPeriodo = int.Parse(collection["txtPeriodo"]),
                    Descripcion = collection["txtDescripcion"],
                    FechaInicio = DateTime.ParseExact(collection["txtFechaInicio"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    FechaFin = DateTime.ParseExact(collection["txtFechaFin"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    Semestre = collection["txtSemestre"],
                    academicYear = int.Parse(collection["txtAcademicYear"]),                   
                    
                };

                int idConcepto = int.Parse(collection["txtConcepto"]);
              
                AjaxData result = _calendarioService.SaveCalendario(calendario);
                if (!result.Is_Error)
                {
                    return Json(new { isError = false, msj = "Calendario academico registrado correctamente." });
                }
                else
                    return Json(new { isError = true, msj = "Ha ocurrido un error inesperado." });

            }
            catch (Exception ex)
            {
                return Json(new { isError = true, msj = ex.Message });

            }
        }
    }
}
