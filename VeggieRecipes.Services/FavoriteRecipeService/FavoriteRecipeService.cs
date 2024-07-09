using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.FavoriteRecipeRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.FavoriteRecipeService
{
    public class FavoriteRecipeService : IFavoriteRecipeService
    {
        private IFavoriteRecipeRepository _favoriteRecipeRepository;

        public FavoriteRecipeService (IFavoriteRecipeRepository favoriteRecipeRepository)
        {
            _favoriteRecipeRepository = favoriteRecipeRepository;
        }
        public List<FavoriteRecipe> GetAll()
        {
            return _favoriteRecipeRepository.GetAll();
        }
        public FavoriteRecipe GetById(int id)
        {
            return _favoriteRecipeRepository.GetById(id);
        }
        public FavoriteRecipe Update(FavoriteRecipe entity)
        {
            return _favoriteRecipeRepository.Update(entity);
        }
        public FavoriteRecipe Add(FavoriteRecipe entity)
        {
            return _favoriteRecipeRepository.Add(entity);
        }
        public FavoriteRecipe Delete(int id)
        {
            return _favoriteRecipeRepository.Delete(id);
        }
        public FavoriteRecipe Delete(FavoriteRecipe entity)
        {
            return _favoriteRecipeRepository.Delete(entity);
        }
        public List<FavoriteRecipe> GetFavoritesByUserId(int id)
        {
            return _favoriteRecipeRepository.GetFavoritesByUserId(id);
        }
        public FavoriteRecipe GetFavoritesByUserAndRecipeId(int userId, int recipeID)
        {
            return _favoriteRecipeRepository.GetFavoritesByUserAndRecipeId(userId, recipeID);
        }
    }
}
