using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Core;
using WB.DesafioOnline.Anuncios.Dominio;

namespace WB.DesafioOnline.Anuncios.Servicos.Commands
{
    public class AnuncioCommandHandler : RepositoryDMLHandler,
                                         IRequestHandler<AtivarAnuncioCommand, ValidationResult>,
                                         IRequestHandler<AtualizarAnuncioCommand, ValidationResult>,
                                         IRequestHandler<CadastrarAnuncioCommand, ValidationResult>,
                                         IRequestHandler<DesativarAnuncioCommand, ValidationResult>,
                                         IRequestHandler<DeletarAnuncioCommand, ValidationResult>
    {
        private readonly IAnuncioRepositorio _anuncioRepositorio;

        public AnuncioCommandHandler(IAnuncioRepositorio anuncioRepositorio)
        {
            _anuncioRepositorio = anuncioRepositorio;
        }

        public async Task<ValidationResult> Handle(CadastrarAnuncioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var anuncio = new Anuncio(marca: request.Marca,
                                      modelo: request.Modelo,
                                      versao: request.Versao,
                                      ano: request.Ano,
                                      quilometragem: request.Quilometragem,
                                      observacao: request.Observacao);

            _anuncioRepositorio.Cadastrar(anuncio);

            return await PersistirDados(_anuncioRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarAnuncioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var anuncio = await _anuncioRepositorio.PorId(request.AnuncioId);

            anuncio.Atualizar(marca: request.Marca,
                              modelo: request.Modelo,
                              versao: request.Versao,
                              ano: request.Ano,
                              quilometragem: request.Quilometragem,
                              observacao: request.Observacao);

            _anuncioRepositorio.Atualizar(anuncio);

            return await PersistirDados(_anuncioRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtivarAnuncioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var anuncio = await _anuncioRepositorio.PorId(request.AnuncioId);

            anuncio.Ativar();

            _anuncioRepositorio.Atualizar(anuncio);

            return await PersistirDados(_anuncioRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DesativarAnuncioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var anuncio = await _anuncioRepositorio.PorId(request.AnuncioId);

            anuncio.Desativar();

            _anuncioRepositorio.Atualizar(anuncio);

            return await PersistirDados(_anuncioRepositorio.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(DeletarAnuncioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var anuncio = await _anuncioRepositorio.PorId(request.AnuncioId);

            _anuncioRepositorio.Deletar(anuncio);

            return await PersistirDados(_anuncioRepositorio.UnitOfWork);
        }
    }
}