using System;
using calculos.tests.Replicas;
using Service;
using Xunit;

namespace TesteUnitarioXUnit
{
    public class TesteUnitarioXUnit
    {
        [Fact]
        public void CalcularJurosTest()
        {
            var propostaRepository = new PropostaTesteRepository();
            var parametroRepository = new ParametroTesteRepository();
            var busControlTeste = new BusControlTeste();

            var cj = new PropostaService(propostaRepository, parametroRepository, busControlTeste);
            var resultado = cj.CalcularJuros(10, 1000);
            Assert.Equal((decimal)1104.62, (decimal)resultado);
        }
    }
}