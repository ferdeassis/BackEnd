using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoController : Controller
    {
        private readonly ISituacaoRepository _situacaoRepository;
        public SituacaoController(ISituacaoRepository situacaoRepository)
        {
            _situacaoRepository = situacaoRepository;
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = _situacaoRepository.GetAll();
                return Ok(resultado);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{situacao}")]
        [Authorize]
        public ActionResult GetDescricao(string situacao)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_situacaoRepository.GetDescricao(situacao));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}