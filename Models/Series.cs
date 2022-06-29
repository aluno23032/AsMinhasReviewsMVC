using System.ComponentModel.DataAnnotations;

namespace SiteReviews.Models
{
    public class Series : Objetos
    {
        [Display(Name = "Número de temporadas")]
        public int NTemporadas { get; set; }

        [Display(Name = "Número de episódios")]
        public int NEpisodios { get; set; }

        public string Diretor { get; set; }

        public string Atores { get; set; }
    }
}
