﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public DateTime FEchaInscripcion { get; set; }


        public virtual ICollection<Programa> Programas { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
