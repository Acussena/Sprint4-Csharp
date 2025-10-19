using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Data;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repositories
{
    public class ConscientizacaoRepository
    {
        private readonly AppDbContext _context;
        public ConscientizacaoRepository(AppDbContext context) => _context = context;


        public async Task<bool> InserirAsync(Conscientizacao c)
        {
            _context.Conscientizacoes.Add(c);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<List<Conscientizacao>> ListarTodosAsync()
        {
            return await _context.Conscientizacoes.OrderByDescending(c => c.Id).ToListAsync();
        }


        public async Task<Conscientizacao?> ObterPorIdAsync(int id) => await _context.Conscientizacoes.FindAsync(id);


        public async Task<bool> AtualizarAsync(Conscientizacao c)
        {
            _context.Conscientizacoes.Update(c);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeletarAsync(int id)
        {
            var item = await _context.Conscientizacoes.FindAsync(id);
            if (item == null) return false;
            _context.Conscientizacoes.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}