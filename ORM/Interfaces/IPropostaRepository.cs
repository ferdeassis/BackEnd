using Entities;

namespace ORM.Interfaces
{
    public interface IPropostaRepository
    {
        Propostas GetCpf(string cpf);
        void Add(Propostas obj);
        // void Remove(int id);
        void Update(Propostas obj);
    }
}