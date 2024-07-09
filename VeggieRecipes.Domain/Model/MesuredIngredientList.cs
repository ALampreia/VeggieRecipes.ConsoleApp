using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeggieRecipes.Domain.Model
{
    public class MesuredIngredientList
    {
        public string IngredientName {  get; set; }
        public float IngredientQuantity { get; set; }
        public string UsedMesurament {  get; set; }
    }
}
