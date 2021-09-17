using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Entities.Dtos;
using Newtonsoft.Json;
using ORM.Interfaces;

namespace ORM.Repository
{
    public class CepRepository : ICepRepository
    {
        private static HttpClient ceps = new HttpClient();
        public async Task<CepDto> GetCep(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            var response = await ceps.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            CepDto c = JsonConvert.DeserializeObject<CepDto>(result);
            return c;
        }
    }
}