using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService (ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
        public Category Update(Category entity)
        {
            return _categoryRepository.Update(entity);
        }
        public Category Add(Category entity)
        {
            return _categoryRepository.Add(entity);
        }
        public Category Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }
        public Category Delete(Category entity)
        {
            return _categoryRepository.Delete(entity);
        }
    }
}
