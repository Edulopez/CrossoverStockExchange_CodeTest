namespace CrossoverStockExchange.Dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Core.Entities;
    public sealed class Configuration : DbMigrationsConfiguration<CrossoverStockExchange.Dal.Context.StockExchangeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CrossoverStockExchange.Dal.Context.StockExchangeDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CrossoverStockExchange.Dal.Context.StockExchangeDbContext context)
        {
            if (!context.Stocks.Any())
            {
                context.Stocks.AddOrUpdate(x => x.Code
                    , new Stock
                    {
                        Code = "AA1",
                        Price = new Random(123).Next(0, 10000)
                    }, new Stock
                    {
                        Code = "bb3",
                        Price = new Random(21).Next(0, 10000)
                    }, new Stock
                    {
                        Code = "QS1",
                        Price = new Random(7).Next(0, 10000)
                    }, new Stock
                    {
                        Code = "aA5",
                        Price = new Random(11).Next(0, 10000)
                    }
                    );
            }
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
