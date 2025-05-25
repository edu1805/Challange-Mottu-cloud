using AutoMapper;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.DTOs;
using Cp2WebApplication.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cp2WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Controller responsável por gerenciar a localização atual das motos no pátio.")]
    public class LocalizacaoAtualController : ControllerBase
    {
        private readonly ILocalizacaoAtualRepository _repository;
        private readonly IMapper _mapper;

        public LocalizacaoAtualController(ILocalizacaoAtualRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Lista todas as localizações registradas das motos.")]
        [SwaggerResponse(200, "Retorna a lista de localizações.", typeof(IEnumerable<LocalizacaoAtualDto>))]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult<IEnumerable<LocalizacaoAtualDto>>> ListarTodas()
        {
            var localizacoes = await _repository.ListarTodasAsync();
            var dto = _mapper.Map<IEnumerable<LocalizacaoAtualDto>>(localizacoes);
            return Ok(dto);
        }

        [HttpGet("moto/{motoId}")]
        [SwaggerOperation(Summary = "Obtém a localização atual de uma moto pelo ID.")]
        [SwaggerResponse(200, "Retorna a localização da moto.", typeof(LocalizacaoAtualDto))]
        [SwaggerResponse(404, "Localização para a moto não encontrada.")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult<LocalizacaoAtualDto>> ObterPorMotoId(int motoId)
        {
            var localizacao = await _repository.ObterPorMotoIdAsync(motoId);
            if (localizacao == null)
                return NotFound($"Localização para a moto {motoId} não encontrada.");

            var dto = _mapper.Map<LocalizacaoAtualDto>(localizacao);
            return Ok(dto);
        }

        [HttpPost("create")]
        [SwaggerOperation(Summary = "Cria uma nova localização atual para uma moto.")]
        [SwaggerResponse(201, "Localização criada com sucesso.", typeof(LocalizacaoAtualDto))]
        [SwaggerResponse(400, "Dados inválidos para criação.")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult> Criar([FromBody] CriarLocalizacaoAtualDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var localizacao = new LocalizacaoAtual(dto.MotoId, dto.CoordenadaX, dto.CoordenadaY);
            await _repository.AdicionarAsync(localizacao);
            var retornoDto = _mapper.Map<LocalizacaoAtualDto>(localizacao);

            return CreatedAtAction(nameof(ObterPorMotoId), new { motoId = localizacao.MotoId }, retornoDto);
        }

        [HttpPut("moto_edit/{motoId}")]
        [SwaggerOperation(Summary = "Atualiza a localização de uma moto existente.")]
        [SwaggerResponse(204, "Atualização concluída com sucesso.")]
        [SwaggerResponse(404, "Localização da moto não encontrada.")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult> Atualizar(int motoId, [FromBody] AtualizarLocalizacaoAtualDto dto)
        {
            var localizacao = await _repository.ObterPorMotoIdAsync(motoId);
            if (localizacao == null)
                return NotFound($"Localização da moto {motoId} não encontrada.");

            localizacao.AtualizarCoordenadas(dto.CoordenadaX, dto.CoordenadaY);
            await _repository.AtualizarAsync(localizacao);

            return NoContent();
        }

        [HttpDelete("moto_delete/{motoId}")]
        [SwaggerOperation(Summary = "Deleta o registro de localização de uma moto.")]
        [SwaggerResponse(204, "Localização deletada com sucesso.")]
        [SwaggerResponse(404, "Localização da moto não encontrada.")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult> Deletar(int motoId)
        {
            var localizacao = await _repository.ObterPorMotoIdAsync(motoId);
            if (localizacao == null)
                return NotFound($"Localização da moto {motoId} não encontrada.");

            await _repository.DeletarAsync(localizacao);
            return NoContent();
        }
    }
}