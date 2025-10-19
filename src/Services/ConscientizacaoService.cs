// Em backend.src.Services/ConscientizacaoService.cs

using backend.src.Models;
using backend.src.Repositories;
using System;
using System.Threading.Tasks; // Necessário para Task

namespace backend.src.Services
{
    public class ConscientizacaoService
    {
        private readonly ConscientizacaoRepository _repo;

        public ConscientizacaoService(ConscientizacaoRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> RegistrarReflexaoAsync(Conscientizacao c)
        {
            if (c.ValorApostado <= 0)
                throw new ArgumentException("O valor apostado deve ser maior que 0.");

            return await _repo.InserirAsync(c);
        }
    }
}