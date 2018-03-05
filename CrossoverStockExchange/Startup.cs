using System;
using System.Data.Entity;
using System.Security.Claims;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Services.Concrete;
using CrossoverStockExchange.Dal.Context;
using CrossoverStockExchange.Dal.Repositories.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;
using StructureMap;


[assembly: OwinStartupAttribute(typeof(CrossoverStockExchange.Startup))]
namespace CrossoverStockExchange
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IDataProtectionProvider>().Use(app.GetDataProtectionProvider);
            });
            ConfigureAuth(app);
        }
    }
}
