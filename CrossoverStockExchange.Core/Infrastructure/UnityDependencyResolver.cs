using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CrossoverStockExchange.Core.Infrastructure
{
    class UnityDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
