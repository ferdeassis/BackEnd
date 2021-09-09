using System;
using System.Net;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametroController : Controller
    {
        private readonly IParametroRepository _parametroRepository;
        public ParametroController(IParametroRepository parametroRepository)
        {
            _parametroRepository = parametroRepository;
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetParametro()
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                var resultado = _parametroRepository.GetParametro();
                return Ok(resultado);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult Update(Parametro obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _parametroRepository.Update(obj);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}