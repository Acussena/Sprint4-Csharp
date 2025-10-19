using backend.src.Models;
using backend.src.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/questionario")]
    public class QuestionarioController : ControllerBase
    {
        private readonly QuestionarioService _service;

        public QuestionarioController(QuestionarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Questionario q)
        {
            try
            {
                Guid idGerado = await _service.RegistrarRespostasAsync(q);

                return CreatedAtAction(nameof(GetById), new { id = idGerado }, new
                {
                    Message = "Questionário registrado com sucesso",
                    Id = idGerado
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no POST: {ex.Message}");
                return StatusCode(500, new { Message = "Ocorreu um erro interno no servidor." });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var questionario = await _service.ObterPorIdAsync(id);

            if (questionario == null)
                return NotFound(new { Message = "Questionário não encontrado." });

            return Ok(questionario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.ListarTodosAsync();
            return Ok(lista);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Questionario q)
        {
            try
            {
                var existente = await _service.ObterPorIdAsync(id);
                if (existente == null)
                    return NotFound(new { Message = "Questionário não encontrado." });

                existente.FrequenciaApostas = q.FrequenciaApostas;
                existente.ValorMensal = q.ValorMensal;
                existente.Motivo = q.Motivo;

                bool atualizado = await _service.AtualizarAsync(existente);
                if (!atualizado)
                    return BadRequest(new { Message = "Não foi possível atualizar o questionário." });

                return Ok(new { Message = "Questionário atualizado com sucesso" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no PUT: {ex.Message}");
                return StatusCode(500, new { Message = "Ocorreu um erro interno no servidor." });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                bool deletado = await _service.DeletarAsync(id);
                if (!deletado)
                    return NotFound(new { Message = "Questionário não encontrado." });

                return Ok(new { Message = "Questionário deletado com sucesso" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no DELETE: {ex.Message}");
                return StatusCode(500, new { Message = "Ocorreu um erro interno no servidor." });
            }
        }
    }
}
