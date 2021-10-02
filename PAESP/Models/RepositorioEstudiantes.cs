using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class RepositorioEstudiantes
    {
        public List<Estudiante> Estudiantes { get; set; }
        public RepositorioEstudiantes()
        {
            Estudiantes = new List<Estudiante>();
            DatosIniciales();
        }
        private void DatosIniciales()
        {
            var est1 = new Estudiante
            {
                Nombres="Jose Salazar", Apellidos="Martin Diaz", Cedula=1073663, Celular=31838383, Ciudad="Valledupar", Correo="JoseSal@fake.com", Estado="Registrado",
                Telefono=7272727, TipoIdentificacion="C.C"
            };
            Estudiantes.Add(est1);
        }
        public string Guardar(Estudiante estudiante)
        {
            IReadOnlyList<string> errors = estudiante.CanCrear(estudiante);
            if (errors.Any())
            {
                string listaErrors = "Errores: ";
                foreach (var item in errors)
                {
                    listaErrors += item.ToString();
                }
                return listaErrors;
            }
            else
            {
                Estudiantes.Add(estudiante);
                return "Datos guardados correctamente";
            }
            
        }
    }
}
