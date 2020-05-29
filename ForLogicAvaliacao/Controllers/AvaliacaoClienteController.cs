using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace ForLogicAvaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AvaliacaoClienteController : ControllerBase
    {
        private readonly IAvaliacaoService _serv;
        public AvaliacaoClienteController(IAvaliacaoService serv)
        {
            _serv = serv;
        }

        // GET: api/AvaliacaoCliente/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _serv.GetClientesByIdAvaliacao(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
