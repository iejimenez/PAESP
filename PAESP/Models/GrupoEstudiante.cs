using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class GrupoEstudiante
    {
        [Key]
        public int IdGrupoEstudiante { get; set; }

        public int IdGrupo { get; set; }
        public int IdEstudiante { get; set; }

        public double PrimerCorte { get; set; }
        public double SegundoCorte { get; set; }

        public double TercerCorte { get; set; }

        [NotMapped]
        public double Ponderado { get { return Math.Round((PrimerCorte * 0.3) + (SegundoCorte * 0.3) + (TercerCorte * 0.4), 2); } }

        public int Estado { get; set; }

        [ForeignKey("IdGrupo")]
        public virtual Grupo Grupo { get; set; }
        
        [ForeignKey("IdEstudiante")]
        public virtual Estudiante Estudiante { get; set; }
    }
}
