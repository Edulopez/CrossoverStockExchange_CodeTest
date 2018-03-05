using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Core.Services.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CrossoverStockExchange.Core.Services;
namespace CrossoverStockExchange.Dal.Repositories.Concrete
{
    public class UserRepository:  IUserRepository
    {
        private readonly ApplicationUserManager UserManager;
        private RoleManager<IdentityRole> RoleManager;
        protected DbContext Context;
        public UserRepository(DbContext dbContext, ApplicationUserManager userManager, RoleManager<IdentityRole> roleManager)
        {
            Context = dbContext;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationUser GetById(string id)
        {
            return UserManager.Users.Where(x => x.Id == id).Include( x=> x.UserStock).FirstOrDefault();
        }
        public void Update(ApplicationUser user)
        {
            UserManager.Update(user);
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Count(Func<ApplicationUser, bool> filter)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetById(int[] ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetLatests(int number)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetByFilter(int page, int count, Func<ApplicationUser, bool> filterBy)
        {
            throw new NotImplementedException();
        }
    }
}
