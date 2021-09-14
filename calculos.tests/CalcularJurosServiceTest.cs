using calculos.tests.Replicas;
using NUnit.Framework;
using Service;

namespace calculos.tests
{
    public class CalcularJurosServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalcularJurosTest()
        {
            var propostaRepository = new PropostaTesteRepository();
            var parametroRepository = new ParametroTesteRepository();
            var busControlTeste = new BusControlTeste();

            var cj = new PropostaService(propostaRepository, parametroRepository, busControlTeste);
            var resultado = cj.CalcularJuros(10, 1000);
            Assert.AreEqual(1104.62, resultado);
        }
    }
}