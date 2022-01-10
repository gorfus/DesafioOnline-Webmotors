using FluentValidation;
using WB.DesafioOnline.Anuncios.Core;

namespace WB.DesafioOnline.Anuncios.Servicos.Commands
{
    public class AtivarAnuncioCommand : Command
    {
        public int AnuncioId { get; set; }
     
        public override bool EhValido()
        {
            ValidationResult = new AtivarAnuncioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtivarAnuncioCommandValidation : AbstractValidator<AtivarAnuncioCommand>
        {
            public AtivarAnuncioCommandValidation()
            {
                RuleFor(c => c.AnuncioId)
                    .NotEqual(0)
                    .NotNull()
                    .WithMessage("Id inválido");
            }
        }
    }
}