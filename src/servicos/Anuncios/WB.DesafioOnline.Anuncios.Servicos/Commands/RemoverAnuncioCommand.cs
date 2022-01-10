using FluentValidation;
using WB.DesafioOnline.Anuncios.Core;

namespace WB.DesafioOnline.Anuncios.Servicos.Commands
{
    public class DeletarAnuncioCommand : Command
    {
        public int AnuncioId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new DeletarAnuncioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DeletarAnuncioCommandValidation : AbstractValidator<DeletarAnuncioCommand>
        {
            public DeletarAnuncioCommandValidation()
            {
                RuleFor(c => c.AnuncioId)
                    .NotEqual(0)
                    .NotNull()
                    .WithMessage("Id inválido");
            }
        }
    }
}