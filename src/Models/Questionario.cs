using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Models
{
    public class Questionario
    {
        public Guid Id { get; init; }
        public int FrequenciaApostas { get; set; }
        public decimal ValorMensal { get; set; }
        public string? Motivo { get; set; }
    }
}