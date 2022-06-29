using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteReviews.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data de criação")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Conteúdo")]
        [Required(ErrorMessage = "Escreva a sua review")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "Indique um rating")]
        [RegularExpression("[0-9]", ErrorMessage = "Selecione um valor")]
        [Range(1, 10)]
        public int Rating { get; set; }

        [ForeignKey(nameof(Criador))]
        public int CriadorFK { get; set; }
        public Utilizadores Criador { get; set; }

        [ForeignKey(nameof(Objeto))]
        public int ObjetoFK { get; set; }
        public Series Objeto { get; set; }
    }
}
