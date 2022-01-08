using System;

namespace WB.DesafioOnline.Anuncios.Core
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}