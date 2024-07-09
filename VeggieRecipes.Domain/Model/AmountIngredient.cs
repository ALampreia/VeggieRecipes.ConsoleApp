using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Interfaces;

namespace VeggieRecipes.Domain.Model
{
    public class AmountIngredient : AuditableEntity, IEntity
    {
        public int Id { get; set; }
        public Recipe RecipeId { get; set; }
        public Ingredient IngredientId { get; set; }
        public Mesurament MesuramentId { get; set; }
        public float Quantity { get; set; }
    }
}
