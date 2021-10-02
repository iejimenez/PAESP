using NUnit.Framework;

namespace PAESP_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCaseSource("RegistrarEstudiante")]
        public void PagarEmpleado(PagarEmpleadoRequest nominaRequest, string expected)
        {
            _PagarEmpleadoservice = new PagarEmpleadoService(_unitOfWork);
            var response = _PagarEmpleadoservice.Ejecutar(nominaRequest);
            Assert.AreEqual(expected, response.Message);
        }

        private static IEnumerable<TestCaseData> CreationsPagarEmpleado()
        {
            yield return new TestCaseData(
                new PagarEmpleadoRequest
                {
                    IdEmpleado = 2699540
                },
                "Nomina no existe"
                ).SetName("Pagar Empleado Correctamente");
        }
    }
}