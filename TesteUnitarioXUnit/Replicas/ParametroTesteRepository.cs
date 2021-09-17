using Entities;
using ORM.Interfaces;

namespace calculos.tests.Replicas
{
    public class ParametroTesteRepository : IParametroRepository
    {
        public Parametro GetParametro()
        {
            return new Parametro
            {
                Juro_Composto = 1
            };
        }

        public void Update(Parametro obj)
        {
            throw new System.NotImplementedException();
        }
    }
}