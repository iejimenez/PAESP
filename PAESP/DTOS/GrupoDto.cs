using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.DTOS
{
    public class GrupoDto
    {
        public int IdGrupo { get; set; }

   
        public string Nombre { get; set; }


        public int Cupo { get; set; }

        public int IdMateria { get; set; }

    
        public int IdProfesor { get; set; }


        public virtual MateriaDto Materia { get; set; }


        public virtual ProfesorDto Profesor { get; set; }

    }
}
