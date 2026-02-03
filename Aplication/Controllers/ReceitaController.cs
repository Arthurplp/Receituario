using Domínio.Interfaces;
using Domínio.Model;
using Microsoft.AspNetCore.Mvc;

namespace Aplicação.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var receita = await _receitaService.GetById(id);

            if (receita == null)
                return NotFound(new { message = "Receita não encontrada" });

            return Ok(receita);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var receitas = await _receitaService.GetReceitas();
            return Ok(receitas);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Receita model)
        {
            var receitaCriada = await _receitaService.Create(model);

            if (receitaCriada == null)
                return BadRequest(new { message = "Dados inválidos para criação da Receita" });

            return CreatedAtAction(
                nameof(GetById),
                new { id = receitaCriada.Id },
                receitaCriada
            );
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] Receita model)
        {
            model.Id = id;

            var receitaAtualizada = await _receitaService.Edit(model);

            if (receitaAtualizada == null)
                return NotFound(new { message = "Receita não encontrada para atualização" });

            return Ok(receitaAtualizada);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _receitaService.Delete(id);
            return NoContent();
        }
    }
}