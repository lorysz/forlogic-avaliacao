using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dto.Cliente;
using Service.Interfaces;

namespace ForLogicAvaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _serv;
        public ClienteController(IClienteService serv)
        {
            _serv = serv;
        }

        // GET: api/Cliente
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


        // GET: api/Cliente
        [HttpGet("combo")]
        public IActionResult GetComboCliente()
        {
            try
            {
                var result = _serv.GetAllCombo();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cliente/5
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

        // POST: api/Cliente
        [HttpPost]
        [Authorize]
        public IActionResult Post(CadastrarClienteDto value)
        {
            try
            {
                var result = _serv.ValidarCnpjExistente(value.Cnpj, 0);

                if (result)
                {
                    return Ok("Este Cnpj já foi cadastrado anteriormente. Verifique a lista de clientes.");
                }

                _serv.CadastrarCliente(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Cliente/5
        [HttpPut]
        [Authorize]
        public IActionResult Put(AlterarClienteDto value)
        {
            try
            {
                var result = _serv.ValidarCnpjExistente(value.Cnpj, value.IdCliente);

                if (result)
                {
                    return Ok("Este Cnpj já foi cadastrado anteriormente. Verifique a lista de clientes.");
                }

                _serv.AlterarCliente(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cliente/validarcnpjexistente
        [HttpGet("validarcnpjexistente")]
        public IActionResult GetCnpjExistente(string cnpj, int idCliente)
        {
            try
            {
                var result = _serv.ValidarCnpjExistente(cnpj, idCliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
