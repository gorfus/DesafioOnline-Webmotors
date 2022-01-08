using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WB.DesafioOnline.MarketingWeb.Models;

namespace WB.DesafioOnline.MarketingWeb.Integracoes.OnlineChallenge
{

    public interface IInformacoesCarrosServicos
    {
        //PagedViewModel
        Task<IEnumerable<MarcaDTO>> TodasMarcas();
        Task<IEnumerable<ModeloDTO>> ModelosPorMarcaId(int marcaId);
        Task<IEnumerable<VersaoDTO>> VersoesPorModelo(int modeloId);
        Task<IEnumerable<VeiculoDTO>> TodosVeiculos();
    }

    public class InformacoesCarrosServicos : IInformacoesCarrosServicos
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public InformacoesCarrosServicos(IHttpClientFactory clientFactory, HttpClient httpClient)
        {
            _clientFactory = clientFactory;
            _httpClient = _clientFactory.CreateClient("onlinechallenge");
        }

        public async Task<IEnumerable<MarcaDTO>> TodasMarcas()
        {
            var response = await _httpClient.GetAsync("Make");
            return await JsonSerializer.DeserializeAsync<IEnumerable<MarcaDTO>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<ModeloDTO>> ModelosPorMarcaId(int marcaId)
        {
            var response = await _httpClient.GetAsync($"Model?MakeID={marcaId}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<ModeloDTO>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<VersaoDTO>> VersoesPorModelo(int modeloId)
        {
            var response = await _httpClient.GetAsync($"Version?ModelID={modeloId}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<VersaoDTO>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<VeiculoDTO>> TodosVeiculos()
        {
            var response = await _httpClient.GetAsync("Vehicles");
            return await JsonSerializer.DeserializeAsync<IEnumerable<VeiculoDTO>>(await response.Content.ReadAsStreamAsync());
        }
    }
}
