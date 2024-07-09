using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.Admin
{
    public class AdminRecipesManageModel : PageModel
    {
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public User SessionUser { get; set; }
        public List<Recipe> RecipeList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterOption { get; set; }
        public Recipe Recipe { get; set; }
        public void OnGet(int id)
        {
            GetSessionUser();
            RecipeList = RecipeService.GetRecipesByBlockedStatus(FilterOption);
        }
        public IActionResult OnPost()
        {
            //this is a workaround as razor requests do not save info when onget finishes
            string recipeListJson = Request.Form["RecipeList"];
            RecipeList = JsonSerializer.Deserialize<List<Recipe>>(recipeListJson);

            foreach (var recipe in RecipeList)
            {
                bool isBlocked = Request.Form["blockedStatus_" + recipe.Id].ToString() == "Blocked";
                RecipeService.UpdateRecipeBlockStatus(recipe, isBlocked);
            }

            return RedirectToPage("/Admin/AdminRecipesManage");
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
