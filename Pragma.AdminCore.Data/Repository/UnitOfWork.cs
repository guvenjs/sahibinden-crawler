using System;
using Pragma.AdminCore.Data.Models;

namespace Pragma.AdminCore.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;

        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(Context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Context != null)
                {
                    Context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
