using Microsoft.AspNetCore.Mvc;
using PAESP.Clases;
using PAESP.DTOS;
using PAESP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class ConfiguracionController : Controller
    {
        private readonly ConfigurationService _configurationService;
        public ConfiguracionController(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public JsonResult GetTiposIdentificacion()
        {
            AjaxData Retono = new AjaxData();
            try
            {
                List<TiposIdenticacionDTO> tiposIdenti = _configurationService.ListTiposIdentificacion();
                if (tiposIdenti.Count > 0)
                {
                    Retono.Objeto = tiposIdenti;
                    Retono.Is_Error = false;
                }
                else
                {
                    Retono.Is_Error = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(Retono);
        }
    }
}
