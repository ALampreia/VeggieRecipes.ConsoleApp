﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Interfaces;

namespace VeggieRecipes.Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, IAuditableEntity
    {
      
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Delete(int id);
        
    }
}
