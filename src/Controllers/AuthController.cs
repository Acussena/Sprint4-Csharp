using backend.src.Models;
using backend.src.Requests;
using backend.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; // <-- Para SqlException
using Microsoft.EntityFrameworkCore; // <-- Para DbUpdateException
using System;
using System.Threading.Tasks;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UsuarioService _service;

        public AuthController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioRequest usuarioRequest)
        {
            try
            {
                var usuario = new Usuario
                {
                    Nome = usuarioRequest.Nome,
                    Email = usuarioRequest.Email,
                    Senha = usuarioRequest.Senha
                };

                var cadastrado = await _service.CadastrarAsync(usuario);

                if (!cadastrado)
                    return BadRequest(new { message = "Email já cadastrado." });

                return Created("", new
                {
                    message = "Usuário cadastrado com sucesso!",
                    usuario = new
                    {
                        usuario.Nome,
                        usuario.Email
                    }
                });
            }
            catch (DbUpdateException ex)
            {
                // Captura erro de violação de UNIQUE (SQL Server)
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                {
                    return BadRequest(new { message = "Email já cadastrado." });
                }

                Console.WriteLine($"Erro no cadastro: {ex.Message}");
                return StatusCode(500, new { message = "Ocorreu um erro interno no servidor." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no cadastro: {ex.Message}");
                return StatusCode(500, new { message = "Ocorreu um erro interno no servidor." });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioRequest usuarioRequest)
        {
            return await _service.LoginAsync(usuarioRequest.Email, usuarioRequest.Senha)
                ? Ok(new { message = "Login realizado!" })
                : Unauthorized(new { message = "Usuário ou senha inválidos." });
        }
    }
}
