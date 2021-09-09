using System.Collections.Generic;
using Entities;

namespace ORM.Interfaces
{
    public interface IConsultaPropostaRepository
    {
        IEnumerable<Propostas> GetUser(string usuario);
    }
}