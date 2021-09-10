using System.Threading.Tasks;
using Entities;

namespace Service.Interfaces
{
    public interface IPropostaService
    {
        Propostas GetCpf(string cpf);
        Task AddAsync(Propostas obj);
        void Update(Propostas obj);
        decimal CalcularJuros(int prazo, decimal Vlr_Solicitado);
        void ValidarPrazo(int prazo);
        DadosFila FilaProposta(int proposta);
    }
}