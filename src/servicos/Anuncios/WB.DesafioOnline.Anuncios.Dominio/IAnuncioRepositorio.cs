using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WB.DesafioOnline.Anuncios.Core;

namespace WB.DesafioOnline.Anuncios.Dominio
{
    public interface IAnuncioRepositorio : IRepository<Anuncio>
    {
        DbConnection ObterConexao();

        void Cadastrar(Anuncio anuncio);
        void Atualizar(Anuncio anuncio);
        void Deletar(Anuncio anuncio);

        Task<Anuncio> PorId(int anuncioId);
        Task<IEnumerable<Anuncio>> Todos();
        Task<IEnumerable<Anuncio>> PorMarca(string marca);
        Task<IEnumerable<Anuncio>> PorModelo(string modelo);
        Task<IEnumerable<Anuncio>> PorVersao(string versao);
    }
}