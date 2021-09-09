using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaPropostaController : Controller
    {
        private readonly IConsultaPropostaRepository _cpRepository;
        public ConsultaPropostaController(IConsultaPropostaRepository cpRepository)
        {
            _cpRepository = cpRepository;
        }

        [HttpGet("{usuario}")]
        [Authorize]
        public ActionResult GetUser(string usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_cpRepository.GetUser(usuario));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}