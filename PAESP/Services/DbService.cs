using AutoMapper;
using PAESP.Datos;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Services
{
    public class DbService
    {
        private readonly IMapper _mapper;
        private readonly PaespDbContext _context;
        public DbService(PaespDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


       
    }
}
