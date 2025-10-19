using backend.src.Models;
using backend.src.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace backend.src.Services
{
    public class QuestionarioService
    {
        private readonly QuestionarioRepository _repo;

        public QuestionarioService(QuestionarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> RegistrarRespostasAsync(Questionario q)
        {
            if (q.FrequenciaApostas < 1 || q.FrequenciaApostas > 5)
                throw new ArgumentException("A frequência deve estar entre 1 e 5.");

            if (q.ValorMensal <= 0)
                throw new ArgumentException("O valor mensal deve ser maior que 0.");

            return await _repo.InserirAsync(q);
        }

        public async Task<Questionario?> ObterPorIdAsync(Guid id)
        {
            return await _repo.ObterPorIdAsync(id);
        }

        public async Task<List<Questionario>> ListarTodosAsync()
        {
            return await _repo.ListarTodosAsync();
        }

        public async Task<bool> AtualizarAsync(Questionario q)
        {
            return await _repo.AtualizarAsync(q);
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            return await _repo.DeletarAsync(id);
        }
    }
}
