using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.CategoryRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
