﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteReviews.Models;

namespace SiteReviews.Data
{
    public class SiteReviewsContext : DbContext
    {
        public SiteReviewsContext (DbContextOptions<SiteReviewsContext> options)
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
                   Nome  = "joaotiago",
               },
               new Utilizadores()
               {
                   Id = 3,
                   Nome = "ricardosousa",
               }
            );
            modelBuilder.Entity<Series>().HasData(
                new Series { Id = 1, Nome = "Breaking Bad", Capa = "breakingbad.jpg", Plataforma = "Netflix", DataLancamento = new DateTime(2008, 1, 20), 
                    Descricao = "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.",
                ListaReviews = new List<Reviews>(), ListaFotografias = new List<Fotografias>()
                }
            );

            modelBuilder.Entity<Reviews>().HasData(
               new Reviews { Id = 1, DataCriacao = new DateTime(2022, 6, 26), Conteudo = "When you finish the show you'll never be the same..I guarantee you", 
                   Rating = 10, CriadorFK = 1, JogoFK = 1}
            );
        }

        public DbSet<SiteReviews.Models.Reviews> Reviews { get; set; }

        public DbSet<SiteReviews.Models.Fotografias> Fotografias { get; set; }

        public DbSet<SiteReviews.Models.Objetos> Objetos { get; set; }

        public DbSet<SiteReviews.Models.Filmes> Filmes { get; set; }

        public DbSet<SiteReviews.Models.Jogos> Jogos { get; set; }

        public DbSet<SiteReviews.Models.Series> Series { get; set; }

        public DbSet<SiteReviews.Models.Utilizadores> Utilizadores { get; set; }
    }
}
