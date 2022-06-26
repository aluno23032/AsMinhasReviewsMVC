using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteReviews.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaReviews = new HashSet<Reviews>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome de utilizador é de preenchimento obrigatório.")]
        [StringLength(32, ErrorMessage = "O nome de utilizador não pode ter mais do que {1} caracteres.", MinimumLength = 8)]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+", ErrorMessage = "No nome de utilizador só são aceites letras.")]
        public string NomeUtilizador { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(64, ErrorMessage = "O email não pode ter mais do que {1} caracteres.", MinimumLength = 8)]
        [EmailAddress(ErrorMessage = "Só são aceites endereços de email válidos.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento é de preenchimento obrigatório.")]
        public DateTime DataNascimento { get; set; }

        public string Fotografia { get; set; }

        public ICollection<Reviews> ListaReviews { get; set; }

        public string UserID { get; set; }

        public Boolean admin { get; set; } = false;
    }
}
