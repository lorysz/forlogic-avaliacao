using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dto.Usuario;
using Service.Interfaces;

namespace ForLogicAvaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _serv;
        public UsuarioController(IUsuarioService serv)
        {
            _serv = serv;
        }

        // POST: api/Usuario
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Post(LoginUsuarioDto user)
        {
            try
            {
                var result = _serv.LoginUsuario(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
