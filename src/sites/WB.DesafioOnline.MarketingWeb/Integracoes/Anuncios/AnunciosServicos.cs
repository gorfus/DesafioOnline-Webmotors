using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Dominio;
using WB.DesafioOnline.MarketingWeb.Models;

namespace WB.DesafioOnline.MarketingWeb.Integracoes.Anuncios
{
    public interface IAnunciosServicos
    {
        Task<IEnumerable<Anuncio>> Todos();
        Task<IEnumerable<Anuncio>> PorMarca(int marcaId);
        Task<IEnumerable<Anuncio>> PorModelo(int modeloId);
        Task<IEnumerable<Anuncio>> PorVersao();

        void Adicionar(Anuncio anuncio);
        void Atualizar(Anuncio anuncio);
        void Remover(int anuncioId);
    }

    public class AnunciosServicos : IAnunciosServicos
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public AnunciosServicos(IHttpClientFactory clientFactory, HttpClient httpClient)
        {
            _clientFactory = clientFactory;
            _httpClient = _clientFactory.CreateClient("anunciosapi");
        }

        public void Adicionar(Anuncio anuncio)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Anuncio anuncio)
        {
            throw new NotImplementedException();
        }

        public void Remover(int anuncioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Anuncio>> PorMarca(int marcaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Anuncio>> PorModelo(int modeloId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Anuncio>> PorVersao()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Anuncio>> Todos()
        {
            //var response = await _httpClient.GetAsync($"");
            //return await JsonSerializer.DeserializeAsync<IEnumerable<Anuncio>>(await response.Content.ReadAsStreamAsync());
            throw new NotImplementedException();
        }
    }
}
