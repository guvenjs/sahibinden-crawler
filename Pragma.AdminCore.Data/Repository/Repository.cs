using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pragma.AdminCore.Data.Models;

namespace Pragma.AdminCore.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        public DbSet<T> Table { get; set; }

        public Repository(ApplicationDbContext dbContext)
        {
            context = dbContext;
            Table = context.Set<T>();
        }

        public T Add(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;

            var item = Table.Add(entity);
            int result = SaveChanges();

            if (result > 0)
            {
                return item.Entity;
            }

            return null;
        }

        public void AddMultiple(IEnumerable<T> entities)
        {
            IEnumerable<T> items = entities.Select(e =>
            {
                e.DateCreated = DateTime.UtcNow;
                return e;
            }).ToList();

            Table.AddRange(items);

            SaveChanges();
        }

        public T Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DateDeleted = DateTime.UtcNow;

            return Update(entity);
        }

        public T DeleteById(int id)
        {
            T entityToDelete = GetById(id);

            if (entityToDelete != null)
            {
                return Delete(entityToDelete);
            }

            return null;
        }

        public T DeleteByRowId(Guid rowId)
        {
            T entityToDelete = GetByRowId(rowId);

            if (entityToDelete != null)
            {
                return Delete(entityToDelete);
            }

            return null;
        }

        public bool DeleteMultiplePermanently(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
            return SaveChanges() > 0;
        }

        public bool DeletePermanently(T entity)
        {
            Table.Remove(entity);
            return SaveChanges() > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public IQueryable<T> GetAvailable()
        {
            return Table.Where(x => x.IsDeleted == false);
        }

        public IQueryable<T> GetAvailable(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(x => x.IsDeleted == false).Where(predicate);
        }

        public T GetById(int id)
        {
            return Table.FirstOrDefault(x => x.Id == id);
        }

        public T GetByRowId(Guid rowId)
        {
            return Table.FirstOrDefault(x => x.RowId == rowId);
        }

        public T GetFirst(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public T Update(T entity)
        {
            entity.DateUpdated = DateTime.UtcNow;

            var item = Table.Update(entity);
            int result = SaveChanges();

            if (result > 0)
            {
                return item.Entity;
            }

            return null;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
