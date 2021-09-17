using System;
using System.Net;
using Entities.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ORM.Interfaces;
using Service.Token;

namespace Application.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenGenerator _tokenGenerator;
        public LoginController(IUsuarioRepository usuarioRepository, ITokenGenerator tokenGenerator)
        {
            _usuarioRepository = usuarioRepository;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public ActionResult Login(LoginDto obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = _usuarioRepository.Login(obj);
                if (resultado != "LOGADO")
                {
                    return Unauthorized(resultado);
                }
                var retornoToken = _tokenGenerator.GenerateToken(obj);
                return Ok(retornoToken);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}