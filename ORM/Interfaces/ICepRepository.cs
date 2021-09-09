using System.Threading.Tasks;
using Entities.Dtos;

namespace ORM.Interfaces
{
    public interface ICepRepository
    {
        Task<CepDto> GetCepAsync(CepDto cep);
    }
}