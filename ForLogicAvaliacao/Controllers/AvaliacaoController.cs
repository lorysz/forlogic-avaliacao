using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dto.Avaliacao;
using Service.Interfaces;

namespace ForLogicAvaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _serv;
        public AvaliacaoController(IAvaliacaoService serv)
        {
            _serv = serv;
        }

        // GET: api/Avaliacao/5
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _serv.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Avaliacao/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _serv.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Avaliacao
        [HttpPost]
        public IActionResult Post(CadastrarAvaliacaoDto value)
        {
            try
            {
                var result = _serv.ValidarAvaliacaoAtual(value.Mes, value.Ano);
                if (result)
                {
                    _serv.CadastrarAvaliacao(value);

                } else
                {
                    return Ok("Já foi realizado uma avaliação este mês.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        // POST: api/Avaliacao
        [HttpGet("validacao")]
        public IActionResult GetValidacao(int mes, int ano)
        {
            try
            {
                var result = _serv.ValidarAvaliacaoAtual(mes, ano);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
