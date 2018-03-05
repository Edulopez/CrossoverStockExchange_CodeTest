using System.Data.Entity;
using System.Security.Principal;
using CrossoverStockExchange.Core.Entities;
using Microsoft.AspNet.Identity;

namespace CrossoverStockExchange.Core.Infrastructure
{

    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly DbContext _context;

        private ApplicationUser _user;

        public CurrentUser(IIdentity identity, DbContext context)
        {
            _identity = identity;
            _context = context;
        }

        public ApplicationUser User
        {
            get { return _user ?? (_user = _context.Set<ApplicationUser>().Find(_identity.GetUserId())); }
        }
    }
}
