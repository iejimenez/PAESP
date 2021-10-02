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

        public ActionResult Agregar()
        {
            return View();
        }

      
        public JsonResult InsertarPreinscripcion()
        {

            try
            {
                Preinscripcion preinscripcion = new Preinscripcion()
                {
                    Persona = new Usuario()
                    {
                        TipodeIdentificacion = Request.Form["txtTipoIdentificacion"],
                        Cedula = Request.Form["txtNroDocumento"],
                        Nombres = Request.Form["txtNombres"],
                        Apeliidos = Request.Form["txtApellidos"],
                        Correo = Request.Form["txtEmail"],
                        Telefono = Request.Form["txtTelefono"],
                        Celular = Request.Form["txtCiudad"]
                    }
                };

                if (!Preinscripcion.ValidarCampos(preinscripcion)) 
                    return Json(new { isError = true, msj = "Campos incompletos" });

                if (preinscripcion.Guardar())
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
