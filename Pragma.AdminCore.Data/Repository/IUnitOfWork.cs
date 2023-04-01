using Pragma.AdminCore.Data.Models;
using System;

namespace Pragma.AdminCore.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
