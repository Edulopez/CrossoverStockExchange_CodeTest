using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Core.Repositories.Abstract
{
    public interface IUserRepository : IReadOnlyRepository<ApplicationUser>
    {
        ApplicationUser GetById(string id);

        void Update(ApplicationUser user);
    }
}
