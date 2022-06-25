using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Objetos
    {
        public Objetos()
        {
            ListaReviews = new HashSet<Reviews>();
            ListaFotografias = new HashSet<Fotografias>();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Fotografia { get; set; }

        public string Plataforma { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Descricao { get; set; }

        public ICollection<Reviews> ListaReviews { get; set; }

        public ICollection<Fotografias> ListaFotografias { get; set; }
    }
}
