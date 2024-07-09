using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.RecipeRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        int GetLastRecipe();
        List<Recipe> GetRecipeByCategoryId(int id);
        List<Recipe> GetRecipeByUserId(int id);
        List<Recipe> GetRecipeByDifficultyId(int id);
        List<Recipe> GetThreeLastRecipe();
        int GetMinRecipeId();
        int GetMaxRecipeId();
        List<Recipe> GetThreeRandomRecipe();
        List<Recipe> GetRecipesByBlockedStatus(string filterOption);
        Recipe UpdateRecipeBlockStatus(Recipe entity, bool isBlocked);
    }
}
