using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.FavoriteRecipeRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.FavoriteRecipeService;

namespace VeggieRecipe.WebApp.Pages.FavoriteRecipes
{
    public class ListByIdModel : PageModel
    {
        public static IFavoriteRecipeRepository FavoriteRecipeRepo = new FavoriteRecipeRepository();
        public static IFavoriteRecipeService FavoriteRecipeService = new FavoriteRecipeService(FavoriteRecipeRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public FavoriteRecipe FavoriteRecipe { get; set; }
        public void OnGet(int id)
        {
            FavoriteRecipe = FavoriteRecipeService.GetById(id);
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
