using MaternidadeN1_Edna_Raul.DTOs;
using MaternidadeN1_Edna_Raul.Interfaces;
using MaternidadeN1_Edna_Raul.Models;
using MaternidadeN1_Edna_Raul.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaternidadeN1_Edna_Raul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaeController : ControllerBase
    {
        public readonly IMaeService _service;

        public MaeController(IMaeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MaeModel>>> GetAllMaes()
        {
            var maes = await _service.GetAllMaes();

            if (maes == null) { return NotFound(); }

            return Ok(maes);
        }

        [HttpGet("MaePorCPF/{cpf}")]
        public async Task<ActionResult<MaeModel>> GetMaesPorCPF(string cpf)
        {
            var mae = await _service.GetMaeByCPF(cpf);

            if (mae == null) { return NotFound(); }

            return Ok(mae);
        }

        [HttpGet("MaePorId/{id}")]
        public async Task<ActionResult<MaeModel>> GetMaeByID(int id)
        {
            var mae = await _service.GetMaeByID(id);

            if (mae == null) { return NotFound(); }

            return Ok(mae);
        }
        
        [HttpGet("RNsPorMaeId/{id}")]
        public async Task<ActionResult<List<RecemNascidoModel>>> GetRNsPorMaeId(int id)
        {
            var bebesPorMae = await _service.GetRNsPorMae(id);

            if (bebesPorMae == null) { return NotFound(); }

            return Ok(bebesPorMae);
        }

        [HttpGet("MaePorstadoCivil/{estadoCivil}")]
        public async Task<ActionResult<List<MaeModel>>> GetMaesPorEstadoCivil(string estadoCivil)
        {
            var maes = await _service.GetMaesEstadoCivil(estadoCivil);

            if (maes == null) { return NotFound(); }

            return Ok(maes);
        }

        [HttpPost("PostMae")]
        public async Task<ActionResult<MaeModel>> PostMae(MaeDTO maeRequest)
        {
            var mae = await _service.PostMae(maeRequest);

            if (mae.Id is null) { return BadRequest($"Já existe uma mãe com este CPF : {maeRequest.CPF}"); }

            return Ok(mae);
        }

        [HttpPut("UpdateMae/{id}")]
        public async Task<ActionResult<MaeModel>> UpdateMae(int id, MaeDTO maeRequest)
        {
            var mae = await _service.UpdateMae(id, maeRequest);

            if (mae.Id is null) { return NotFound($"ID : {id} não encontrado!"); }

            return Ok(mae);
        }

        [HttpPatch("UpdateMaeHistorico/{id}")]
        public async Task<ActionResult<MaeModel>> PatchMaeHistoricoMedico(int id, string historicoRequest)
        {
            var mae = await _service.PatchMaeHistoricoMedico(id, historicoRequest);

            if (mae.Id is null) { return NotFound($"ID : {id} não encontrado!"); }

            return Ok(mae);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecemNascido(int id)
        {
            await _service.DeleteMae(id);

            return NoContent();
        }
    }
}
