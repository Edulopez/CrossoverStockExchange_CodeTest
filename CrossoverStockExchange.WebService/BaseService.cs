using System;
using System.Web;
using System.Web.UI;
using Microsoft.Practices.Unity;
using StructureMap;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Dal.Repositories.Concrete;
using CrossoverStockExchange.Core.Services.Abstract;
using System.Data.Entity;
using CrossoverStockExchange.Core.Services.Concrete;
namespace CrossoverStockExchange.WebService
{
    
    public class BaseService<T> : System.Web.Services.WebService where T : class
    {
        public BaseService()
        {
            InjectDependencies();
        }

        protected virtual void InjectDependencies()
        {
                //ObjectFactory.BuildUp()
                 ObjectFactory.Configure(cfg =>
                {
                    cfg.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<Dal.Context.StockExchangeDbContext>();
                   // cfg.For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
               
                    //cfg.For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
                    //cfg.For<IRoleStore<IdentityRole, string>>().Use<RoleStore<IdentityRole>>();
                    //cfg.For<ApplicationUserManager>().Use<ApplicationUserManager>();
                    cfg.For<IStockRepository>().Use<StockRepository>();
                    cfg.For<IStockExchangeService>().Use<StockExchangeService>();
                    cfg.For<IExceptionRepository>().Use<ExceptionRepository>();
                    cfg.For<IUserRepository>().Use<UserRepository>();
                    cfg.For<IUserService>().Use<UserService>();

                    ////ASP.NET Identity Classes
                    //cfg.For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
                    //cfg.For<IRoleStore<IdentityRole, string>>().Use<RoleStore<IdentityRole>>();
                    //cfg.For<ApplicationUserManager>().Use<ApplicationUserManager>();
                    //cfg.For<IIdentityMessageService>().Use<EmailService>();

             
                });
        }
    }
}