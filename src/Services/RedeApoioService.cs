using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Models;
using backend.src.Services;
using backend.src.Requests;
using backend.src.Repositories;

namespace backend.src.Services
{
    public class RedeApoioService
    {
        private readonly RedeApoioRepository _repo;
        public RedeApoioService(RedeApoioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<RedeApoio>> ListarRedesAsync() => await _repo.ListarAsync();
        public async Task<RedeApoio?> BuscarPorIdAsync(int id) => await _repo.ObterPorIdAsync(id);
        public async Task<bool> AdicionarAsync(RedeApoio rede) => await _repo.InserirAsync(rede);

        public async Task<bool> AtualizarAsync(RedeApoio rede) => await _repo.AtualizarAsync(rede);

        public async Task<bool> RemoverAsync(int id) => await _repo.DeletarAsync(id);
    }
}