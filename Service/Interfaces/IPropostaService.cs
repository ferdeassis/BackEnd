using System.Collections.Generic;
using Entities;

namespace Service.Interfaces
{
    public interface IPropostaService
    {
        Propostas GetCpf(string cpf);
        void Add(Propostas obj);
        // void Remove(int id);
        void Update(Propostas obj);
        decimal CalcularJuros(int prazo, decimal Vlr_Solicitado);
        void ValidarPrazo(int prazo);
    }
}