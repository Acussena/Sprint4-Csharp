using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Models
{
    public class Conscientizacao
    {
        public Guid Id { get; init; }
        public decimal ValorApostado { get; set; }
        public decimal? PossivelInvestimento { get; set; }
    }
}