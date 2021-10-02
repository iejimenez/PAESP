﻿using Microsoft.AspNetCore.Http;
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
        IHttpContextAccessor ica = null;
        public PreinscripcionController(IHttpContextAccessor contextAccessor)
        {
            // save to a field, like _httpContext = contextAccessor.HttpContext;
            ica = contextAccessor;
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
      
        public JsonResult InsertarPreinscripcion()
        {

            try
            {
                Preinscripcion preinscripcion = new Preinscripcion()
                {
                    Persona = new Usuario()
                    {
                        TipodeIdentificacion = ica.HttpContext.Request.Form["txtTipoIdentificacion"],
                        Cedula = ica.HttpContext.Request.Form["txtNroDocumento"],
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
