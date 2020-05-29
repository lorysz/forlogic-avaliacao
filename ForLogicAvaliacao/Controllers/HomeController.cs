using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace ForLogicAvaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        protected readonly IHomeService _serv;
        public HomeController(IHomeService serv)
        {
            _serv = serv;
        }

        // GET: api/Home
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _serv.GetInformacoes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
