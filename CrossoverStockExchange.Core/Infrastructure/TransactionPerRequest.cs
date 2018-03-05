using System.Data;
using System.Data.Entity;
using System.Web;
using CrossoverStockExchange.Core.Infrastructure.Tasks;

namespace CrossoverStockExchange.Core.Infrastructure
{
	public class TransactionPerRequest :
		IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
	{
		private readonly DbContext _dbContext;
		private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(DbContext dbContext,
			HttpContextBase httpContext)
		{
			_dbContext = dbContext;
			_httpContext = httpContext;
		}

		void IRunOnEachRequest.Execute()
		{
			_httpContext.Items["_Transaction"] =
				_dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		void IRunOnError.Execute()
		{
			_httpContext.Items["_Error"] = true;
		}

		void IRunAfterEachRequest.Execute()
		{
			var transaction = (DbContextTransaction) _httpContext.Items["_Transaction"];

			if (_httpContext.Items["_Error"] != null)
			{
                transaction.Rollback();
                _dbContext.Database.Connection.Close();
			}
			else
			{
				transaction.Commit();
                _dbContext.Database.Connection.Close();
			}
		}
	}
}