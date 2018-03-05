using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossoverStockExchange.Core.Repositories.Abstract
{
    public interface IWriteableRepository<T> : IReadOnlyRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void Remove(T entity);
    }
}
