using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Core;
using WB.DesafioOnline.Anuncios.Dominio;
using WB.DesafioOnline.Anuncios.Servicos.Commands;
using WB.DesafioOnline.Anuncios.Servicos.DTOs;

namespace WB.DesafioOnline.Anuncios.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnunciosController : ControllerBase
    {
        private readonly ILogger<AnunciosController> _logger;
        private readonly IMediatorHandler _mediator;
        private readonly IAnuncioRepositorio _anuncioRepositorio;

        public AnunciosController(ILogger<AnunciosController> logger,
                                  IMediatorHandler mediator, IAnuncioRepositorio anuncioRepositorio)
        {
            _logger = logger;
            _mediator = mediator;
            _anuncioRepositorio = anuncioRepositorio;
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarAnuncioCommand request)
        {
            try
            {
                _logger.LogInformation($"Mensagem recebida: {request}");
                await _mediator.EnviarComando(request);
                _logger.LogInformation($"Mensagem processada.");

                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogCritical("");
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody]AtualizarAnuncioCommand request)
        {
            return Ok(await _mediator.EnviarComando(request));
        }

        [HttpDelete("{anuncioId}")]
        public async Task<IActionResult> Deletar(int anuncioId)
        {
 
            return Ok(await _mediator.EnviarComando(new DeletarAnuncioCommand { AnuncioId = anuncioId }));
        }


        [HttpGet("{anuncioId}")]
        public async Task<IActionResult> PorId(int anuncioId)
        {
            return Ok(await _anuncioRepositorio.PorId(anuncioId));
        }

        [HttpPut("ativar/{anuncioId}")]
        public async Task<IActionResult> Ativar(AtivarAnuncioCommand request)
        {
            return Ok(await _mediator.EnviarComando(request));
        }

        [HttpPut("destivar/{anuncioId}")]
        public async Task<IActionResult> Desativar(DesativarAnuncioCommand request)
        {
            return Ok(await _mediator.EnviarComando(request));
        }

        [HttpGet]
        public async Task<IActionResult> Todos()
        {
            var result = await _anuncioRepositorio.Todos();
            return Ok(result);
        }

        [HttpPost("filtrar")]
        public async Task<IActionResult> Pesquisar(AnuncioFiltroDTO filtro)
        {
            var result = await _anuncioRepositorio.Pesquisar(filtro.Marca, filtro.Modelo, filtro.Versao, 1, 15);
            return Ok(result);
        }
    }
}
