using backend.src.Models;
using backend.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api")]
    public class RedeApoioController : ControllerBase
    {
        private readonly RedeApoioService _service;
        public RedeApoioController(RedeApoioService service) => _service = service;

        [HttpGet("redeApoio")]
        public async Task<ActionResult<List<RedeApoio>>> GetAll()
        {
            try
            {
                var redes = await _service.ListarRedesAsync();
                return Ok(redes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao carregar redes de apoio", Details = ex.Message });
            }
        }

        [HttpGet("redeApoio/{id:int}")]
        public async Task<ActionResult<RedeApoio>> GetById(int id)
        {
            try
            {
                var rede = await _service.BuscarPorIdAsync(id);

                if (rede == null)
                    return NotFound(new { Message = "Rede de apoio não encontrada" });

                return Ok(rede);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao buscar rede de apoio", Details = ex.Message });
            }
        }
    }
}