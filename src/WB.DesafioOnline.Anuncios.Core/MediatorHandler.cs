using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace WB.DesafioOnline.Anuncios.Core
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        //public async Task PublicarEvento<T>(T evento) where T : Event
        //{
        //    await _mediator.Publish(evento);
        //}


        //public async Task PublicarQuery<T>(T query) where T : Query
        //{
        //    await _mediator.Publish(query);
        //}
    }
}