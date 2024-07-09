using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.AmountIngredientRepository;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.IngredientRepository;
using VeggieRecipes.Data.MesuramentRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.AmountIngredientService;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.IngredientService;
using VeggieRecipes.Services.MesuramentService;
using VeggieRecipes.Services.RecipeService;

namespace VeggieRecipe.WebApp.Pages.AmountIngredients
{
    public class ListByIdModel : PageModel
    {
        public static IAmountIngredientRepository AmountIngredientRepo = new AmountIngredientRepository();
        public static IAmountIngredientService AmountIngredientService = new AmountIngredientService(AmountIngredientRepo);
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IIngredientRepository IngredientRepo = new IngredientRepository();
        public static IIngredientService IngredientService = new IngredientService(IngredientRepo);
        public static IMesuramentRepository MesuramentRepo = new MesuramentRepository();
        public static IMesuramentService MesuramentService = new MesuramentService(MesuramentRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public User SessionUser { get; set; }
        public AmountIngredient AmountIngredient { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public Mesurament Mesurament { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public void OnGet(int id)
        {
            AmountIngredient = AmountIngredientService.GetById(id);
            Mesurament = MesuramentService.GetById(AmountIngredient.MesuramentId.Id);
            GetSessionUser();
        }
        private void GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                SessionUser = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
