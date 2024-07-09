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
    public class EditModel : PageModel
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
        public Ingredient Ingredient { get; set; }
        public void OnGet(int id)
        {
            Ingredient = IngredientService.GetById(id);
            GetSessionUser();
        }
        public IActionResult OnPost()
        {
            Ingredient ingredient = new Ingredient();

            ingredient.Id = Convert.ToInt32(Request.Form["id"]);
            ingredient.IngredientName = Request.Form["ingredientName"].ToString();
            
            IngredientService.Update(ingredient);

            return Redirect("/Ingredients/ListAll");
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
