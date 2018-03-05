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
    public class UserStockExchangeController : Controller
    {
        private readonly IStockExchangeService stockExchangeService;
        private readonly IUserService userService;

        public UserStockExchangeController(IStockExchangeService stockExchangeService, IUserService userService)
        {
            this.userService = userService;
            this.stockExchangeService = stockExchangeService;
        }

        // GET: UserStockExchange
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            StockExchangeWebService.StockExchangeWebService ws = new StockExchangeWebService.StockExchangeWebService();

            var user = userService.GetById(User.Identity.GetUserId());
            var Codes = user.UserStock.Select(x => x.Code).ToList();

            var res = ws.GetAllStockByCodeList(Codes.ToArray());
            
            Models.UserStockExchange.List model = new Models.UserStockExchange.List();
            model.UserName = user.UserName;
            model.StockList = Helper.StockExchangeHelper.ConvertToPlainStock(res);
            return View(model);
        }
      

        public ActionResult remove(int id)
        {
           bool res = stockExchangeService.RemoveStockExchangeFromUser(id, User.Identity.GetUserId());
            //add feedback
           return RedirectToAction("List");
        }
    }
}