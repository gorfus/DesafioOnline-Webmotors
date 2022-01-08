using System.Threading.Tasks;

namespace WB.DesafioOnline.Anuncios.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}