using Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts)
            : base(opts) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sessao>()
                .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });
            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(filme => filme.sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);
        }
        public DbSet<Filme> filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
