using Entities;

namespace ORM.Interfaces
{
    public interface IPropostaRepository
    {
        Propostas GetCpf(string cpf);
        void Add(Propostas obj);
        void Update(Propostas obj);
        DadosFila FilaProposta(int proposta);
    }
}