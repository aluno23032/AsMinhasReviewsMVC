using System.ComponentModel.DataAnnotations.Schema;
namespace SiteReviews.Models
{
    public class ReviewsFilmes
    {
        public int Id { get; set; }

        public string Conteúdo { get; set; }

        [ForeignKey(nameof(CriadorFK))]
        public int CriadorFK { get; set; }
        public Utilizadores IdUtilizador { get; set; }

        public int Rating { get; set; }

        [ForeignKey(nameof(IdFilmeFK))]
        public int IdFilmeFK { get; set; }
        public Filmes IdFilme { get; set; }
    }
}
