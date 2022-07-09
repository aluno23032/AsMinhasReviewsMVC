using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AsMinhasReviews.Models
{
    /// <summary>
    /// Representa os dados da review
    /// </summary>
    public class Reviews
    {
        public Reviews()
        {
            DataCriacao = DateTime.Now;
        }

        /// <summary>
        /// Chave primária para a tabela das reviews
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Data de criação da review
        /// </summary>
        [Display(Name = "Data de criação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Conteúdo escrito da review
        /// </summary>
        [Display(Name = "Conteúdo")]
        [Required(ErrorMessage = "Escreva a sua review.")]
        public string Conteudo { get; set; }

        /// <summary>
        /// Rating que o utilizador atribui ao objeto
        /// </summary>
        [Required(ErrorMessage = "Selecione o seu rating")]
        [RegularExpression("[0-9]{1,2}", ErrorMessage = "Selecione um valor válido.")]
        [Range(1, 10, ErrorMessage = "O valor escolhido deve ser de 1 a 10.")]
        public int Rating { get; set; }

        //Chave forasteira do criador da review 
        [ForeignKey(nameof(Criador))]
        public int CriadorFK { get; set; }
        public Utilizadores Criador { get; set; }

        //Chave forasteira do jogo sobre o qual a review é feita
        [Required(ErrorMessage = "Escolha o jogo para o qual pretende fazer a review.")]
        [Display(Name = "Jogo")]
        [ForeignKey(nameof(Jogo))]
        public int JogoFK { get; set; }
        public Jogos Jogo { get; set; }
    }
}
