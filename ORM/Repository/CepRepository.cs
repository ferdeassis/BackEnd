using System.Net.Http;
using System.Threading.Tasks;
using Entities.Dtos;
using ORM.Interfaces;

namespace ORM.Repository
{
    // public class CepRepository : ICepRepository
    // {
    //     public async Task<CepDto> GetCepAsync(string cep)
    //     {
    //         string url = $"https://viacep.com.br/ws/{cep}/json/";
    //         HttpClient httpClient = new HttpClient();
    //         HttpResponseMessage resposta = await httpClient.GetAsync(url);
    //         resposta.EnsureSuccessStatusCode();

    //         return await resposta.Content.ReadAsStringAsync();
    //     }
    // }
}