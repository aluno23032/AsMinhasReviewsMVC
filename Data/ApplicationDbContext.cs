using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AsMinhasReviews.Models;

namespace AsMinhasReviews.Data;

public class ApplicationUser : IdentityUser { }

/// <summary>
/// Classe que funciona como a base de dados do nosso projeto
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Utilizadores>().HasData(
               new Utilizadores()
               {
                   Id = 1,
                   Nome = "josesilva",
               },
               new Utilizadores()
               {
                   Id = 2,
                   Nome = "joaotiago",
               },
               new Utilizadores()
               {
                   Id = 3,
                   Nome = "ricardosousa",
               }
            );
        modelBuilder.Entity<Series>().HasData(
            new Series
            {
                Id = 1,
                Nome = "Breaking Bad",
                Capa = "breakingbad.jpg",
                Plataforma = "Netflix",
                DataLancamento = new DateTime(2008, 1, 20),
                Descricao = "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.",
                ListaReviews = new List<Reviews>(),
                ListaFotografias = new List<Fotografias>()
            }
        );

        modelBuilder.Entity<Reviews>().HasData(
           new Reviews
           {
               Id = 1,
               DataCriacao = new DateTime(2022, 6, 26),
               Conteudo = "When you finish the show you'll never be the same..I guarantee you",
               Rating = 10,
               CriadorFK = 1,
               JogoFK = 1
           }
        );
    }

    public DbSet<AsMinhasReviews.Models.Reviews> Reviews { get; set; }
    public DbSet<AsMinhasReviews.Models.Jogos> Jogos { get; set; }
    public DbSet<AsMinhasReviews.Models.Utilizadores> Utilizadores { get; set; }
}

