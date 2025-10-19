using System;

namespace backend.src.Models
{
    public class Depoimento
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

        public Depoimento() { }

        public Depoimento(string? nome, string titulo, string texto)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Titulo = titulo;
            Texto = texto;
            DataCriacao = DateTime.UtcNow;
        }
    }
}
