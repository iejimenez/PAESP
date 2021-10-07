using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAESP.Datos;
using PAESP.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Services
{
    public class ConceptoService
    {
        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public ConceptoService(IMapper mapper, PaespDbContext contenxt)
        {
            _mapper = mapper;
            _context = contenxt;
        }
        public List<ConceptoDTO> ListConceptos()
        {
            var Conceptos = _context.Conceptos.ToList();
            if (true) { } 

            return _mapper.Map<List<ConceptoDTO>>(Conceptos);

        }
    }
}
