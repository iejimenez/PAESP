using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Estudiante
    {
        public int Cedula { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int Celular { get; set; }
        public int Telefono { get; set; }
        public string Ciudad  { get; set; }
        public string Estado { get; set; }
        private string[] TipoIds { get => new string[]{ "C.C", "T.I"}; }
        public IReadOnlyList<string> CanCrear(Estudiante estudiante)
        {
            var errors = new List<string>();
            if (estudiante.Cedula == 0)
                errors.Add("Campo cedula vacio ");
            if (string.IsNullOrEmpty(estudiante.Apellidos))
                errors.Add("Campo Apellidos vacio ");
            if (string.IsNullOrEmpty(estudiante.TipoIdentificacion))
                errors.Add("Campo Tipo de Identificacion vacio ");            
            if (string.IsNullOrEmpty(estudiante.Correo))
                errors.Add("Campo Correo vacio ");           
            if (string.IsNullOrEmpty(estudiante.Nombres))
                errors.Add("Campo Nombres vacio ");
            if(!TipoIds.Contains(estudiante.TipoIdentificacion) && !string.IsNullOrEmpty(estudiante.TipoIdentificacion))
                errors.Add("Tipo identificacion Invalida ");

            return errors;
        }
    }
}
