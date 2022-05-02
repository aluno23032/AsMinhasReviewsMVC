using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Jogos
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Plataforma { get; set; }

        public DateTime Datalancamento { get; set; }

        public string Descricao { get; set; }

        public string Desenvolvedores { get; set; }
    }
}
