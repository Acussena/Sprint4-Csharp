using System;
using Microsoft.EntityFrameworkCore;
using backend.src.Models;

namespace backend.src.Data
{
      public class AppDbContext : DbContext
      {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Usuario> Usuarios { get; set; } = default!;
            public DbSet<Conscientizacao> Conscientizacoes { get; set; } = default!;
            public DbSet<Questionario> Questionarios { get; set; } = default!;
            public DbSet<RedeApoio> RedesApoio { get; set; } = default!;
            public DbSet<Depoimento> Depoimentos { get; set; } = default!;

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                  modelBuilder.Entity<Usuario>(entity =>
                  {
                        entity.ToTable("USUARIOS_SPRINT4");

                        entity.HasKey(u => u.Id);
                        entity.Property(u => u.Id)
                        .HasDefaultValueSql("NEWID()");

                        entity.Property(u => u.Nome)
                        .IsRequired()
                        .HasMaxLength(2000);

                        entity.Property(u => u.Email)
                        .IsRequired()
                        .HasMaxLength(450);

                        entity.Property(u => u.Senha)
                        .IsRequired()
                        .HasMaxLength(2000);

                        entity.HasIndex(u => u.Email)
                        .IsUnique();
                  });

                  modelBuilder.Entity<Conscientizacao>(entity =>
                  {
                        entity.ToTable("CONSCIENTIZACAO");

                        entity.HasKey(c => c.Id);
                        entity.Property(c => c.Id)
                        .HasDefaultValueSql("NEWID()");

                        entity.Property(c => c.PossivelInvestimento)
                        .HasColumnType("decimal(18,2)");

                        entity.Property(c => c.ValorApostado)
                        .HasColumnType("decimal(18,2)");
                  });

                  modelBuilder.Entity<Questionario>(entity =>
                  {
                        entity.ToTable("QUESTIONARIO");

                        entity.HasKey(q => q.Id);
                        entity.Property(q => q.Id)
                        .HasDefaultValueSql("NEWID()");

                        entity.Property(q => q.ValorMensal)
                        .HasColumnType("decimal(18,2)");

                        entity.Property(q => q.Motivo)
                        .HasMaxLength(2000);
                  });

                  modelBuilder.Entity<RedeApoio>(entity =>
                  {
                        entity.ToTable("REDE_APOIO");

                        entity.HasKey(r => r.Id);
                        entity.Property(r => r.Id)
                        .HasDefaultValueSql("NEWID()");

                        entity.Property(r => r.Nome)
                        .IsRequired()
                        .HasMaxLength(2000);

                        entity.Property(r => r.Tipo)
                        .IsRequired()
                        .HasMaxLength(2000);

                        entity.Property(r => r.Contato)
                        .HasMaxLength(2000);
                  });


                  modelBuilder.Entity<Depoimento>(entity =>
                  {
                        entity.ToTable("DEPOIMENTOS");

                        entity.HasKey(d => d.Id);
                        entity.Property(d => d.Id)
                        .HasDefaultValueSql("NEWID()");

                        entity.Property(d => d.Nome)
                        .HasMaxLength(2000);

                        entity.Property(d => d.Titulo)
                        .IsRequired()
                        .HasMaxLength(2000);

                        entity.Property(d => d.Texto)
                        .IsRequired()
                        .HasMaxLength(4000);

                        entity.Property(d => d.DataCriacao)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");
                  });

                  base.OnModelCreating(modelBuilder);
            }
      }
}
