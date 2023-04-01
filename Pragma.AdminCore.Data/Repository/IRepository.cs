using Pragma.AdminCore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pragma.AdminCore.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        T GetByRowId(Guid rowId);
        T GetFirst(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAvailable();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAvailable(Expression<Func<T, bool>> predicate);

        T Add(T entity);
        void AddMultiple(IEnumerable<T> entities);

        T Update(T entity);

        T DeleteById(int id);
        T DeleteByRowId(Guid rowId);
        T Delete(T entity);
        bool DeletePermanently(T entity);
        bool DeleteMultiplePermanently(IEnumerable<T> entities);

        int SaveChanges();
    }
}
