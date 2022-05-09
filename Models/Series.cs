using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }

        public int NTemporadas { get; set; }

        public int NEpisodios { get; set; }

        public string Diretor { get; set; }

        public string Atores { get; set; }
    }
}
