using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using StructureMap;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Dal.Repositories.Concrete;
using CrossoverStockExchange.Core.Services.Abstract;
using System.Data.Entity;
using CrossoverStockExchange.Core.Services.Concrete;
namespace CrossoverStockExchange.WebService
{
    public class Global : System.Web.HttpApplication, IContainerAccessor
    {
        public Global()
        {


        }
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        IUnityContainer IContainerAccessor.Container
        {
            get
            {
                return Container;
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            CreateContainer();
        }

        
        protected virtual void CreateContainer()
        {//ObjectFactory.BuildUp()

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
            IUnityContainer container = new UnityContainer();
            container.RegisterType<Core.Services.Abstract.IStockExchangeService, Core.Services.Concrete.StockExchangeService>();
            container.RegisterType<Core.Repositories.Abstract.IStockRepository, Dal.Repositories.Concrete.StockRepository>();

            //container.RegisterType< Dal.Context.StockExchangeDbContext>();
             container.RegisterType<Core.Repositories.Abstract.IStockRepository, Dal.Repositories.Concrete.StockRepository>();
             container.RegisterType<Core.Repositories.Abstract.IStockRepository, Dal.Repositories.Concrete.StockRepository>();
              //cfg.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<StockExchangeDbContext>();
               // cfg.For<IStockExchangeService>().Use<StockExchangeService>();
            Container = container;
        }
        
        

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}