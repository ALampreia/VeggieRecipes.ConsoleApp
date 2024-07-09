using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.RatingRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.RatingService
{
    public class RatingService : IRatingService
    {
        private IRatingRepository _ratingRepository;

        public RatingService (IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public Rating Add(Rating entity)
        {
            return _ratingRepository.Add(entity);
        }
        public List<Rating> GetAll()
        {
            return _ratingRepository.GetAll();
        }
        public Rating GetById(int id)
        {
            return _ratingRepository.GetById(id);
        }
        public Rating Update(Rating entity)
        {

            return _ratingRepository.Update(entity);
        }
        public Rating Delete(int id)
        {
            return _ratingRepository.Delete(id);
        }
        public Rating Delete(Rating entity)
        {
            return _ratingRepository.Delete(entity);
        }

        public List<Rating> GetRatingsByRecipeId(int id)
        {
            return _ratingRepository.GetRatingsByRecipeId(id);
        }
        public float GetAvgRatingValue(int id)
        {
            return _ratingRepository.GetAvgRatingValue(id);
        }
        public Rating GetRatingsByUserIdAndRecipeId(int userId, int recipeID)
        {
            return _ratingRepository.GetRatingsByUserIdAndRecipeId(userId, recipeID);
        }
    }
}
