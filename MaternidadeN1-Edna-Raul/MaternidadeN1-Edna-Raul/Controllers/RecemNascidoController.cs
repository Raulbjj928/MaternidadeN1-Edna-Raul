using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

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

        [HttpGet]
        public async Task<ActionResult<List<RecemNascidoModel>>> GetAllRecemNascido()
        {
            var recemNascidos = await _recemNascidoService.GetAllRecemNascidos();
            if(recemNascidos == null)
                return NotFound("Not Found");
            return Ok(recemNascidos);
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

        [HttpGet("idMae/{idMae}/RecemNascido/{genero}")]
        public async Task<ActionResult<List<RecemNascidoModel>>> GetRecemNascidoPorGenero(string genero, int idMae)
        {
            var recemNascidosGenero = await _recemNascidoService.GetRecemNascidoPorGenero(genero, idMae);
            if (recemNascidosGenero.IsNullOrEmpty())
                return NotFound("seleção não encontrada");
            return recemNascidosGenero;
        }
        [HttpGet("idMae/{idMae}/RecemNascido/tipoDeParto/{tipoDeParto}")]
        public async Task<ActionResult<List<RecemNascidoModel>>> GetRecemNascidoPorTipoParto(string tipoDeParto, int idMae)
        {
            var recemNascidosTipoParto = await _recemNascidoService.GetRecemNascidoPorTipoParto(tipoDeParto, idMae);
            if (recemNascidosTipoParto.IsNullOrEmpty())
                return NotFound("seleção não encontrada");
            return recemNascidosTipoParto;
        }

        [HttpGet("idMae/{idMae}/RecemNascido/peso/{peso}")]
        public async Task<ActionResult<List<RecemNascidoModel>>> GetRecemNascidoPorPeso(int peso, int idMae)
        {
            var recemNascidosPorPeso = await _recemNascidoService.GetRecemNascidoPorPeso(peso, idMae);
            if (recemNascidosPorPeso.IsNullOrEmpty())
                return NotFound("seleção não encontrada");
            return recemNascidosPorPeso;
        }


        [HttpPost]
        public async Task<ActionResult<RecemNascidoModel>> PostRecemNascido(RecemNascidoDTO recemNascidoRequest)
        {
            var bebe = await _recemNascidoService.PostRecemNascido(recemNascidoRequest);
            if (bebe.MaeId is null) return NotFound("Mãe inexistente!");
            return Ok(bebe);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RecemNascidoModel>> UpdateRecemNascido(int id, RecemNascidoDTO recemNascidoRequest)
        {
            var bebe = await _recemNascidoService.UpdateRecemNascido(id, recemNascidoRequest);
            if (bebe == null) 
                return NotFound("Id não encontrado!");
                       
            return Ok(bebe);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteRecemNascido(int id)
        {
            var recemNascido = await _recemNascidoService.GetRecemNascidoByID(id);

            if (recemNascido == null)
            {
                return NotFound($"Recem Nascido com o ID {id} não encontrado.");
            }

            await _recemNascidoService.DeleteRecemNascido(id);

            return Ok("Recem Nascido deletado com sucesso");
        }
    }
}
