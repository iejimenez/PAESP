﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAESP.Datos;
using PAESP.DTOS;
using PAESP.Models;
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
        public ConfigurationService(PaespDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<TiposIdenticacionDTO> ListTiposIdentificacion()
        {
            var tiposIdenti = _context.TipoIdentificacions.ToList();

            return _mapper.Map<List<TiposIdenticacionDTO>>(tiposIdenti);

        }
    }

    public class ReciboService
    {
        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public ReciboService(PaespDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Recibo GetRecibo(int id)
        {
            Recibo rec = _context.Recibos
                .Include(w => w.Concepto)
                .FirstOrDefault(f => f.IdRecibo == id);
            return rec;
        }
    }

}
