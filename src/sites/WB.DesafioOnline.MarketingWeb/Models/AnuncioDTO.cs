namespace WB.DesafioOnline.MarketingWeb.Models
{
    public class AnuncioDTO
    {
        public int? AnuncioId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }

    public class AnuncioFiltroDTO
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
