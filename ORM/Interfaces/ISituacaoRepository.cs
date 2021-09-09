using System.Collections.Generic;
using Entities;

namespace ORM.Interfaces
{
    public interface ISituacaoRepository
    {
        IEnumerable<Situacao> GetAll();
        Situacao GetDescricao(string situacao);
    }
}