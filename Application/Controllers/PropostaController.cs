using System;
using System.Net;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : Controller
    {
        private readonly IPropostaService _propostaService;
        public PropostaController(IPropostaService propostaService)
        {
            _propostaService = propostaService;
        }

        [HttpGet("{cpf}")]
        [Authorize]
        public ActionResult GetCpf(string cpf)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                return Ok(_propostaService.GetCpf(cpf));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add(Propostas obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _propostaService.AddAsync(obj);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult Update(Propostas obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _propostaService.Update(obj);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}