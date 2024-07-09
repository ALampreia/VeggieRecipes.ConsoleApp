using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string username, string password);
        List<User> GetUsersByStatusAndRole(string filterOption);
        User UpdateUserBlockStatus(User entity, bool isBlocked);
        User UpdateUserRole(User entity, bool isAdmin);

    }
}
