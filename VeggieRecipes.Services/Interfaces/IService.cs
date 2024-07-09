using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Interfaces;

namespace VeggieRecipes.Services.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
        T Delete(T entity);
    }
}
