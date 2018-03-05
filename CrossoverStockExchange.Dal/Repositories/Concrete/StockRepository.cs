using System.Data.Entity;
using System.Linq;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Core.Entities;
using System;
using System.Collections.Generic;
namespace CrossoverStockExchange.Dal.Repositories.Concrete
{
    public class StockRepository: WriteableRepository<Stock>, IStockRepository 
    {
        private static DateTime currentTime;
        private static DateTime LastTimeSaved = new DateTime(2000,1,1);
        public StockRepository(DbContext dbContext) : base(dbContext) {
            currentTime = DateTime.Now;
        }
       
        /// <summary>
        /// Method to recalculate the prices of the stocks every 10s
        /// </summary>
        private void UpdateAllPrices()
        {
            if ((currentTime - LastTimeSaved).TotalSeconds > 10)
            {
                LastTimeSaved = DateTime.Now;
                var res = GetAllQueryable().ToList();
                foreach(var x in res)
                {
                    x.Price = new Random((int)((DateTime.Now.Ticks  ) % int.MaxValue)).Next(1000);
                    Update(x);
                }
              
            }
        }

        public new IEnumerable<Stock> GetAll()
        {
            UpdateAllPrices();
            var r = EntitySet.Where(x => x.IsActive);
            return r.ToList();
        }
        public System.Collections.Generic.List<Stock> GetByCodes(System.Collections.Generic.List<string> StockCodesList)
        {
            UpdateAllPrices();
            return EntitySet.Where(x => StockCodesList.Contains(x.Code)).ToList();
        }


        public Stock FindByCode(string code)
        {
            return EntitySet.Where(x => x.Code == code).FirstOrDefault();
        }


        public bool UserHasStock(int stockId, ApplicationUser user)
        {
            return EntitySet.Where(x => x.Id == stockId && x.Users.Contains(user)).FirstOrDefault() != null;
        }

        public List<Stock> GetByUserId(string UserId)
        {
            return EntitySet.Where(x => x.Users.Select(y => y.Id).Contains(UserId)).ToList();
        }
    }
}
