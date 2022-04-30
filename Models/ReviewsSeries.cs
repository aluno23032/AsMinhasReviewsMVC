using System.ComponentModel.DataAnnotations.Schema;
namespace SiteReviews.Models
{
    public class ReviewsSeries
    {
        public int Id { get; set; }

        public string Conteudo { get; set; }

        [ForeignKey(nameof(CriadorFK))]
        public int CriadorFK { get; set; }
        public Utilizadores IdUtilizador { get; set; }

        public int Rating { get; set; }

        [ForeignKey(nameof(IdSerieFK))]
        public int IdSerieFK { get; set; }
        public Series IdSerie { get; set; }
    }
}
