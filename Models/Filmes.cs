using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Filmes
    {
        [Key]
        public int Id { get; set; }

        public string Diretor { get; set; }

        public string Atores { get; set; }
    }
}
