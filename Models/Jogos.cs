using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    /// <summary>
    /// Representa os dados do jogo
    /// </summary>
    public class Jogos
    {
        public Jogos()
        {
            ListaReviews = new HashSet<Reviews>();
        }

        /// <summary>
        /// Chave primária da tabela dos jogos
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Jogo
        /// </summary>
        [Required(ErrorMessage = "O nome do jogo é de preenchimento obrigatório.")]
        public string Nome { get; set; }

        public string NomeFormatado { get; set; }

        /// <summary>
        /// Capa do Jogo
        /// </summary>
        public string Capa { get; set; }

        /// <summary>
        /// Plataformas do Jogo
        /// </summary>
        [Required(ErrorMessage = "A plataforma do jogo é de preenchimento obrigatório.")]
        public string Plataformas { get; set; }

        /// <summary>
        /// Data de lançamento do Jogo
        /// </summary>
        [Required(ErrorMessage = "A data de lançamento do jogo é de preenchimento obrigatório.")]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLancamento { get; set; }

        /// <summary>
        /// Descrição do jogo
        /// </summary>
        [Required(ErrorMessage = "A descrição do jogo é de preenchimento obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        /// <summary>
        /// Rating do jogo
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:0.0}")]  
        public decimal Rating { get; set; }

        /// <summary>
        /// Lista de reviews do jogo
        /// </summary>
        public ICollection<Reviews> ListaReviews { get; set; }
    }
}
