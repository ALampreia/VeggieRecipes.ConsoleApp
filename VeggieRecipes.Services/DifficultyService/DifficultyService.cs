using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.DifficultyService
{
    public class DifficultyService : IDifficultyService
    {
        private IDifficultyRepository _difficultyRepository;

        public DifficultyService (IDifficultyRepository difficultyRepository)
        {
            _difficultyRepository = difficultyRepository;
        }

        public List<Difficulty> GetAll()
        {
            return _difficultyRepository.GetAll();
        }
        public Difficulty GetById(int id)
        {
            return _difficultyRepository.GetById(id);
        }
        public Difficulty Update(Difficulty entity)
        {
            return _difficultyRepository.Update(entity);
        }
        public Difficulty Add(Difficulty entity)
        {
            return _difficultyRepository.Add(entity);
        }
        public Difficulty Delete(int id)
        {
            return _difficultyRepository.Delete(id);
        }
        public Difficulty Delete(Difficulty entity)
        {
            return _difficultyRepository.Delete(entity);
        }
    }
}
