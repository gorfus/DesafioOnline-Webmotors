using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Core;
using WB.DesafioOnline.Anuncios.Dominio;
using WB.DesafioOnline.Anuncios.Servicos.Commands;

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
        public async Task<IActionResult> Atualizar(AtualizarAnuncioCommand request)
        {
            return Ok(await _mediator.EnviarComando(request));
        }

        [HttpDelete("{anuncioId}")]
        public async Task<IActionResult> Deletar(DeletarAnuncioCommand request)
        {
            return Ok(await _mediator.EnviarComando(request));
        }


        [HttpGet("{anuncioId}")]
        public async Task<IActionResult> PorId(int anuncioId)
        {
            return Ok(await _anuncioRepositorio.PorId(anuncioId));
        }

        [HttpPut("Ativar/{anuncioId}")]
        public async Task<IActionResult> Ativar(AtivarAnuncioCommand request)
        {
            return Ok(await _mediator.EnviarComando(request));
        }

        [HttpPut("Destivar/{anuncioId}")]
        public async Task<IActionResult> Desativar(DesativarAnuncioCommand request)
        {
            return Ok(await _mediator.EnviarComando(request));
        }

        [HttpGet]
        public async Task<IActionResult> Todos()
        {
            return Ok(await _anuncioRepositorio.Todos());
        }

    }
}
