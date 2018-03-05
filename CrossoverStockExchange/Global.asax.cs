using System;
using System.Data.Entity;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Infrastructure;
using CrossoverStockExchange.Core.Infrastructure.ModelMetadata;
using CrossoverStockExchange.Core.Infrastructure.Tasks;
using CrossoverStockExchange.Core.Services.Abstract;
using CrossoverStockExchange.Core.Services.Concrete;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Dal.Context;
using CrossoverStockExchange.Dal.Migrations;
using CrossoverStockExchange.Dal.Repositories.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;    
using Microsoft.Owin.Security;
using StructureMap;


namespace CrossoverStockExchange
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container
        {
            get
            {
                return (IContainer)HttpContext.Current.Items["_Container"];
            }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StockExchangeDbContext, Configuration>());
           
            DependencyResolver.SetResolver(
                new StructureMapDependencyResolver(() => Container ?? ObjectFactory.Container));

            ObjectFactory.Configure(cfg =>
            {
                cfg.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<StockExchangeDbContext>();
                cfg.For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
               
                cfg.For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
                cfg.For<IRoleStore<IdentityRole, string>>().Use<RoleStore<IdentityRole>>();
                cfg.For<ApplicationUserManager>().Use<ApplicationUserManager>();
                cfg.For<IStockRepository>().Use<StockRepository>();
                cfg.For<IStockExchangeService>().Use<StockExchangeService>();
                cfg.For<IExceptionRepository>().Use<ExceptionRepository>();
                cfg.For<IUserRepository>().Use<UserRepository>();
                cfg.For<IUserService>().Use<UserService>();

                //ASP.NET Identity Classes
                cfg.For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
                cfg.For<IRoleStore<IdentityRole, string>>().Use<RoleStore<IdentityRole>>();
                cfg.For<ApplicationUserManager>().Use<ApplicationUserManager>();
                cfg.For<IIdentityMessageService>().Use<EmailService>();

                cfg.AddRegistry(new StandardRegistry());
                cfg.AddRegistry(new ControllerRegistry());
                cfg.AddRegistry(new ActionFilterRegistry(
                    () => Container ?? ObjectFactory.Container));
                cfg.AddRegistry(new MvcRegistry());
                cfg.AddRegistry(new TaskRegistry());
                cfg.AddRegistry(new ModelMetadataRegistry());
            });

            using (var container = ObjectFactory.Container.GetNestedContainer())
            {
                foreach (var task in container.GetAllInstances<IRunAtInit>())
                {
                    task.Execute();
                }

                foreach (var task in container.GetAllInstances<IRunAtStartup>())
                {
                    task.Execute();
                }
            }
        }


        public void Application_BeginRequest()
        {
            Container = ObjectFactory.Container.GetNestedContainer();

            foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (var task in Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

        public void Application_EndRequest()
        {
            try
            {
                foreach (var task in
                    Container.GetAllInstances<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            finally
            {
                Container.Dispose();
                Container = null;
            }
        }
    }
}
