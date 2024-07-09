using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.Interfaces;

namespace VeggieRecipes.Services.IngredientService
{
    public interface IIngredientService : IService<Ingredient>
    {
    }
}
