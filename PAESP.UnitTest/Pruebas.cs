using NUnit.Framework;
using PAESP.Models;

namespace PAESP.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ObtenerInstaciasDeDatos()
        {
            PAESP.Models.Data data =  PAESP.Models.Data.GetInstance();
            Assert.AreNotEqual(null, data);
            Assert.AreNotEqual(null, data.Usuarios);
            Assert.AreNotEqual(null, data.Preinscripciones);

        }

        [Test]
        public void InsertUsuarioNotRegistrado()
        {
            Data data = Data.GetInstance();
            Usuario usuario = new Usuario();
            Assert.AreEqual(false, usuario.Guardar());
        }

        [Test]
        public void InsertUsuarioRegistrado()
        {
            Data data = Data.GetInstance();
            data.LimpiarUsuario();
            Usuario usuario = new Usuario() { 
                Cedula="1063961939",
                TipodeIdentificacion = "CC",
                Nombres = "Ivan E",
                Apeliidos = "Jimenez M", 
                Celular = "3022964612",
                Ciudad = "Valledupar",
                Correo = "iejimenez01@gmail.com"
            };
            Assert.AreEqual(true, usuario.Guardar());
            Assert.AreEqual(false, usuario.Guardar());
        }

        [Test]
        public void ValidarCamposDelUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Cedula = "",
                TipodeIdentificacion = "CC",
                Nombres = "Ivan E",
                Apeliidos = "Jimenez M",
                Celular = "3022964612",
                Ciudad = "Valledupar"
            };
            Usuario usuario2 = new Usuario()
            {
                Cedula = "1063961939",
                TipodeIdentificacion = "",
                Nombres = "Ivan E",
                Apeliidos = "Jimenez M",
                Celular = "3022964612",
                Ciudad = "Valledupar"
            };
            Usuario usuario3 = new Usuario()
            {
                Cedula = "1063961939",
                TipodeIdentificacion = "CC",
                Nombres = "",
                Apeliidos = "",
                Celular = "3022964612",
                Ciudad = "Valledupar"
            };
            Usuario usuario4 = new Usuario()
            {
                Cedula = "15489421",
                TipodeIdentificacion = "CC",
                Nombres = "Ivan E",
                Apeliidos = "Jimenez M",
                Celular = "3022964612",
                Ciudad = "vaaaa",
                Correo = "holapeuqeño"
            };

            Assert.IsFalse(Usuario.ValidarCampos(usuario));
            Assert.IsFalse(Usuario.ValidarCampos(usuario2));
            Assert.IsFalse(Usuario.ValidarCampos(usuario3));
            Assert.IsFalse(Usuario.ValidarCampos(usuario4));

        }
    }
}