using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Preinscripcion
    {
        public string IdPresinscripcion { get;set; }

        public DateTime FechaDePreInscripcion { get; set; }

        public string NumeroRecibo { get; set; }

        public string IdPersona { get; set; }

        public Usuario Persona { get; set; }

        public bool Guardar()
        {
            if (!Preinscripcion.ValidarCampos(this))
                return false;

            Data data = Data.GetInstance();
            Usuario usuario = data.getUsuario(this.Persona.TipodeIdentificacion, this.Persona.Cedula);
            if (usuario != null)
            {
                Preinscripcion p = data.getPreinscripcion(usuario.Id);
                if(p == null)
                {
                    data.AddPreinscripcion(p);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static bool ValidarCampos(Preinscripcion preinscripcion)
        {
            //if (string.IsNullOrEmpty(preinscripcion.NumeroRecibo))
            //    return false;
            if (preinscripcion.Persona== null)
                return false;


            if (!Usuario.ValidarCampos(preinscripcion.Persona))
                return false;

            return true;
        }
    }
}
