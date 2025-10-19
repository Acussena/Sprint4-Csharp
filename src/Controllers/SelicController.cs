using Microsoft.AspNetCore.Mvc;
using backend.src.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/selic")]
    public class SelicController : ControllerBase
    {
        private readonly SelicService _selicService;

        public SelicController(SelicService selicService)
        {
            _selicService = selicService;
        }

        [HttpGet("historico")]
        public async Task<IActionResult> Historico()
        {
            var historico = await _selicService.ObterHistoricoAsync();
            return Ok(historico.OrderBy(x => x.Data));
        }

        [HttpGet("simulacao")]
        public async Task<IActionResult> Simulacao(decimal valorInicial = 1000)
        {
            var historico = await _selicService.ObterHistoricoAsync();
            historico = historico.OrderBy(x => x.Data).ToList();

            decimal investimento = valorInicial;
            var resultados = new List<object>();

            foreach (var item in historico)
            {
                if (item.Valor > 0 && item.Valor < 1000)
                {
                    var rendimento = investimento * (item.Valor / 100) / 12;
                    investimento += rendimento;
                }

                resultados.Add(new
                {
                    item.Data,
                    item.Valor,
                    Saldo = Math.Round(investimento, 2)
                });
            }

            return Ok(resultados);
        }
    }
}
