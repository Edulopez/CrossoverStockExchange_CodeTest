using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Helper
{
    public class StockExchangeHelper
    {
        public static   List<PlainStock> ConvertToPlainStock( StockExchangeWebService.PlainStock[] stockArray )
        {
            List<PlainStock> L = new List<PlainStock>();
            foreach (StockExchangeWebService.PlainStock stock in stockArray)
            {
                L.Add(new PlainStock()
                {
                    Id = stock.Id,
                    Code = stock.Code,
                    Price = stock.Price
                });
            }
            return L;
        }
    }
}