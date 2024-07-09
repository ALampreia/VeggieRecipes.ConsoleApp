using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.Interfaces;

namespace VeggieRecipes.Services.RecipeService
{
    public interface IRecipeService : IService<Recipe>
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
