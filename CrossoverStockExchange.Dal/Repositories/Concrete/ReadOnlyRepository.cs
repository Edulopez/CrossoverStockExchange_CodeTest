using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Repositories.Abstract;

namespace CrossoverStockExchange.Dal.Repositories.Concrete
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : Entity
    {
        protected DbContext Context;
        protected DbSet<T> EntitySet;
        public ReadOnlyRepository(DbContext dbContext)
        {
            Context = dbContext;
            EntitySet = Context.Set<T>();
        }
        public IQueryable<T> GetAllQueryable()
        {
            var r = EntitySet.Where(x => x.IsActive);
            return r;
        }
        public IEnumerable<T> GetAll()
        {
            var r = EntitySet.Where(x => x.IsActive);
            return r;
        }
        public int Count()
        {
            return EntitySet.Count(x => x.IsActive == true);
        }
        public int Count(Func<T, bool> filter)
        {
            return EntitySet.Count(filter);
        }

        public T GetById(int id)
        {
            return EntitySet.FirstOrDefault(x => x.Id == id && x.IsActive);
        }
        public IEnumerable<T> GetById(int[] ids)
        {
            return EntitySet.Where(x => ids.Contains(x.Id) && x.IsActive).ToList();
        }

        public IEnumerable<T> GetLatests(int number)
        {
            var r = EntitySet.Where(x => x.IsActive).Take(number).ToList();
            return r;
        }

        public IEnumerable<T> GetByFilter(int page, int count, Func<T, bool> filterBy)
        {
            return this.GetAll().Where(filterBy).Skip(page * count).Take(count);
        }
    }
}
