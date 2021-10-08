using AutoMapper;
using PAESP.DTOS;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Concepto, ConceptoDTO>().ReverseMap();
            CreateMap<TipoIdentificacion, TiposIdenticacionDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Materia, MateriaDto>().ReverseMap();
            CreateMap<Profesor, ProfesorDto>().ReverseMap();
            CreateMap<Grupo, GrupoDto>()
                
                .ReverseMap();


        }
    }
}
