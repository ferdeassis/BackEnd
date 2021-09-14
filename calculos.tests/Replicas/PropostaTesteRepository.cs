using Entities;
using ORM.Interfaces;

namespace calculos.tests.Replicas
{
    public class PropostaTesteRepository : IPropostaRepository
    {
        public void Add(Propostas obj)
        {
            throw new System.NotImplementedException();
        }

        public DadosFila FilaProposta(int proposta)
        {
            throw new System.NotImplementedException();
        }

        public Propostas GetCpf(string cpf)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Propostas obj)
        {
            throw new System.NotImplementedException();
        }
    }
}