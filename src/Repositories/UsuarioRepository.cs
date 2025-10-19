using backend.src.Data;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend.src.Repositories
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) => _context = context;

        public async Task<bool> CadastrarAsync(Usuario usuario)
        {
            bool emailExistente = await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email);
            if (emailExistente) return false;

            _context.Usuarios.Add(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> LoginAsync(string email, string senha)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email && u.Senha == senha);
        }
    }
}