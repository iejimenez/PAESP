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
            Assert.AreEqual(true, usuario.Guardar());
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
                Ciudad = "Valledupar"
            };
            Assert.AreEqual(true, usuario.Guardar());
            Assert.AreEqual(false, usuario.Guardar());
        }



    }
}