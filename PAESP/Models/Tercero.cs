using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Usuario
    {
        public string Cedula { get; set; }
        public string TipodeIdentificacion { get; set; }

        public string Nombres { get; set; }

        public string Apeliidos { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Ciudad { get; set; }

        public bool Guardar() {

            Data data = Data.GetInstance();
            Usuario usuario = data.getUsuario(this.TipodeIdentificacion, this.Cedula);
            if(usuario== null)
            {
                data.AddUsuario(this);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
