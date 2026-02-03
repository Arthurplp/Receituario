using Domínio.Interfaces;
using Domínio.Model;
using Microsoft.AspNetCore.Mvc;

namespace Aplicação.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var material = await _materialService.GetById(id);

            if (material == null)
                return NotFound(new { message = "Material não encontrado" });

            return Ok(material);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var materiais = await _materialService.GetMateriais();
            return Ok(materiais);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Material model)
        {
            var materialCriado = await _materialService.Create(model);

            if (materialCriado == null)
                return BadRequest(new { message = "Dados inválidos para criação do Material" });

            return CreatedAtAction(
                nameof(GetById),
                new { id = materialCriado.Id },
                materialCriado
            );
        }

        // PUT api/material/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] Material model)
        {
            model.Id = id;

            var materialAtualizado = await _materialService.Edit(model);

            if (materialAtualizado == null)
                return NotFound(new { message = "Material não encontrado para atualização" });

            return Ok(materialAtualizado);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _materialService.Delete(id);
            return NoContent();
        }
    }
}