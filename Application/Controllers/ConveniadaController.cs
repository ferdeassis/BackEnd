using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConveniadaController : Controller
    {
        private readonly IConveniadaRepository _conveniadaRepository;
        public ConveniadaController(IConveniadaRepository conveniadasRepository)
        {
            _conveniadaRepository = conveniadasRepository;
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = _conveniadaRepository.GetAll();
                return Ok(resultado);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{conveniada}")]
        [Authorize]
        public ActionResult GetDescricao(string conveniada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_conveniadaRepository.GetDescricao(conveniada));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}