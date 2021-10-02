using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ActionResult Agregar()
        {
            return View();
        }

      


    }
}
