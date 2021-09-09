using Entities;

namespace Service.Interfaces
{
    public interface IClienteService
    {
        Cliente GetCpf(string cpf);
        void Add(Cliente obj);
        void Update(Cliente obj);
    }
}
