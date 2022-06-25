using System;
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

        public DbSet<SiteReviews.Models.Reviews> Reviews { get; set; }

        public DbSet<SiteReviews.Models.Fotografias> Fotografias { get; set; }

        public DbSet<SiteReviews.Models.Objetos> Objetos { get; set; }

        public DbSet<SiteReviews.Models.Filmes> Filmes { get; set; }

        public DbSet<SiteReviews.Models.Jogos> Jogos { get; set; }

        public DbSet<SiteReviews.Models.Series> Series { get; set; }

        public DbSet<SiteReviews.Models.Utilizadores> Utilizadores { get; set; }
    }
}
