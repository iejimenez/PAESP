﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
