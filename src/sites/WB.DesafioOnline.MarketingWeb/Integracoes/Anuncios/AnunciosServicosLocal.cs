using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Dominio;
using WB.DesafioOnline.MarketingWeb.Models;

namespace WB.DesafioOnline.MarketingWeb.Integracoes.Anuncios
{
    public interface IAnunciosServicosLocal
    {
        Task Adicionar(AnuncioDTO anuncio);
        Task Atualizar(Anuncio anuncio);
        Task Remover(Anuncio anuncio);

        Task<Anuncio> PorId(int anuncioId);
        Task<IEnumerable<Anuncio>> Todos();
        Task<IEnumerable<Anuncio>> PorMarca(string marca);
        Task<IEnumerable<Anuncio>> PorModelo(string modelo);
        Task<IEnumerable<Anuncio>> PorVersao(string versao);
    }

    public class AnunciosServicosLocal : IAnunciosServicosLocal
    {
        private readonly IAnuncioRepositorio _anuncioRepositorio;

        public AnunciosServicosLocal(IAnuncioRepositorio anuncioRepositorio)
        {
            _anuncioRepositorio = anuncioRepositorio;
        }

        public async Task Adicionar(AnuncioDTO anuncio)
        {
            _anuncioRepositorio.Adicionar(new Anuncio (anuncio.Marca, 
                                                       anuncio.Modelo, 
                                                       anuncio.Versao, 
                                                       anuncio.Ano,
                                                       anuncio.Quilometragem,
                                                       anuncio.Observacao));

            await _anuncioRepositorio.UnitOfWork.Commit();
        }

        public async Task Atualizar(Anuncio anuncio)
        {
            _anuncioRepositorio.Atualizar(anuncio);

            await _anuncioRepositorio.UnitOfWork.Commit();
        }

        public async Task  Remover(Anuncio anuncio)
        {
            _anuncioRepositorio.Remover(anuncio);

            await _anuncioRepositorio.UnitOfWork.Commit();
        }

        public async Task<Anuncio> PorId(int anuncioId)
        {
            return await _anuncioRepositorio.PorId(anuncioId);
        }

        public async Task<IEnumerable<Anuncio>> Todos()
        {
            return await _anuncioRepositorio.Todos();
        }

        public async Task<IEnumerable<Anuncio>> PorMarca(string marca)
        {
            return await _anuncioRepositorio.PorMarca(marca);
        }

        public async Task<IEnumerable<Anuncio>> PorModelo(string modelo)
        {
            return await _anuncioRepositorio.PorMarca(modelo);
        }

        public async Task<IEnumerable<Anuncio>> PorVersao(string versao)
        {
            return await _anuncioRepositorio.PorVersao(versao);
        }
    }
}
