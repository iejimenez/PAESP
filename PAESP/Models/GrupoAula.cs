using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class GrupoAula
    {
        [Key]
        public int IdGrupoaula { get; set; }
        public string Descripcion { get; set; }
        public int IdAula { get; set; }

        public int IdGrupo { get; set; }

        public int Dia { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        [ForeignKey("IdAula")]
        public virtual Aula Aula { get; set; }

        [ForeignKey("IdGrupo")]
        public virtual Grupo Grupo { get; set; }
        public int Estado { get; set; }
    }
}
