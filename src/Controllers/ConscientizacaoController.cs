// Em backend.src.Controllers/ConscientizacaoController.cs

using backend.src.Models;
using backend.src.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConscientizacaoController : ControllerBase
    {
        private readonly ConscientizacaoService _service;

        public ConscientizacaoController(ConscientizacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Conscientizacao c)
        {
            try
            {
                var sucesso = await _service.RegistrarReflexaoAsync(c);
                return sucesso
                    ? CreatedAtAction(nameof(Post), new { id = c.Id }, new { Message = "Conscientização registrada com sucesso" })
                    : BadRequest(new { Message = "Erro ao registrar conscientização." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "Ocorreu um erro interno no servidor." });
            }
        }
    }
}