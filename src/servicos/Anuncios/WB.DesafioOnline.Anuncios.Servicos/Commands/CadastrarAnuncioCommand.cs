using FluentValidation;
using System;
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
                RuleFor(c => c.Marca)
                    .NotNull()
                    .WithMessage("o campo Marca é requerido.");

                RuleFor(c => c.Modelo)
                  .NotNull()
                  .WithMessage("o campo Modelo é requerido.");

                RuleFor(c => c.Versao)
                  .NotNull()
                  .WithMessage("o campo Versao é requerido.");

                RuleFor(c => c.Ano)
                 .GreaterThan(1886)
                 .LessThan(DateTime.Now.Year - 1)
                 .WithMessage("Ano inválido {0} {1}.");

                RuleFor(c => c.Quilometragem)
                    .GreaterThan(0)
                    .WithMessage("o campo Quilometragem deve ser preenchido com valor maior que 0.");

                RuleFor(c => c.Observacao)
                    .NotNull()
                    .WithMessage("o campo Observação é requerido.");
            }
        }
    }
}