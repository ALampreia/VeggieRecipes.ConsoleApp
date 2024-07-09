using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Exceptions;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.UserService;



namespace VeggieRecipes.Services.RecipeService
{

    public class RecipeService : IRecipeService
    {
        public static IUserRepository UserRepo = new UserRepository();
       // public static IUserService UserService = new UserService(UserRepo); -- To Solve This --

        private IRecipeRepository _recipeRepository;

        public RecipeService (IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public List<Recipe> GetAll()
        {
            return _recipeRepository.GetAll();
        }
        public Recipe GetById(int id)
        {
            return _recipeRepository.GetById(id);
        }
        public Recipe Update(Recipe entity)
        {
            return _recipeRepository.Update(entity);
        }
        //public Recipe UpdateValidation(Recipe entity, int userId)
        //{
        //    //if (!UserService().isAdmin(userId)) { throw new CustomException("User cant preform opeartion"); }

        //    //Recipe databaseRecipe = _recipeRepository.GetById(entity.Id);
        //    //User user = UserRepo.GetById(userId);

        //    //if (databaseRecipe.UserId.Id == userId || user.IsAdmin == true)
        //    //{
        //    return _recipeRepository.Update(entity);
        //    //-- Not working, anyone can edit --
        //    //}
        //    //else
        //    //{
        //    //    throw new CustomException("invalid.");
        //    //}
        //}
        public Recipe Add(Recipe entity)
        {
            return _recipeRepository.Add(entity);
        }
        public Recipe Delete(int id)
        {
            return _recipeRepository.Delete(id);
        }
        public Recipe Delete(Recipe entity)
        {
            return _recipeRepository.Delete(entity);
        }
        public int GetLastRecipe()
        {
            return _recipeRepository.GetLastRecipe();
        }
        public List<Recipe> GetRecipeByCategoryId(int id)
        {
            return _recipeRepository.GetRecipeByCategoryId(id);
        }
        public List<Recipe> GetRecipeByUserId(int id)
        {
            return _recipeRepository.GetRecipeByUserId(id);
        }
        public List<Recipe> GetRecipeByDifficultyId(int id)
        {
            return _recipeRepository.GetRecipeByDifficultyId(id);
        }
        public List<Recipe> GetThreeLastRecipe()
        {
            return _recipeRepository.GetThreeLastRecipe();
        }
        public int GetMinRecipeId()
        {
            return _recipeRepository.GetMinRecipeId();
        }
        public int GetMaxRecipeId()
        {
            return _recipeRepository.GetMaxRecipeId();
        }
        public List<Recipe> GetThreeRandomRecipe()
        {
            return _recipeRepository.GetThreeRandomRecipe();
        }
        public List<Recipe> GetRecipesByBlockedStatus(string filterOption)
        {
            return _recipeRepository.GetRecipesByBlockedStatus(filterOption);
        }
        public Recipe UpdateRecipeBlockStatus(Recipe entity, bool isBlocked)
        {
            return _recipeRepository.UpdateRecipeBlockStatus(entity, isBlocked);
        }
    }
}
