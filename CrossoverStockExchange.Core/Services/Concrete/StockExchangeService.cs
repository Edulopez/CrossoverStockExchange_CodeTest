using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Core.Services.Abstract;
using StructureMap;
using System.Web;
using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Core.Services.Concrete
{
   public class StockExchangeService : IStockExchangeService
   {
       private readonly IStockRepository stockRepository;
       private readonly IUserRepository userRepository;

        public StockExchangeService(IStockRepository stockRepository, IUserRepository userRepository)
        {
            this.stockRepository = stockRepository;
            this.userRepository = userRepository;
        }

        public List<Entities.Stock> GetStock(List<string> stockCodesList)
        {
            return stockRepository.GetByCodes(stockCodesList);
        }


        public Entities.Stock FindByCode(string code)
        {
            return stockRepository.FindByCode(code);
        }


        public List<Entities.Stock> GetAll()
        {
            return stockRepository.GetAll().ToList();
        }


       public bool UserContainStock(Stock stock, ApplicationUser user)  
        {
            if (user == null || stock == null || user.UserStock == null) return true ;

            return user.UserStock.Contains(stock);

           
        }
        public bool AddStockToUserList(int id, string userId)
        {
            ApplicationUser user = userRepository.GetById(userId);
            Stock stock = stockRepository.GetById(id);
            if (UserContainStock(stock, user)) return true;
            user.UserStock.Add(stock);
            userRepository.Update(user);
            return true;
        }


        public bool RemoveStockExchangeFromUser(int stockId, string userId)
        {
            ApplicationUser user = userRepository.GetById(userId);
            Stock stock = stockRepository.GetById(stockId);
            if (!UserContainStock(stock, user)) return false;
            user.UserStock.Remove(stock);
            userRepository.Update(user);
            return true;
        }
   }
}
