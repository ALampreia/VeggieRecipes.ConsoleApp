using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.Interfaces;

namespace VeggieRecipes.Services.FavoriteRecipeService
{
    public interface IFavoriteRecipeService : IService<FavoriteRecipe>
    {
        List<FavoriteRecipe> GetFavoritesByUserId(int id);
        FavoriteRecipe GetFavoritesByUserAndRecipeId(int userId, int recipeID);
    }
}
