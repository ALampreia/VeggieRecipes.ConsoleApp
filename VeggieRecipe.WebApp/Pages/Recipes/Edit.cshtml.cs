using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Domain.Exceptions;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;
using Microsoft.AspNetCore.SignalR;

namespace VeggieRecipe.WebApp.Pages.Recipes
{
    public class EditModel : PageModel
    {
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public Recipe Recipe { get; set; }
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public void OnGet(int id)
        {
            GetSessionUser();
            Recipe = RecipeService.GetById(id);
            CategoryList = CategoryService.GetAll();
            DifficultyList = DifficultyService.GetAll();
        }

        public IActionResult OnPost()
        {
            Recipe recipe = new Recipe();
            recipe.UserId = new User();
            recipe.RecipeCategory = new Category();
            recipe.RecipeDifficulty = new Difficulty();

            recipe.Id = Convert.ToInt32(Request.Form["id"]);
            recipe.UserId.Id = Convert.ToInt32(Request.Form["userId"]);
            recipe.Title = Request.Form["title"].ToString();
            recipe.PrepMethod = Request.Form["prepMethod"].ToString();
            recipe.PrepTime = Convert.ToInt32(Request.Form["prepTime"]);
            recipe.RecipeCategory.Id = Convert.ToInt32(Request.Form["category"]);
            recipe.RecipeDifficulty.Id = Convert.ToInt32(Request.Form["difficulty"]);

            RecipeService.Update(recipe);
            return RedirectToPage("/AmountIngredients/Edit");
            //try
            //{
            //}
            //catch (CustomException ex)
            //{
            //    ModelState.AddModelError(string.Empty, ex.Message);
            //    return Page();
            //}
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
