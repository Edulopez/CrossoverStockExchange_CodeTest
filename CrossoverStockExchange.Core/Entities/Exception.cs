using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossoverStockExchange.Core.Entities
{
    public class Exception : Entity, IEntity
    {
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string InnerException { get; set; }
    }
}
