using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.Interfaces;
using VeggieRecipes.Domain.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.MesuramentRepository
{
    public interface IMesuramentRepository : IRepository<Mesurament>
    {
    }
}
