using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.Interfaces;
using Service;
using Service.Interfaces;

namespace TesteUnitario
{
    [TestClass]
    public class CalcularJurosTest
    {


        [TestMethod]
        public void CalcularJurosService()
        {
            CalcularJurosService cj = new CalcularJurosService();
            var result = cj.CalcularJuros(10, 1000);
            Assert.AreEqual(result, 1104.62);
        }
    }
}
