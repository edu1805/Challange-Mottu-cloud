using AutoMapper;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.Context;
using Cp2WebApplication.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Cp2WebApplication.Controllers
{
    [ApiController]
    [Route("api/motos")]
    [SwaggerTag("Controller responsável por gerenciar motos.")]
    public class MotoController : ControllerBase
    {
        private readonly Cp2Context _context;
        private readonly IMapper _mapper;

        public MotoController(Cp2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todas as motos ou filtra por status.
        /// </summary>
        /// <param name="status">Status opcional para filtrar (ex: 'pronta', 'manutencao')</param>
        /// <returns>Lista de motos</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Listar motos", Description = "Retorna todas as motos ou apenas as que têm o status informado.")]
        [SwaggerResponse(200, "Lista de motos retornada com sucesso", typeof(IEnumerable<MotoDto>))]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult<IEnumerable<MotoDto>>> GetAll([FromQuery] string? status = null)
        {
            var query = _context.Motos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(m => m.Status == status.ToLower());

            var motos = await query.ToListAsync();
            return Ok(_mapper.Map<List<MotoDto>>(motos));
        }

        /// <summary>
        /// Obtém uma moto por ID.
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Buscar moto por ID", Description = "Retorna uma moto específica pelo ID.")]
        [SwaggerResponse(200, "Moto encontrada", typeof(MotoDto))]
        [SwaggerResponse(404, "Moto não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult<MotoDto>> GetById(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            return Ok(_mapper.Map<MotoDto>(moto));
        }

        /// <summary>
        /// Cria uma nova moto.
        /// </summary>
        [HttpPost("criar")]
        [SwaggerOperation(Summary = "Criar moto", Description = "Cria uma nova moto com os dados informados.")]
        [SwaggerResponse(201, "Moto criada com sucesso", typeof(MotoDto))]
        [SwaggerResponse(400, "Dados inválidos")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult<MotoDto>> Create([FromBody] CreateMotoDto dto)
        {
            try
            {
                var novaMoto = new Moto(dto.Placa, dto.Posicao, dto.Status);

                _context.Motos.Add(novaMoto);
                await _context.SaveChangesAsync();

                var result = _mapper.Map<MotoDto>(novaMoto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza uma moto existente.
        /// </summary>
        [HttpPut("editar/{id}")]
        [SwaggerOperation(Summary = "Atualizar moto", Description = "Atualiza os dados de uma moto existente.")]
        [SwaggerResponse(204, "Moto atualizada com sucesso")]
        [SwaggerResponse(400, "Erro nos dados enviados")]
        [SwaggerResponse(404, "Moto não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateMotoDto dto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            try
            {
                moto.AtualizarPosicao(dto.Posicao);
                moto.AtualizarStatus(dto.Status);

                _context.Motos.Update(moto);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        /// <summary>
        /// Deleta uma moto.
        /// </summary>
        [HttpDelete("delete/{id}")]
        [SwaggerOperation(Summary = "Deletar moto", Description = "Remove uma moto do sistema.")]
        [SwaggerResponse(204, "Moto deletada com sucesso")]
        [SwaggerResponse(404, "Moto não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<ActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}