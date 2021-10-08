using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAESP.Clases;
using PAESP.Datos;
using PAESP.Models;
using PAESP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class LoginController : Controller
    {

        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public LoginController(IMapper mapper, PaespDbContext contenxt)
        {
            _mapper = mapper;
            _context = contenxt;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        public class Login { 
        
            public string user { get; set; }
            public string pass { get; set; }
        }

        public JsonResult Autenticate(Login login)
        {
            AjaxData retorno = new AjaxData();
            if(login!= null)
            {
                Usuario user = _context.GetUser(login.user, login.pass);
                if(user!= null)
                {
                    retorno.Is_Error = false;
                    retorno.Msj = "OK";
                    Redirect("/Home");
                }
                else
                {
                    retorno.Is_Error = false;
                    retorno.Msj = "Datos incorrectos";
                }
            }
            else
            {
                retorno.Is_Error = true;
                retorno.Msj = "";
            }
            return Json(retorno);
        }
    }
}
