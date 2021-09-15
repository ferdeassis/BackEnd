using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICepRepository _cepRepository;
        public CepController(ICepRepository cepRepository)
        {
            _cepRepository = cepRepository;
        }

        [HttpGet("{cep}")]
        [Authorize]
        public async Task<CepDto> Get([FromRoute] string cep)
        {
            var ceps = await _cepRepository.GetCep(cep);
            return ceps;
        }
    }
}