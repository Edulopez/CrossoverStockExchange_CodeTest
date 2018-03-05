using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Core.Repositories.Abstract
{
    public interface IStockRepository: IWriteableRepository<CrossoverStockExchange.Core.Entities.Stock>
    {
        List<Entities.Stock> GetByCodes(List<string> StockCodesList);
        List<Entities.Stock> GetByUserId(string UserId);

        Entities.Stock FindByCode(string code);

        bool UserHasStock(int stockId, ApplicationUser user);

    }
}
