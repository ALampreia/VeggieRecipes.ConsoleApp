using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.IngredientRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.IngredientService
{
    public class IngredientService : IIngredientService
    {
        private IIngredientRepository _ingredientRepository;

        public IngredientService (IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public List<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }
        public Ingredient GetById(int id)
        {
            return _ingredientRepository.GetById(id);
        }
        public Ingredient Update(Ingredient entity)
        {
            return _ingredientRepository.Update(entity);
        }
        public Ingredient Add(Ingredient entity)
        {
            return _ingredientRepository.Add(entity);
        }
        public Ingredient Delete(int id)
        {
            return _ingredientRepository.Delete(id);
        }
        public Ingredient Delete(Ingredient entity)
        {
            return _ingredientRepository.Delete(entity);
        }
    }
}
