using System.Web;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Infrastructure.Tasks;
using CrossoverStockExchange.Core.Repositories.Abstract;
using StructureMap;

namespace CrossoverStockExchange.Core.Infrastructure.ErrorHandlers
{
    public class DatabaseErrorLogger : IRunOnError
    {
        public void Execute()
        {
            
        }
    }
}
