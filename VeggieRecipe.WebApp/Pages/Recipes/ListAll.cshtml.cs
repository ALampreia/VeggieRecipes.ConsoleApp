using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.RatingRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.RatingService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.Recipes
{
    public class ListAllModel : PageModel
    {
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public static IRatingRepository RatingRepo = new RatingRepository();
        public static IRatingService RatingService = new RatingService(RatingRepo);
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public User SessionUser { get; set; }
        public List<Recipe> RecipeList { get; set; }
        public float Rating { get; set; }

        public string filterOption = "NotBlocked";
        public void OnGet(int idCategory, int idDifficulty, int userId)
        {
            GetSessionUser();
            if (idCategory > 0)
            {
                RecipeList = RecipeService.GetRecipeByCategoryId(idCategory);
            }
            else if (idDifficulty > 0)
            {
                RecipeList = RecipeService.GetRecipeByDifficultyId(idDifficulty);
            }
            else if (userId > 0)
            {
                RecipeList = RecipeService.GetRecipeByUserId(userId);
            }
            else
            {
                RecipeList = RecipeService.GetRecipesByBlockedStatus(filterOption);
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
