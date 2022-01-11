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
        Task<GridPaginado<AnuncioDTO>> Pesquisar(AnuncioFiltroDTO filtro);
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

        public async Task<ResponseResult> Cadastrar(AnuncioDTO anuncio)
        {
            var response = await _httpClient.PostAsync("", SetStringContent(anuncio));

            if (response.IsSuccessStatusCode)
                return new ResponseResult();

            return new ResponseResult
            {
                Title = "Erro HTTP",
                Status = response.StatusCode.ToString(),
                Message = await response.Content.ReadAsStringAsync()
            };
        }
        public async Task<ResponseResult> Atualizar(AnuncioDTO anuncio)
        {
            var response = await _httpClient.PutAsync("", SetStringContent(anuncio));

            if (response.IsSuccessStatusCode)
                return new ResponseResult();

            return new ResponseResult
            {
                Title = "Erro HTTP",
                Status = response.StatusCode.ToString(),
                Message = await response.Content.ReadAsStringAsync()
            };
        }
        public async Task<ResponseResult> Deletar(int anuncioId)
        {
            var response = await _httpClient.DeleteAsync($"{anuncioId}");

            if (response.IsSuccessStatusCode)
                return new ResponseResult();

            return new ResponseResult
            {
                Title = "Erro HTTP",
                Status = response.StatusCode.ToString(),
                Message = await response.Content.ReadAsStringAsync()
            };
        }

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

        public async Task<GridPaginado<AnuncioDTO>> Pesquisar(AnuncioFiltroDTO filtro)
        {
            var response = await _httpClient.PostAsync("filtrar", SetStringContent(filtro));
            return await DeserializarObjetoResponse<GridPaginado<AnuncioDTO>>(response);
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

        #region Uteis
        protected StringContent SetStringContent(object dado) => new StringContent(JsonSerializer.Serialize(dado), Encoding.UTF8, "application/json");

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }
        #endregion

    }

    public class EnviarParaExclusao
    {
        public int AnuncioId { get; set; }
    }
}
