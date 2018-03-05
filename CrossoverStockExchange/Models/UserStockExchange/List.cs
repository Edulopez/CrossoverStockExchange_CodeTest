using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrossoverStockExchange.Models.UserStockExchange
{
    public class List
    {
        public string UserName { get; set; }

        public List<Core.Entities.PlainStock> StockList { get; set; }
    }
}