using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Interfaces;

namespace VeggieRecipes.Domain.Model
{
    public class Recipe : AuditableEntity, IEntity
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public string Title { get; set; }
        public string PrepMethod { get; set; }
        public int PrepTime { get; set; }
        public Category RecipeCategory { get; set; }
        public Difficulty RecipeDifficulty { get; set; }
        public bool IsBlocked { get; set; }

    }
}
