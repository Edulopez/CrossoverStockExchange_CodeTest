using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossoverStockExchange.Core.Entities
{
    public class Stock : Entity
    {
        [MinLength(3),MaxLength(100)]
        public string Code { get; set; }
        
        public int Price { get; set;}
        
        public List<ApplicationUser> Users { get; set; }

    }
}
