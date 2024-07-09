using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.Interfaces;

namespace VeggieRecipes.Services.UserService
{
    public interface IUserService : IService<User>
    {
        User? Login(string username, string password);
        List<User> GetUsersByStatusAndRole(string filterOption);
        User UpdateUserBlockStatus(User entity, bool isBlocked);
        User UpdateUserRole(User entity, bool isAdmin);
    }
}
