using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.Interfaces;

namespace VeggieRecipes.Services.AmountIngredientService
{
    public interface IAmountIngredientService : IService<AmountIngredient>
    {
        List<AmountIngredient> GetAmountIngredientByRecipeId(int id);
        List<MesuredIngredientList> GetListMeasuredIngredients(int id);
    }
}
