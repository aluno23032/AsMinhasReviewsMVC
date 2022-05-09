using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Jogos
    {
        [Key]
        public int Id { get; set; }

        public string Desenvolvedores { get; set; }
    }
}
