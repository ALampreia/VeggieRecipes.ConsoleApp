using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.AmountIngredientRepository;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.RatingRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.AmountIngredientService;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.RatingService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.Ratings
{
    public class CreateModel : PageModel
    {
        public static IRatingRepository RatingRepo = new RatingRepository();
        public static IRatingService RatingService = new RatingService(RatingRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public static IAmountIngredientRepository AmountIngredientRepo = new AmountIngredientRepository();
        public static IAmountIngredientService AmountIngredientService = new AmountIngredientService(AmountIngredientRepo);

        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public Rating Rating { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public float AvgRatingValue { get; set; }

        public List<MesuredIngredientList> ListMesuredIngredients = new List<MesuredIngredientList>();

        public List<Rating> RatingList = new List<Rating>();
        public Recipe Recipe { get; set; }

        public IActionResult OnGet(int id)
        {
            GetSessionUser();
            Recipe = RecipeService.GetById(id);
            Category = CategoryService.GetById(Recipe.RecipeCategory.Id);
            Difficulty = DifficultyService.GetById(Recipe.RecipeDifficulty.Id);
            ListMesuredIngredients = AmountIngredientService.GetListMeasuredIngredients(id);
            RatingList = RatingService.GetRatingsByRecipeId(Recipe.Id);
            AvgRatingValue = RatingService.GetAvgRatingValue(Recipe.Id);
            Rating = RatingService.GetRatingsByUserIdAndRecipeId(SessionUser.Id, Recipe.Id);

            if (Rating.Id > 0)
            {
                return RedirectToPage("/Ratings/Edit", new { id = Rating.Id });
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Rating rating = new Rating();
            rating.UserId = new User();
            rating.RecipeId = new Recipe();

            rating.UserId.Id = Convert.ToInt32(Request.Form["userId"]);
            rating.RecipeId.Id = Convert.ToInt32(Request.Form["recipeId"]);
            rating.Value = Convert.ToInt32(Request.Form["value"]);
            rating.Comment = Request.Form["comment"].ToString();

            
            RatingService.Add(rating);


            return Redirect("/Recipes/ListAll");


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
