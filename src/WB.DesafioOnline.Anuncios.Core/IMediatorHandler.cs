using FluentValidation.Results;
using System.Threading.Tasks;

namespace WB.DesafioOnline.Anuncios.Core
{
    public interface IMediatorHandler
    {
        //Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}