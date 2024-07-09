using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.RatingRepository
{
    public interface IRatingRepository : IRepository<Rating>
    {
        List<Rating> GetRatingsByRecipeId(int id);
        float GetAvgRatingValue(int id);
        Rating GetRatingsByUserIdAndRecipeId(int userId, int recipeID);
    }
}
