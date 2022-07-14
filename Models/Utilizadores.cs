using System.ComponentModel.DataAnnotations;
namespace AsMinhasReviews.Models
{
    /// <summary>
    /// Representa os dados do utilizador
    /// </summary>
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaReviews = new HashSet<Reviews>();
        }

        /// <summary>
        /// Chave primária para a tabela dos utilizadores
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do utilizador
        /// </summary>
        /// [Display(Name = "Nome do Utilizador")]
        [Required(ErrorMessage = "O nome de utilizador é de preenchimento obrigatório.")]
        [StringLength(32, ErrorMessage = "O {0} deve ter, pelo menos, {2} e um máximo de {1} carateres.", MinimumLength = 8)]

        public string Nome { get; set; }
        
        /// <summary>
        /// Data de nascimento do utilizador
        /// </summary>
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de nascimento é de preenchimento obrigatório.")]
        public DateTime DataNascimento { get; set; }


        /// <summary>
        /// Lista das reviews que o utilizador criou
        /// </summary>
        public ICollection<Reviews> ListaReviews { get; set; }


        /// <summary>
        /// Atributo para executar a chave forasteira que permite ligar a tabela da autenticação à tabela dos utilizadores
        /// </summary>
        public string UserID { get; set; }
    }
}
