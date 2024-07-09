using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.FavoriteRecipeRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.FavoriteRecipeService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.FavoriteRecipes
{
    public class CreateModel : PageModel
    {
        public static IFavoriteRecipeRepository FavoriteRecipeRepo = new FavoriteRecipeRepository();
        public static IFavoriteRecipeService FavoriteRecipeService = new FavoriteRecipeService(FavoriteRecipeRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public FavoriteRecipe FavoriteRecipe { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public User SessionUser { get; set; }
        public Recipe Recipe { get; set; }
        public IActionResult OnGet(int id)
        {
            GetSessionUser();
            Recipe = RecipeService.GetById(id);

            if (SessionUser != null)
            {
                FavoriteRecipe favoriteRecipe = new FavoriteRecipe();
                favoriteRecipe.UserId = SessionUser;
                favoriteRecipe.RecipeId = new Recipe();

                favoriteRecipe.UserId.Id = SessionUser.Id;
                favoriteRecipe.RecipeId.Id = Recipe.Id;

                FavoriteRecipeService.Add(favoriteRecipe);

                var refererUrl = Request.Headers["Referer"].ToString();

                if (!string.IsNullOrEmpty(refererUrl))
                {
                    return Redirect(refererUrl);
                }
                else
                {
                  return RedirectToPage("/FavoriteRecipes/ListAll");
                }
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
