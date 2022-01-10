using FluentValidation;
using WB.DesafioOnline.Anuncios.Core;

namespace WB.DesafioOnline.Anuncios.Servicos.Commands
{
    public class CadastrarAnuncioCommand : Command
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarAnuncioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CadastrarAnuncioCommandValidation : AbstractValidator<CadastrarAnuncioCommand>
        {
            public CadastrarAnuncioCommandValidation()
            {
                //RuleFor(c => c.ClienteId)
                //    .NotEqual(Guid.Empty)
                //    .WithMessage("Id do cliente inválido");

                //RuleFor(c => c.PedidoItems.Count)
                //    .GreaterThan(0)
                //    .WithMessage("O pedido precisa ter no mínimo 1 item");

                //RuleFor(c => c.ValorTotal)
                //    .GreaterThan(0)
                //    .WithMessage("Valor do pedido inválido");

                //RuleFor(c => c.NumeroCartao)
                //    .CreditCard()
                //    .WithMessage("Número de cartão inválido");

                //RuleFor(c => c.NomeCartao)
                //    .NotNull()
                //    .WithMessage("Nome do portador do cartão requerido.");

                //RuleFor(c => c.CvvCartao.Length)
                //    .GreaterThan(2)
                //    .LessThan(5)
                //    .WithMessage("O CVV do cartão precisa ter 3 ou 4 números.");

                //RuleFor(c => c.ExpiracaoCartao)
                //    .NotNull()
                //    .WithMessage("Data expiração do cartão requerida.");
            }
        }
    }
}