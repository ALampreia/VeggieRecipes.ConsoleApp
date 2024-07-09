using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.UserService
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public User Update(User entity)
        {
            return _userRepository.Update(entity);
        }
        public User Add(User entity)
        {
            return _userRepository.Add(entity);
            //aqui fazer as validacoes como por exemplo, nao puder haver users com o mesmo username
        }
        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }
        public User Delete(User entity)
        {
            return _userRepository.Delete(entity);
        }
        public User Login(string username, string password)
        {
            return _userRepository.Login(username, password);
        }
        public List<User> GetUsersByStatusAndRole(string filterOption)
        {
            return _userRepository.GetUsersByStatusAndRole(filterOption);
        }       
        public User UpdateUserBlockStatus(User entity, bool isBlocked)
        {
            return _userRepository.UpdateUserBlockStatus(entity, isBlocked);
        }
        public User UpdateUserRole(User entity, bool isAdmin)
        {
            return _userRepository.UpdateUserRole(entity, isAdmin);
        }

    }
}
