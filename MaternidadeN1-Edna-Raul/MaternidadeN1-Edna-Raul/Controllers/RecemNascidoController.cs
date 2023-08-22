using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaternidadeN1_Edna_Raul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecemNascidoController : ControllerBase
    {
        private readonly IRecemNascidoService _recemNascidoService;

        public RecemNascidoController(IRecemNascidoService recemNascidoService)
        {
            _recemNascidoService = recemNascidoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecemNascidoModel>> GetRecemNascidoByID(int id)
        {
            var recemNascido = await _recemNascidoService.GetRecemNascidoByID(id);
            if (recemNascido == null)
                return NotFound($"Recem Nascido com ID {id} não encontrado.");

            return Ok(recemNascido);
        }

        [HttpGet("apgar/{apgar}")]
        public async Task<ActionResult<List<RecemNascidoModel>>> GetRecemNascidoPorApgar(int apgar)
        {
            var recemNascido = await _recemNascidoService.GetRecemNascidoPorApgar(apgar);
            if (recemNascido == null)
                return NotFound($"Recem Nascido com apgar {apgar} não encontrado.");

            return Ok(recemNascido);
        }

    }
}
