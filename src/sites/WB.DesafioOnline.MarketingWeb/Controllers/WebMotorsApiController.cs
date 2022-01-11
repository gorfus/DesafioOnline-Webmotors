using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WB.DesafioOnline.MarketingWeb.Integracoes.OnlineChallenge;
using WB.DesafioOnline.MarketingWeb.Models;

namespace WB.DesafioOnline.MarketingWeb.Controllers
{
    public class WebMotorsApiController : Controller
    {
        private readonly IInformacoesCarrosServicos _informacoesCarrosServicos;

        public WebMotorsApiController(IInformacoesCarrosServicos informacoesCarrosServicos)
        {
            _informacoesCarrosServicos = informacoesCarrosServicos;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Marcas(string search = "")
        {
            var marcas = await _informacoesCarrosServicos.TodasMarcas();
            return View(marcas);
        }
        public async Task<IActionResult> MarcasData(string search = "")
        {
            var marcas = await _informacoesCarrosServicos.TodasMarcas();
            var marcasSelect = (from m in marcas select new { id = m.ID, text = m.Name });

            return Ok(new { results = marcasSelect });
        }

        public async Task<IActionResult> ModelosPorMarca(int marcaId = 1)
        {
            var modelos = await _informacoesCarrosServicos.ModelosPorMarcaId(marcaId);
            return View(modelos);
        }
        public async Task<IActionResult> ModelosPorMarcaData(int marcaId, string marcaText)
        {
            var modelos = await _informacoesCarrosServicos.ModelosPorMarcaId(marcaId);
            var modelosSelect = (from m in modelos select new { id = m.ID, text = m.Name });
            return Ok(new { results = modelosSelect });
        }

        public async Task<IActionResult> VersoesPorModelo(int modeloId = 1)
        {
            var versoes = await _informacoesCarrosServicos.VersoesPorModelo(modeloId);
            return View(versoes);
        }
        public async Task<IActionResult> VersoesPorModeloData(int modeloId = 1)
        {
            var versoes = await _informacoesCarrosServicos.VersoesPorModelo(modeloId);
            var versoesSelect = (from m in versoes select new { id = m.ID, text = m.Name });
            return Ok(new { results = versoesSelect });
        }

        public async Task<IActionResult> TodosVeiculos()
        {
            var veiculos = await _informacoesCarrosServicos.TodosVeiculos();
            return View(veiculos);
        }
    }
}
