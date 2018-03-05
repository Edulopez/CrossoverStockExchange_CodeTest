using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CrossoverStockExchange.Core.Entities;
using CrossoverStockExchange.Core.Services.Abstract;
using CrossoverStockExchange.Core.Services.Concrete;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Dal.Repositories.Concrete;
using Microsoft.Practices;
using Microsoft.Practices.Unity;
using StructureMap;
using StructureMap.Attributes;
namespace CrossoverStockExchange.WebService
{
    //http://stackoverflow.com/questions/10861568/asmx-web-service-basic-authentication
    /// <summary>
    /// Summary description for StockExchangeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StockExchangeWebService : System.Web.Services.WebService //.Web.Services.WebService
    {

        private IStockRepository stockRepository
        {
            get;
            set;
        }

        public StockExchangeWebService()
        {
            var dbContext = new Dal.Context.StockExchangeDbContext();
            stockRepository = new Dal.Repositories.Concrete.StockRepository(dbContext);
        }

        private List<PlainStock> ConvertToPlainStock(List<Stock> stockList)
        {
            List<PlainStock> L = new List<PlainStock>();

            if (stockList != null)
            {
                for (int i = 0; i < stockList.Count; i++)
                    L.Add(new PlainStock()
                    {
                        Code = stockList[i].Code,
                        Price = stockList[i].Price,
                        Id = stockList[i].Id
                    });
            }
            return L;
        }
        [WebMethod]
        public List<PlainStock> GetAllStock()
        {
            var res = stockRepository.GetAll().ToList();
            return ConvertToPlainStock(res);
        }
        [WebMethod]
        public List<PlainStock> GetAllStockByCodeList(string[] stockCodes)
        {
            var res = stockRepository.GetByCodes(stockCodes.ToList()).ToList();
            return ConvertToPlainStock(res);
        }

        [WebMethod]
        public List<PlainStock> GetAllStockByUserId(string userId)
        {
            var res = stockRepository.GetByUserId(userId); ;
            return ConvertToPlainStock(res);
        }


    }
}
