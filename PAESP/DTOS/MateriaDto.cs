using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.DTOS
{
    public class MateriaDto
    {
        public int IdMateria { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public int Creditos { get; set; }
    }

}
