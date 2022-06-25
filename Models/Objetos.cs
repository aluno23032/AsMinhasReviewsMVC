using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Objetos
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Fotografia { get; set; }

        public string Plataforma { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Descricao { get; set; }

        public ICollection<Reviews> ListaReviews { get; set; }
    }
}
