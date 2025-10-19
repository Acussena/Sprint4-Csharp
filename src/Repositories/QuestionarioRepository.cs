using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Data;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repositories
{
    public class QuestionarioRepository
    {
        private readonly AppDbContext _context;
        public QuestionarioRepository(AppDbContext context) => _context = context;

        public async Task<Guid> InserirAsync(Questionario q)
        {
            _context.Questionarios.Add(q);
            await _context.SaveChangesAsync();
            return q.Id;
        }

        public async Task<List<Questionario>> ListarTodosAsync()
        {
            return await _context.Questionarios.OrderBy(q => q.Id).ToListAsync();
        }

        public async Task<Questionario?> ObterPorIdAsync(Guid id) => await _context.Questionarios.FindAsync(id);

        public async Task<bool> AtualizarAsync(Questionario q)
        {
            _context.Questionarios.Update(q);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var item = await _context.Questionarios.FindAsync(id);
            if (item == null) return false;
            _context.Questionarios.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}