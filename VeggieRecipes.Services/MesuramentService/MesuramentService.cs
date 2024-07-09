using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.MesuramentRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Services.MesuramentService
{
    public class MesuramentService : IMesuramentService
    {
        private IMesuramentRepository _mesuramentRepository;

        public MesuramentService (IMesuramentRepository mesuramentRepository)
        {
            _mesuramentRepository = mesuramentRepository;
        }
        public List<Mesurament> GetAll()
        {
            return _mesuramentRepository.GetAll();
        }
        public Mesurament GetById(int id)
        {
            return _mesuramentRepository.GetById(id);
        }
        public Mesurament Add(Mesurament entity)
        {
            return _mesuramentRepository.Add(entity);
        }
        public Mesurament Update(Mesurament entity)
        {
            return _mesuramentRepository.Update(entity);
        }
        public Mesurament Delete(int id)
        {
            return _mesuramentRepository.Delete(id);
        }
        public Mesurament Delete(Mesurament entity)
        {
            return _mesuramentRepository.Delete(entity);
        }
    }
}
