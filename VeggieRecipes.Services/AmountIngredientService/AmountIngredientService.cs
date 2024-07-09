using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.AmountIngredientRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.AmountIngredientService
{
    public class AmountIngredientService : IAmountIngredientService
    {
        private IAmountIngredientRepository _amountIngredientRepository;

        public AmountIngredientService (IAmountIngredientRepository amountIngredientRepository)
        {
            _amountIngredientRepository = amountIngredientRepository;
        }
        public List<AmountIngredient> GetAll()
        {
            return _amountIngredientRepository.GetAll();
        }
        public AmountIngredient GetById(int id)
        {
            return _amountIngredientRepository.GetById(id);
        }
        public AmountIngredient Update(AmountIngredient entity)
        {
            return _amountIngredientRepository.Update(entity);
        }
        public AmountIngredient Add(AmountIngredient entity)
        {
            return _amountIngredientRepository.Add(entity);
        }
        public AmountIngredient Delete(int id)
        {
            return _amountIngredientRepository.Delete(id);
        }
        public AmountIngredient Delete(AmountIngredient entity)
        {
            return _amountIngredientRepository.Delete(entity);
        }

        public List<AmountIngredient> GetAmountIngredientByRecipeId(int id)
        {
            return _amountIngredientRepository.GetAmountIngredientByRecipeId(id);
        }
        public List<MesuredIngredientList> GetListMeasuredIngredients(int id)
        {
            return _amountIngredientRepository.GetListMeasuredIngredients(id);
        }
    }
}
