using backend.src.Models;
using backend.src.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.src.Services
{
    public class DepoimentoService
    {
        private readonly DepoimentoRepository _repository;

        public DepoimentoService(DepoimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Depoimento>> ListarAsync()
        {
            return await _repository.ListarAsync();
        }

        public async Task<Depoimento?> ObterPorIdAsync(Guid id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<Depoimento> CriarAsync(Depoimento d)
        {
            return await _repository.AdicionarAsync(d);
        }

        public async Task<bool> AtualizarAsync(Guid id, Depoimento d)
        {
            return await _repository.AtualizarAsync(id, d);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _repository.ExcluirAsync(id);
        }
    }
}
