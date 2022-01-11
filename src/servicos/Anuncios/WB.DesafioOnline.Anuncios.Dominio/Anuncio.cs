namespace WB.DesafioOnline.Anuncios.Dominio
{
    public class Anuncio
    {
        public Anuncio()
        {

        }
        public Anuncio(string marca,
                        string modelo,
                        string versao,
                        int ano,
                        int quilometragem,
                        string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        public int AnuncioId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
        private bool Ativo { get; set; }

        public void Atualizar(string marca,
                      string modelo,
                      string versao,
                      int ano,
                      int quilometragem,
                      string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        public void Ativar()
        {
            Ativo = true;
        }
        public void Desativar()
        {
            Ativo = false;
        }

    }
}
