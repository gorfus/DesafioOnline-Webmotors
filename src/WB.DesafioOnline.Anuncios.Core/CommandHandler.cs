using FluentValidation.Results;
using System.Threading.Tasks;

namespace WB.DesafioOnline.Anuncios.Core
{
    public  class RepositoryDMLHandler
    {
        public ValidationResult ValidationResult;

        public RepositoryDMLHandler()
        {
            ValidationResult = new ValidationResult();
        }

        public void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        public async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) 
                AdicionarErro("Ocorreu um erro na requisição ao banco de dados");

            return ValidationResult;
        }
    }
}
