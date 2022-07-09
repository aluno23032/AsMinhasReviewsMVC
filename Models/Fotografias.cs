using System.ComponentModel.DataAnnotations;

namespace AsMinhasReviews.Models
{
    public class Fotografias
    {
        [Key]
        public int Id { get; set; }

        public string Fotografia { get; set; }
    }
}
