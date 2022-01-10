using FluentValidation;
using WB.DesafioOnline.Anuncios.Core;

namespace WB.DesafioOnline.Anuncios.Servicos.Commands
{
    public class DesativarAnuncioCommand : Command
    {
        public int AnuncioId { get; set; }


        public override bool EhValido()
        {
            ValidationResult = new DesativarAnuncioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DesativarAnuncioCommandValidation : AbstractValidator<DesativarAnuncioCommand>
        {
            public DesativarAnuncioCommandValidation()
            {
                RuleFor(c => c.AnuncioId)
                       .NotEqual(0)
                       .NotNull()
                       .WithMessage("Id inválido");
            }
        }
    }
}