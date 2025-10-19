using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Data;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repositories
{
    public class RedeApoioRepository
    {
        private readonly AppDbContext _context;
        public RedeApoioRepository(AppDbContext context) => _context = context;

        public async Task<List<RedeApoio>> ListarAsync() => await _context.RedesApoio.OrderBy(r => r.Nome).ToListAsync();

        public async Task<RedeApoio?> ObterPorIdAsync(int id) => await _context.RedesApoio.FindAsync(id);

        public async Task<bool> InserirAsync(RedeApoio r)
        {
            _context.RedesApoio.Add(r);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAsync(RedeApoio r)
        {
            _context.RedesApoio.Update(r);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var item = await _context.RedesApoio.FindAsync(id);
            if (item == null) return false;
            _context.RedesApoio.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}