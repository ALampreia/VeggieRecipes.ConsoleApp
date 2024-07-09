using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.IngredientRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.IngredientService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public static IIngredientRepository IngredientRepo = new IngredientRepository();
        public static IIngredientService IngredientService = new IngredientService(IngredientRepo);

        [BindProperty]
        public User SessionUser {get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public void OnGet()
        {
            GetSessionUser();
            CategoryList = CategoryService.GetAll();
            DifficultyList = DifficultyService.GetAll();
        }
        public IActionResult OnPost()
        {
            GetSessionUser();
            if (SessionUser != null)
                {
                Recipe recipe = new Recipe();  
                recipe.UserId = SessionUser;
                recipe.RecipeCategory = new Category();
                recipe.RecipeDifficulty = new Difficulty();

                recipe.UserId.Id = SessionUser.Id;//Convert.ToInt32(Request.Form["userId"]);
                recipe.Title = Request.Form["title"].ToString();
                recipe.PrepMethod = Request.Form["prepMethod"].ToString();
                recipe.PrepTime = Convert.ToInt32(Request.Form["prepTime"]);
                recipe.RecipeCategory.Id = Convert.ToInt32(Request.Form["category"]);
                recipe.RecipeDifficulty.Id = Convert.ToInt32(Request.Form["difficulty"]);
                recipe.IsBlocked = true;

                RecipeService.Add(recipe);

                return new RedirectToPageResult("/AmountIngredients/Create");
                }
            else
                {
                return new RedirectToPageResult("/Login/Login");
                }
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
