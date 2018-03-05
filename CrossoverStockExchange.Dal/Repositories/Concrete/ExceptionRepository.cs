using System.Data.Entity;
using System.Linq;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Dal.Repositories.Concrete
{
    public class ExceptionRepository : WriteableRepository<Exception>, IExceptionRepository
    {
        public ExceptionRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
