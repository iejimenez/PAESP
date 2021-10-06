using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Cedula { get; set; }
        public string TipodeIdentificacion { get; set; }

        public string Nombres { get; set; }

        public string Apeliidos { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Ciudad { get; set; }

        public string Correo { get; set; }

        public bool Guardar() 
        {
            if (!Usuario.ValidarCampos(this))
                return false;

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


        public static bool ValidarCampos(Usuario user)
        {
            if (string.IsNullOrEmpty(user.TipodeIdentificacion))
                return false;
            if (string.IsNullOrEmpty(user.Cedula))
                return false;
            if (string.IsNullOrEmpty(user.Nombres))
                return false;
            if (string.IsNullOrEmpty(user.Apeliidos)) 
                return false;
            if (string.IsNullOrEmpty(user.Celular))
                return false;

            if (string.IsNullOrEmpty(user.Correo))
                return false;
            string email = user.Correo;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
                return false;

            return true;
        }
    }
}
