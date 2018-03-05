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
namespace CrossoverStockExchange.Core.Services.Concrete
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ApplicationUser GetById(string id)
        {
            return userRepository.GetById(id);
        }
    }
}
