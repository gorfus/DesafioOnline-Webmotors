using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Dominio;
using WB.DesafioOnline.MarketingWeb.Integracoes.Anuncios;
using WB.DesafioOnline.MarketingWeb.Models;

namespace WB.DesafioOnline.MarketingWeb.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnunciosServicosLocal _anunciosServicosLocal;

        public AnunciosController(IAnunciosServicosLocal anunciosServicosLocal)
        {
            _anunciosServicosLocal = anunciosServicosLocal;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var anuncios = await _anunciosServicosLocal.Todos();
            return View(anuncios);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(AnuncioDTO anuncio)
        {
            try
            {
                await _anunciosServicosLocal.Adicionar(anuncio);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Editar(int anuncioId)
        {
            var anuncio = _anunciosServicosLocal.PorId(anuncioId);
            return View(anuncio);
        }

        [HttpPut]
        public IActionResult Editar(Anuncio anuncio)
        {
            _anunciosServicosLocal.Atualizar(anuncio);
            return View("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int anuncioId)
        {
            if (anuncioId == 0)
                throw new Exception("Necesário enviar o id do anuncio para exclusão");

            var anuncio = await _anunciosServicosLocal.PorId(anuncioId);
            _anunciosServicosLocal.Remover(anuncio);

            return View("Index");
        }
    }
}
