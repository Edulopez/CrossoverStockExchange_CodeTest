using System;
using System.Reflection;
using System.Web;
using CrossoverStockExchange.Core.Infrastructure.Tasks;
//using log4net;

namespace CrossoverStockExchange.Core.Infrastructure.ErrorHandlers
{
    public class ErrorLogger : IRunOnError
    {
        public void Execute()
        {
            HttpContext httpContext = HttpContext.Current;
            Exception exception = httpContext.ApplicationInstance.Server.GetLastError();
            
            //ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //log.Error("ERROR",exception);            
        }
    }
}
