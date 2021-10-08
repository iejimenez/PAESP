using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAESP.Clases;
using PAESP.Datos;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Services
{
    public class CalendarioService
    {
        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public CalendarioService(PaespDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CalendarioAcademico> Listcalendarios() 
        {
            List<CalendarioAcademico> calendarios = _context.CalendarioAcademicos
                .Include(w => w.Periodo)
                .ToList();
            return calendarios;
        }

        public AjaxData SaveCalendario(CalendarioAcademico calendar)
        {
            AjaxData result = new AjaxData();           
            try
            {                                         
                _context.CalendarioAcademicos.Add(calendar);
                _context.SaveChanges();              
            
                result.Is_Error = false;               
            }
            catch (Exception ex)
            {           
                result.Is_Error = true;
            }

            return result;

        }
    }
}
