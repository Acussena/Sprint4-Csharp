using backend.src.Models;
using backend.src.Repositories;
using System.Threading.Tasks;

namespace backend.src.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CadastrarAsync(Usuario usuario) => await _repository.CadastrarAsync(usuario);

        public async Task<bool> LoginAsync(string email, string senha) => await _repository.LoginAsync(email, senha);
    }
}