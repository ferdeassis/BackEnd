using System;
using System.Net;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Interfaces;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{cpf}")]
        [Authorize]
        public ActionResult Get(string cpf)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = _clienteService.GetCpf(cpf);
                return Ok(resultado);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(Cliente obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _clienteService.Add(obj);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult Update(Cliente obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _clienteService.Update(obj);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}