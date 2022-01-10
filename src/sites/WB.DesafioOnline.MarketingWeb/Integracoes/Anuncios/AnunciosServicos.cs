using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Core;
using WB.DesafioOnline.MarketingWeb.Models;

namespace WB.DesafioOnline.MarketingWeb.Integracoes.Anuncios
{
    public interface IAnunciosServicos
    {
        Task<IEnumerable<AnuncioDTO>> Todos();
        Task<IEnumerable<AnuncioDTO>> PorMarca(string marca);
        Task<IEnumerable<AnuncioDTO>> PorModelo(string modelo);
        Task<IEnumerable<AnuncioDTO>> PorVersao(string versaO);
        Task<AnuncioDTO> PorId(int anuncioId);

        Task<ResponseResult> Cadastrar(AnuncioDTO anuncio);
        Task<ResponseResult> Atualizar(AnuncioDTO anuncio);
        Task<ResponseResult> Deletar(int anuncioId);
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

        #region Integração Api Anuncios
        public async Task<ResponseResult> Cadastrar(AnuncioDTO anuncio)
        {
            var response = await _httpClient.PostAsync("", SetStringContent(anuncio));
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ResponseResult();

            return new ResponseResult
            {
                Title = "Erro HTTP",
                Status = response.StatusCode.ToString(),
                Message = content
            };
        }
        public async Task<ResponseResult> Atualizar(AnuncioDTO anuncio)
        {
            var response = await _httpClient.PutAsync("", SetStringContent(anuncio));
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ResponseResult();

            return new ResponseResult
            {
                Title = "Erro HTTP",
                Status = response.StatusCode.ToString(),
                Message = content
            };
        }
        public async Task<ResponseResult> Deletar(int anuncioId)
        {
            var response = await _httpClient.DeleteAsync($"{anuncioId}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ResponseResult();

            return new ResponseResult
            {
                Title = "Erro HTTP",
                Status = response.StatusCode.ToString(),
                Message = content
            };
        }

        #endregion

        #region Integração Api Anunciosa
        public async Task<AnuncioDTO> PorId(int anuncioId)
        {
            var response = await _httpClient.GetAsync($"{anuncioId}");
            return await DeserializarObjetoResponse<AnuncioDTO>(response);
        }

        public async Task<IEnumerable<AnuncioDTO>> Todos()
        {
            var response = await _httpClient.GetAsync("");
            return await DeserializarObjetoResponse<IEnumerable<AnuncioDTO>>(response);
        }

        public async Task<IEnumerable<AnuncioDTO>> PorMarca(string marca)
        {
            var response = await _httpClient.GetAsync($"marca/{marca}");
            return await DeserializarObjetoResponse<IEnumerable<AnuncioDTO>>(response);
        }

        public async Task<IEnumerable<AnuncioDTO>> PorModelo(string modelo)
        {
            var response = await _httpClient.GetAsync($"modelo/{modelo}");
            return await DeserializarObjetoResponse<IEnumerable<AnuncioDTO>>(response);
        }

        public async Task<IEnumerable<AnuncioDTO>> PorVersao(string versao)
        {
            var response = await _httpClient.GetAsync($"versao/{versao}");
            return await DeserializarObjetoResponse<IEnumerable<AnuncioDTO>>(response);
        }
        #endregion

        protected StringContent SetStringContent(object dado) => new StringContent(JsonSerializer.Serialize(dado), Encoding.UTF8, "application/json");

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }
    }
}
