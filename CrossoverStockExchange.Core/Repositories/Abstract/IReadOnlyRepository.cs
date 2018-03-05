using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossoverStockExchange.Core.Repositories.Abstract
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        int Count(Func<T, bool> filter);
        int Count();
        T GetById(int id);
        IEnumerable<T> GetById(int[] ids);
        IEnumerable<T> GetLatests(int number);
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> GetByFilter(int page, int count, Func<T, bool> filterBy);
    }
}
