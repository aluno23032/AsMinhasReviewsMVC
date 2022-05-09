using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteReviews.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        public string Conteudo { get; set; }

        [ForeignKey(nameof(IdUtilizador))]
        public int CriadorFK { get; set; }
        public Utilizadores IdUtilizador { get; set; }

        public int Rating { get; set; }

        [ForeignKey(nameof(IdObjeto))]
        public int IdObjetoFK { get; set; }
        public Series IdObjeto { get; set; }
    }
}
