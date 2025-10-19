// backend/src/Services/SelicService.cs
using backend.src.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace backend.src.Services
{
    public class SelicService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://api.bcb.gov.br/dados/serie/bcdata.sgs.11/dados?formato=json&dataInicial=01/01/2016&dataFinal=18/02/2025";

        public SelicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SelicData>> ObterHistoricoAsync()
        {
            var resultado = await _httpClient.GetFromJsonAsync<List<BCData>>(ApiUrl);
            var lista = new List<SelicData>();

            if (resultado != null)
            {
                foreach (var item in resultado)
                {
                    if (!string.IsNullOrEmpty(item.Data) && !string.IsNullOrEmpty(item.Valor))
                    {
                        if (decimal.TryParse(item.Valor, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                        {
                            lista.Add(new SelicData
                            {
                                Data = item.Data,
                                Valor = valor
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
