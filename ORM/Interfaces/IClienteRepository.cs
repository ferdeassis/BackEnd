using Entities;
using Entities.Dtos;

namespace ORM.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetCpf(string cpf);
        void Add(Cliente obj);
        void Update(Cliente obj);
    }
}