using System.ComponentModel.DataAnnotations.Schema;

namespace SiteReviews.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        public string Conteúdo { get; set; }

        [ForeignKey(nameof(CriadorFK))]
        public int CriadorFK { get; set; }
        public Utilizadores IdUtilizador { get; set; }

        public int Rating { get; set; }

        [ForeignKey(nameof(IdJogoFK))]
        public int IdJogoFK { get; set; }
        public Jogos IdJogo { get; set; }
    }
}
