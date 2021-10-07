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
    public class ConceptoController : Controller
    {
        private readonly ConceptoService _conceptoService;
        public ConceptoController(ConceptoService conceptoService)
        {
            _conceptoService = conceptoService;
        }
        public JsonResult ListConceptos()
        {
            AjaxData Retono = new AjaxData();
            try
            {
                List<ConceptoDTO> conceptos =  _conceptoService.ListConceptos();
                if (conceptos.Count > 0)
                {
                    Retono.Objeto = conceptos;
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
