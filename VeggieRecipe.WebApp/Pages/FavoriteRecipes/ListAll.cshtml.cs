using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.FavoriteRecipeRepository;
using VeggieRecipes.Data.RatingRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.FavoriteRecipeService;
using VeggieRecipes.Services.RatingService;
using VeggieRecipes.Services.RecipeService;

namespace VeggieRecipe.WebApp.Pages.FavoriteRecipes
{
    public class ListAllModel : PageModel
    {
        public static IFavoriteRecipeRepository FavoriteRecipeRepo = new FavoriteRecipeRepository();
        public static IFavoriteRecipeService FavoriteRecipeService = new FavoriteRecipeService(FavoriteRecipeRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IRatingRepository RatingRepo = new RatingRepository();
        public static IRatingService RatingService = new RatingService(RatingRepo);
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public List<FavoriteRecipe> FavoriteRecipesList { get; set; }

        public List<Recipe> RecipeList = new List<Recipe>();
        public void OnGet()
        {
            GetSessionUser();
            FavoriteRecipesList = FavoriteRecipeRepo.GetFavoritesByUserId(SessionUser.Id);
            foreach(var favorite in FavoriteRecipesList)
            {
                Recipe recipe = new Recipe();
                recipe = RecipeService.GetById(favorite.RecipeId.Id);

                RecipeList.Add(recipe);
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
