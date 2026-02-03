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
        public async Task<ActionResult> GetById(Guid Id)

        {
            try
            {
                var material = await _materialService.GetById(Id);
                return Ok(material);
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Material model)
        {
            try
            {
                var materialCriado = await _materialService.Create(model);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = materialCriado.Id },
                    materialCriado
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}