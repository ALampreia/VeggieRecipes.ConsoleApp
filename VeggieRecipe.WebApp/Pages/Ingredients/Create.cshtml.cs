using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.IngredientRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.IngredientService;

namespace VeggieRecipe.WebApp.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        public static IIngredientRepository IngredientRepo = new IngredientRepository();
        public static IIngredientService IngredientService = new IngredientService(IngredientRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public List<Ingredient> IngredientList { get; set; }
        public Ingredient Ingredient { get; set; }
        public void OnGet()
        {
            GetSessionUser(); 
            IngredientList = IngredientService.GetAll();
            CategoryList = CategoryService.GetAll();
            DifficultyList = DifficultyService.GetAll();
        }

        public IActionResult OnPost()
        {

            IngredientList = IngredientService.GetAll();

            Ingredient ingredient = new Ingredient();

            ingredient.IngredientName = Request.Form["ingredientName"].ToString();

            IngredientService.Add(ingredient);

            return Redirect("/Ingredients/Create");
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
