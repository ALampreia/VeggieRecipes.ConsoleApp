using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.FavoriteRecipeRepository
{
    public interface IFavoriteRecipeRepository : IRepository<FavoriteRecipe>
    {
        List<FavoriteRecipe> GetFavoritesByUserId(int id);
        FavoriteRecipe GetFavoritesByUserAndRecipeId(int userId, int recipeID);
    }
}
