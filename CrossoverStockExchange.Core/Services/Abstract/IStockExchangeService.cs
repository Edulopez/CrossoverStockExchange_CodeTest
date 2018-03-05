using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Core.Services.Abstract
{
    public interface IStockExchangeService
    {
        List<Stock> GetStock(List<string> stockCodesList);

        Stock FindByCode(string code);

        bool AddStockToUserList(int id, string userId);
        
        List<Stock> GetAll();

        bool RemoveStockExchangeFromUser(int stockId, string userId);
    }
}
