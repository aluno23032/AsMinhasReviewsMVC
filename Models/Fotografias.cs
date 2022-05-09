using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteReviews.Models
{
    public class Fotografias
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(IdUtilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizadores IdUtilizador { get; set; }

        public string Fotografia { get; set; }
    }
}
