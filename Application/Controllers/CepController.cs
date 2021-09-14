using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Entities.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ORM.Interfaces;

namespace Application.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : Controller
    {
        [HttpGet("{cep}")]
        public ActionResult GetCep(string cep)
        {
            try
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseFromServer = reader.ReadToEnd();
                    response.Close();
                    return Ok(responseFromServer);
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private readonly ICepRepository _cepRepository;

        public CepController(ICepRepository cepRepository)
        {
            _cepRepository = cepRepository;
        }
        public async Task<CepDto> Get(string cep)
        {
            var ceps = await _cepRepository.GetCep(cep);
            return ceps;
        }
    }
}