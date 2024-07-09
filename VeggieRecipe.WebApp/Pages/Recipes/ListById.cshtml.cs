using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Text.Json;
using VeggieRecipes.Data.AmountIngredientRepository;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.FavoriteRecipeRepository;
using VeggieRecipes.Data.IngredientRepository;
using VeggieRecipes.Data.MesuramentRepository;
using VeggieRecipes.Data.RatingRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.AmountIngredientService;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.FavoriteRecipeService;
using VeggieRecipes.Services.IngredientService;
using VeggieRecipes.Services.MesuramentService;
using VeggieRecipes.Services.RatingService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.Recipes
{
    public class ListByIdModel : PageModel
    {
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public static IAmountIngredientRepository AmountIngredientRepo = new AmountIngredientRepository();
        public static IAmountIngredientService AmountIngredientService = new AmountIngredientService(AmountIngredientRepo);
        public static IIngredientRepository IngredientRepo = new IngredientRepository();
        public static IIngredientService IngredientService = new IngredientService(IngredientRepo);
        public static IMesuramentRepository MesuramentRepo = new MesuramentRepository();
        public static IMesuramentService MesuramentService = new MesuramentService(MesuramentRepo);
        public static IRatingRepository RatingRepo = new RatingRepository();
        public static IRatingService RatingService = new RatingService(RatingRepo);
        public static IFavoriteRecipeRepository FavoriteRecipeRepo = new FavoriteRecipeRepository();
        public static IFavoriteRecipeService FavoriteRecipeService = new FavoriteRecipeService(FavoriteRecipeRepo);
        public User SessionUser { get; set; }
        public Recipe Recipe { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public float AvgRatingValue { get; set; }

        public List<MesuredIngredientList> ListMesuredIngredients = new List<MesuredIngredientList>();

        public List<Rating> RatingList = new List<Rating>();
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public FavoriteRecipe FavoriteRecipe { get; set; }
        public void OnGet(int id)
        {
            GetSessionUser();
            Recipe = RecipeService.GetById(id);
            Category = CategoryService.GetById(Recipe.RecipeCategory.Id);
            Difficulty = DifficultyService.GetById(Recipe.RecipeDifficulty.Id);
            ListMesuredIngredients = AmountIngredientService.GetListMeasuredIngredients(id);
            RatingList = RatingService.GetRatingsByRecipeId(Recipe.Id);
            AvgRatingValue = RatingService.GetAvgRatingValue(Recipe.Id);
            if (SessionUser != null)
            {
                FavoriteRecipe = FavoriteRecipeService.GetFavoritesByUserAndRecipeId(SessionUser.Id, id);
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