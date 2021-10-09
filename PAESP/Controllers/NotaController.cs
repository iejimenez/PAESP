using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PAESP.Clases;
using PAESP.Datos;
using PAESP.DTOS;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Controllers
{
    public class NotaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public NotaController(IMapper mapper, PaespDbContext contenxt)
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


        
        public JsonResult GetNotas()
        {
            int idgrupo = int.Parse(HttpContext.Request.Query["idgrupo"]);
            List<GrupoEstudianteDto> estudiantes = _mapper.Map<List<GrupoEstudianteDto>>(_context.GetEstudiantesDeGrupo(idgrupo));

            foreach (GrupoEstudianteDto est in estudiantes)
            {
                est.Estudiante = _mapper.Map<EstudianteDto>(_context.GetEstudianteById(est.IdEstudiante));
            }

            return Json(estudiantes);
        }

        public JsonResult UpdateNota(GrupoEstudianteDto nota)
        {
            AjaxData retorno = new AjaxData();
            if (nota != null)
            {
                GrupoEstudiante ge = _mapper.Map<GrupoEstudiante>(nota);
                _context.Update(ge);
                _context.SaveChanges();
                retorno.Is_Error = false;
                retorno.Msj = "OK";
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
