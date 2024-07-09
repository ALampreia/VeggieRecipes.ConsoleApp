using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.AmountIngredientRepository
{
    public interface IAmountIngredientRepository : IRepository<AmountIngredient>
    {
        List<AmountIngredient> GetAmountIngredientByRecipeId(int id);
        List<MesuredIngredientList> GetListMeasuredIngredients(int id);
    }
}
