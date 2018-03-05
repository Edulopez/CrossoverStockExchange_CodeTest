using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Repositories.Abstract;


namespace CrossoverStockExchange.Dal.Repositories.Concrete
{
    public class WriteableRepository<T> : ReadOnlyRepository<T>, IWriteableRepository<T> where T : Entity
    {
        public WriteableRepository(DbContext dbContext) : base(dbContext) { }
        public void Add(T entity)
        {
            EntitySet.Add(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            var e = EntitySet.Find(entity.Id);
            Context.Entry(e).CurrentValues.SetValues(entity);
            Context.Entry(e).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public void Remove(int id)
        {
            var entity = EntitySet.Find(id);
            Remove(entity);
        }
        public void Remove(T entity)
        {
            var iEntity = ((IEntity)entity);
            iEntity.IsActive = false;
            Context.Entry(iEntity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
