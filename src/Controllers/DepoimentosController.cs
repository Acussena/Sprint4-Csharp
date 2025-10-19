using backend.src.Models;
using backend.src.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepoimentosController : ControllerBase
    {
        private readonly DepoimentoService _service;

        public DepoimentosController(DepoimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.ListarAsync();
            return Ok(lista);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var depoimento = await _service.ObterPorIdAsync(id);
            if (depoimento == null)
                return NotFound(new { Message = "Depoimento não encontrado." });

            return Ok(depoimento);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Depoimento d)
        {
            var novo = await _service.CriarAsync(d);
            return CreatedAtAction(nameof(GetById), new { id = novo.Id }, novo);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Depoimento d)
        {
            var atualizado = await _service.AtualizarAsync(id, d);
            if (!atualizado)
                return NotFound(new { Message = "Depoimento não encontrado." });

            return Ok(new { Message = "Depoimento atualizado com sucesso." });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var excluido = await _service.ExcluirAsync(id);
            if (!excluido)
                return NotFound(new { Message = "Depoimento não encontrado." });

            return Ok(new { Message = "Depoimento excluído com sucesso." });
        }
    }
}
