using NUnit.Framework;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAESP.UnitTest
{
    public class Pruebas2
    {
        public RepositorioEstudiantes _repositorioEstudiantes;
        [SetUp]
        public void Setup()
        {
            _repositorioEstudiantes = new RepositorioEstudiantes();
        }

        [TestCaseSource("RegistrarEstudianteData")]
        public void RegistrarEstudiante(Estudiante request, string expected)
        {

            var response = _repositorioEstudiantes.Guardar(request);
            Assert.AreEqual(expected, response);
        }

        private static IEnumerable<TestCaseData> RegistrarEstudianteData()
        {
            yield return new TestCaseData(
                new Estudiante
                {
                    Nombres = "Andres Jose",
                    Apellidos = "León Castillo",
                    Cedula = 10654323,
                    Celular = 314444444,
                    Ciudad = "Valledupar",
                    Correo = "andresleon@fake.com",
                    Telefono = 7272727,
                    TipoIdentificacion = "C.C"
                },
                "Datos guardados correctamente"
                ).SetName("Registro correcto primera vez");

            yield return new TestCaseData(
                new Estudiante
                {
                    Cedula = 10654323,
                    TipoIdentificacion = "C.C"
                },
                "Errores: Campo Apellidos vacio Campo Correo vacio Campo Nombres vacio "
                ).SetName("Registro Incorrecto primera vez campos obligatorios");

            yield return new TestCaseData(
                new Estudiante
                {
                    Nombres = "Andres Jose",
                    Apellidos = "León Castillo",
                    Cedula = 10654323,
                    Celular = 314444444,
                    Ciudad = "Valledupar",
                    Correo = "andresleon@fake.com",
                    Telefono = 7272727,
                    TipoIdentificacion = "T.C"
                },
                "Errores: Tipo identificacion Invalida "
                ).SetName("Registro Incorrecto Tipo identificacion Invalida");
        }
    }
}
