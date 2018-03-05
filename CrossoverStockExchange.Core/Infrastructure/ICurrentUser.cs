using CrossoverStockExchange.Core.Entities;

namespace CrossoverStockExchange.Core.Infrastructure
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; }
    }
}
