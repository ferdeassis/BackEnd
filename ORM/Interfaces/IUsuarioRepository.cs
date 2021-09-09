using System.Threading.Tasks;
using Entities;
using Entities.Dtos;

namespace ORM.Interfaces
{
    public interface IUsuarioRepository
    {
        string Login(LoginDto obj);
    }
}