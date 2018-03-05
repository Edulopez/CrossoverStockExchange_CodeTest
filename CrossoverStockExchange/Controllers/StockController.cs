using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossoverStockExchange.Core.Services.Abstract;
using CrossoverStockExchange.Core.Services.Concrete;
using CrossoverStockExchange.Core.Entities;
using Microsoft.AspNet.Identity;
namespace CrossoverStockExchange.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly IStockExchangeService stockExchangeService;
        public StockController(IStockExchangeService stockExchangeService)
        {
            this.stockExchangeService = stockExchangeService;
        }
        // GET: Stock
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            StockExchangeWebService.StockExchangeWebService ws = new StockExchangeWebService.StockExchangeWebService();
            var res = ws.GetAllStock();
            return View(Helper.StockExchangeHelper.ConvertToPlainStock(res));
        }
        public ActionResult Details(string Code)
        {

            return View();
        }
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(Models.StockViewModels.Find stockFinder)
        {
            if (ModelState.IsValid)
            {
                stockFinder.stock = stockExchangeService.FindByCode(stockFinder.Code);
            }
            return View(stockFinder);
        }

        public ActionResult Add(int id)
        {
            stockExchangeService.AddStockToUserList(id, User.Identity.GetUserId());
            // add feedback
            return RedirectToAction("List");
        }
    }
}
