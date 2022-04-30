namespace SiteReviews.Models
{
    public class Series
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Plataforma { get; set; }

        public DateTime Datalancamento { get; set; }

        public string Descricao { get; set; }

        public int NTemporadas { get; set; }

        public int NEpisodios { get; set; }

        public string Diretor { get; set; }

        public string Atores { get; set; }
    }
}
