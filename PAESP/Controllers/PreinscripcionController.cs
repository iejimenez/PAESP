using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class PreinscripcionController : Controller
    {
        // GET: Preinscripcion
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPreinscriptos() 
        {
            Data dt = Data.GetInstance();
            List<Usuario> List = dt.ListUsuarios();
            return Json(List);
        }

    }
}
