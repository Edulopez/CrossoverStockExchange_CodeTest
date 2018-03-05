﻿using System.Data.Entity;
﻿using Microsoft.AspNet.Identity.EntityFramework;
using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Dal.Context
{
    public class StockExchangeDbContext : IdentityDbContext<ApplicationUser>
    {
        public StockExchangeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Exception> Exceptions { get; set; }
        public static StockExchangeDbContext Create()
        {
            return new StockExchangeDbContext();
        }
    }
}
