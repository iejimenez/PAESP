using AutoMapper;
using PAESP.Clases;
using PAESP.Datos;
using PAESP.DTOS;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Services
{
    public class PreinscripcionService
    {
        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public PreinscripcionService(IMapper mapper, PaespDbContext contenxt)
        {
            _mapper = mapper;
            _context = contenxt;
        }

        public List<Usuario> ListPreinscritos()
        {
            List<Recibo> recibos = _context.Recibos
                .Where(w => w.IdConcepto == 1 && w.Estado == 2)
                .ToList();
            List<string> cedulas = recibos.Select(s => s.Identificacion).ToList();

           //List<Usuario> pres = new List<Usuario>();
            List<Usuario> pres = _context.Usuarios
                .Where(w => cedulas.Contains(w.Cedula)).ToList();

            return pres;

        }

        public AjaxData SavePreinscripcion(Preinscripcion pre, int idConcepto)
        {
            AjaxData result = new AjaxData();
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                Recibo recibo = new Recibo();
                Concepto concepto = _context.Conceptos.FirstOrDefault(f => f.IdConcepto == idConcepto);
                Configuraciones config = _context.configuraciones.FirstOrDefault(f => f.Codigo == "200");
                Estado estado = _context.Estados.FirstOrDefault(f => f.NombreEstado == "PAGADO");               

                recibo.NroRecibo = Consecutivos.ConsecutivoByCodigo(8, "200", config);
                recibo.IdConcepto = concepto.IdConcepto;
                recibo.Identificacion = pre.Persona.Cedula;
                recibo.Nombre = $"{pre.Persona.Nombres} {pre.Persona.Apeliidos}";
                recibo.FechaPago = new DateTime(2021, 10, 31);
                recibo.Estado = estado.IdEstado;
                recibo.FechaReg = DateTime.Now;

                _context.Recibos.Add(recibo);
                _context.Usuarios.Add(pre.Persona);

                _context.SaveChanges();

                pre.NumeroRecibo = recibo.NroRecibo;
                pre.FechaDePreInscripcion = DateTime.Now;
                pre.IdPersona = pre.Persona.IdUsuario;

                _context.Preinscripcions.Add(pre);
                _context.SaveChanges();

                transaction.Commit();

                result.Objeto = recibo.IdRecibo;
                result.Is_Error = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                result.Is_Error = true;
            }

            return result;

        }
    }
}
