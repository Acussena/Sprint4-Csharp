using backend.src.Data;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.src.Repositories
{
    public class DepoimentoRepository
    {
        private readonly AppDbContext _context;

        public DepoimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Depoimento>> ListarAsync()
        {
            return await _context.Depoimentos.ToListAsync();
        }

        public async Task<Depoimento?> ObterPorIdAsync(Guid id)
        {
            return await _context.Depoimentos.FindAsync(id);
        }

        public async Task<Depoimento> AdicionarAsync(Depoimento depoimento)
        {
            await _context.Depoimentos.AddAsync(depoimento);
            await _context.SaveChangesAsync();
            return depoimento;
        }

        public async Task<bool> AtualizarAsync(Guid id, Depoimento novoDepoimento)
        {
            var existente = await _context.Depoimentos.FindAsync(id);
            if (existente == null) return false;

            existente.Nome = novoDepoimento.Nome;
            existente.Titulo = novoDepoimento.Titulo;
            existente.Texto = novoDepoimento.Texto;

            _context.Depoimentos.Update(existente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            var existente = await _context.Depoimentos.FindAsync(id);
            if (existente == null) return false;

            _context.Depoimentos.Remove(existente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
