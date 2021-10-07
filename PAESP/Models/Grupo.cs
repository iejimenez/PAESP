using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupo { get; set; }

        public string Nombre { get; set; }

        public int Cupo { get; set; }

        public int IdMateria { get; set; }

        public int IdProfesor { get; set; }

        [ForeignKey("IdMateria")]
        public virtual Materia Materia { get; set; }

        [ForeignKey("IdProfesor")]
        public virtual Profesor Profesor { get; set; }

        public ICollection<GrupoAula> Horaio {get;set;}

        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
