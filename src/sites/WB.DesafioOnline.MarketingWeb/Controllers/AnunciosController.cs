using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WB.DesafioOnline.MarketingWeb.Integracoes.Anuncios;
using WB.DesafioOnline.MarketingWeb.Models;

namespace WB.DesafioOnline.MarketingWeb.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnunciosServicos _anunciosServicos;

        public AnunciosController(IAnunciosServicos anunciosServicos)
        {
            _anunciosServicos = anunciosServicos;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var anuncios = await _anunciosServicos.Todos();
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
                await _anunciosServicos.Cadastrar(anuncio);
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int anuncioId)
        {
            return View(await _anunciosServicos.PorId(anuncioId));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AnuncioDTO anuncio)
        {
            try
            {
                await _anunciosServicos.Atualizar(anuncio);
            }
            catch (Exception ex)
            {
                throw;
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int anuncioId)
        {
            if (anuncioId == 0)
                throw new Exception("Necesário enviar o id do anuncio para exclusão");

            await _anunciosServicos.Remover(anuncioId);

            return View("Index");
        }
    }
}
