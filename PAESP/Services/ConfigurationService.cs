using AutoMapper;
using PAESP.Datos;
using PAESP.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Services
{
    public class ConfigurationService
    {
        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public ConfigurationService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<TiposIdenticacionDTO> ListTiposIdentificacion()
        {
            var tiposIdenti = _context.TipoIdentificacions.ToList();

            return _mapper.Map<List<TiposIdenticacionDTO>>(tiposIdenti);

        }
    }
}
