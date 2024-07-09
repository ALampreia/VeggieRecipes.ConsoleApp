using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.Interfaces;

namespace VeggieRecipes.Services.RatingService
{
    public interface IRatingService : IService<Rating>
    {
        List<Rating> GetRatingsByRecipeId(int id);
        float GetAvgRatingValue(int id);
        Rating GetRatingsByUserIdAndRecipeId(int userId, int recipeID);
    }
}
