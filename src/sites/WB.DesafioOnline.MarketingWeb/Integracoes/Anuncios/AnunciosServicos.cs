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
        Task<IEnumerable<AnuncioDTO>> Todos();
        Task<IEnumerable<AnuncioDTO>> PorMarca(int marcaId);
        Task<IEnumerable<AnuncioDTO>> PorModelo(int modeloId);
        Task<IEnumerable<AnuncioDTO>> PorVersao();

        Task Cadastrar(AnuncioDTO anuncio);
        Task Atualizar(AnuncioDTO anuncio);
        Task Remover(int anuncioId);
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

        public async Task Atualizar(AnuncioDTO anuncio)
        {
            throw new NotImplementedException();
        }

        public async Task Cadastrar(AnuncioDTO anuncio)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(int anuncioId)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<AnuncioDTO>> PorMarca(int marcaId)
        {
            var response = await _httpClient.GetAsync("Make");
            return await JsonSerializer.DeserializeAsync<IEnumerable<AnuncioDTO>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<AnuncioDTO>> PorModelo(int modeloId)
        {
            var response = await _httpClient.GetAsync("Make");
            return await JsonSerializer.DeserializeAsync<IEnumerable<AnuncioDTO>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<AnuncioDTO>> PorVersao()
        {
            var response = await _httpClient.GetAsync("Make");
            return await JsonSerializer.DeserializeAsync<IEnumerable<AnuncioDTO>>(await response.Content.ReadAsStreamAsync());
        }

      

        public async Task<IEnumerable<AnuncioDTO>> Todos()
        {
            var response = await _httpClient.GetAsync("Make");
            return await JsonSerializer.DeserializeAsync<IEnumerable<AnuncioDTO>>(await response.Content.ReadAsStreamAsync());
        }

    }
}
