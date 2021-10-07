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
    public class PreinscripcionController : Controller
    {
        IHttpContextAccessor ica = null;
        private readonly PreinscripcionService _preinscripcionService;
        public PreinscripcionController(IHttpContextAccessor contextAccessor, PreinscripcionService preinscripcionService)
        {
            // save to a field, like _httpContext = contextAccessor.HttpContext;
            ica = contextAccessor;
            _preinscripcionService = preinscripcionService;
        }
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

        [HttpGet]
        public JsonResult ListPreinscritos()
        {
            AjaxData Retorno = new AjaxData();
            try { 
                List<Usuario> usuarios = _preinscripcionService.ListPreinscritos();
                if (usuarios.Count > 0)
                {
                    Retorno.Objeto = usuarios;
                    Retorno.Is_Error = false;
                }
                else
                {
                    Retorno.Is_Error = true;
                }
            }
            catch (Exception ex)
            {
                Retorno.Is_Error = true; ;
            }
            return Json(Retorno);
        }

        [HttpPost]
        public JsonResult InsertarPreinscripcion(IFormCollection collection)
        {
            try
            {
                Preinscripcion preinscripcion = new Preinscripcion()
                {
                    Persona = new Usuario()
                    {
                        TipodeIdentificacion = collection["txtTipoIdentificacion"],
                        Cedula = collection["txtNroDocumento"],
                        Nombres = collection["txtNombres"],
                        Apeliidos = collection["txtApellidos"],
                        Correo = collection["txtEmail"],
                        Telefono = collection["txtTelefono"],
                        Ciudad = collection["txtCiudad"],
                        Celular = collection["txtTelefono"]
                    }
                };

                int idConcepto = int.Parse(collection["txtConcepto"]);

                if (!Preinscripcion.ValidarCampos(preinscripcion)) 
                    return Json(new { isError = true, msj = "Campos incompletos" });

                if (!_preinscripcionService.SavePreinscripcion(preinscripcion, idConcepto))
                {
                    return Json(new { isError = false, msj = "Generado correctamente." });
                }else
                    return Json(new { isError = true, msj = "Ha ocurrido un error inesperado." });

            }
            catch (Exception ex)
            {
                return Json(new { isError = true, msj = ex.Message });

            }
        }

    }
}
