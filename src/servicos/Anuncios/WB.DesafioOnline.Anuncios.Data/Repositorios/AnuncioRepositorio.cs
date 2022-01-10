using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Core;
using WB.DesafioOnline.Anuncios.Dominio;

namespace WB.DesafioOnline.Anuncios.Data.Repositorios
{
    public class AnuncioRepositorio : RepositoryDMLHandler, IAnuncioRepositorio
    {
        private readonly AnunciosContext _context;

        public AnuncioRepositorio(AnunciosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public void Cadastrar(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
        }

        public void Atualizar(Anuncio anuncio)
        {
            _context.Anuncios.Update(anuncio);
        }

        public void Deletar(Anuncio anuncio)
        {
            _context.Anuncios.Remove(anuncio);
        }

        public async Task<Anuncio> PorId(int anuncioId)
        {
            return await _context.Anuncios
                                 .FirstOrDefaultAsync(a => a.Id == anuncioId);
        }

        public async Task<IEnumerable<Anuncio>> PorMarca(string marca)
        {
            return await _context.Anuncios
                                 .Where(a => a.Marca == marca)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Anuncio>> PorModelo(string modelo)
        {
            return await _context.Anuncios
                                 .Where(a => a.Modelo == modelo)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Anuncio>> PorVersao(string versao)
        {
            return await _context.Anuncios
                                 .Where(a => a.Versao == versao)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Anuncio>> Todos()
        {
            return await _context.Anuncios
                                 .ToListAsync();
        }

    }
}
