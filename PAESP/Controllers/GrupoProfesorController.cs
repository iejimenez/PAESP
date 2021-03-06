using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PAESP.Datos;
using PAESP.DTOS;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class GrupoProfesorController : Controller
    {

        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public GrupoProfesorController(IMapper mapper, PaespDbContext contenxt)
        {
            _mapper = mapper;
            _context = contenxt;
        }

        public IActionResult Index()
        {
            UsuarioDto user = JsonConvert.DeserializeObject<UsuarioDto>(HttpContext.Session.GetString("User"));
            ViewBag.Nombre = user.Nombres;
            ViewBag.Admin = user.Cedula == "123456";
            return View();
        }

        public JsonResult GruposByProfesor()
        {
            UsuarioDto user = JsonConvert.DeserializeObject<UsuarioDto>(HttpContext.Session.GetString("User"));
            int idprofesor = _context.GetProfesorByIdUser(user.IdUsuario).IdProfesor;
            List<GrupoDto> grupos = _mapper.Map<List<GrupoDto>>(_context.GetGruposByProfesor(idprofesor));

            foreach(GrupoDto gp in grupos)
            {
                gp.Materia = _mapper.Map<MateriaDto>(_context.GetMateria(gp.IdMateria)); 
            }
            return Json(grupos);
        }
    }
}
