using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossoverStockExchange.Core.Entities
{
    [Serializable]
    public class PlainStock
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
    }
}
