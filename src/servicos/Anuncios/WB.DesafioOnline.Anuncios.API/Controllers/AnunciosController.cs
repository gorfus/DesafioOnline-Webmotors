using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.API.Commands;
using WB.DesafioOnline.Anuncios.Core;

namespace WB.DesafioOnline.Anuncios.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnunciosController : ControllerBase
    {
        private readonly ILogger<AnunciosController> _logger;
        private readonly IMediatorHandler _mediator;

        public AnunciosController(ILogger<AnunciosController> logger, 
                                  IMediatorHandler mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("pedido")]
        public async Task<IActionResult> Cadastrar(CadastrarAnuncioCommand pedido)
        {
            return Ok(await _mediator.EnviarComando(pedido));
        }


        [HttpPost("pedido")]
        public async Task<IActionResult> Atualizar(AtualizarAnuncioCommand pedido)
        {
            return Ok(await _mediator.EnviarComando(pedido));
        }
    }
}
