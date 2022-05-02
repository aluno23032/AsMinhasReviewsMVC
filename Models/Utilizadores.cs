using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Utilizadores
    {
        [Key]
        public int Id { get; set; }

        public string NomeUtilizador { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Fotografia { get; set; }
    }
}
