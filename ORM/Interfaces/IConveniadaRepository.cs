using System.Collections.Generic;
using Entities;

namespace ORM.Interfaces
{
    public interface IConveniadaRepository
    {
        IEnumerable<Conveniadas> GetAll();
        Conveniadas GetDescricao(string conveniada);
    }
}