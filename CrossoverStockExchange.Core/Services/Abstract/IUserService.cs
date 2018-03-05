using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossoverStockExchange.Core.Repositories.Abstract;
using CrossoverStockExchange.Core.Services.Abstract;
using StructureMap;
using System.Web;
using CrossoverStockExchange.Core.Entities;
namespace CrossoverStockExchange.Core.Services.Abstract
{
    public interface IUserService
    {
        ApplicationUser GetById(string id);
    }
}
