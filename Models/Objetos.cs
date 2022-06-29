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

        public string Capa { get; set; }

        public string Plataforma { get; set; }

        [Display(Name = "Data de lançamento")]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Lista de reviews")]
        public ICollection<Reviews> ListaReviews { get; set; }

        [Display(Name = "Lista de fotografias")]
        public ICollection<Fotografias> ListaFotografias { get; set; }
    }
}
