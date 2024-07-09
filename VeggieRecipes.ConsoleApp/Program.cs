using System.Xml;
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
namespace VeggieRecipes.ConsoleApp
{
    internal class Program
    {

        public static UserRepository Userrepo = new UserRepository();
        public static UserService UserService = new UserService(Userrepo);
        public static RecipeRepository RecipeRepo = new RecipeRepository();
        public static RecipeService RecipeService = new RecipeService(RecipeRepo);
        public static RatingRepository RatingRepo = new RatingRepository();
        public static RatingService RatingService = new RatingService(RatingRepo);
        public static MesuramentRepository MesuramentRepository = new MesuramentRepository();
        public static MesuramentService MesuramentService = new MesuramentService(MesuramentRepository);
        public static IngredientRepository IngredientRepository = new IngredientRepository();
        public static IngredientService ingredientService = new IngredientService(IngredientRepository);
        public static FavoriteRecipeRepository FvRepo = new FavoriteRecipeRepository();
        public static FavoriteRecipeService FvSer = new FavoriteRecipeService(FvRepo);
        public static DifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static DifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public static CategoryRepository CategoryRepository = new CategoryRepository();
        public static CategoryService categoryService = new CategoryService(CategoryRepository);
        public static AmountIngredientRepository AmountIngredientRepository = new AmountIngredientRepository();
        public static AmountIngredientService AmountIngredientService = new AmountIngredientService(AmountIngredientRepository);



        static void Main(string[] args)
        {


            //List<AmountIngredient> x = AmountIngredientService.GetAmountIngredientByRecipeId(30);
            //foreach (AmountIngredient amount in x)
            //{
            //    Console.WriteLine(amount.IngredientName);
            //}
            //    ---------GetAll--------------
            //    List<Recipe> xs = RecipeService.GetAll();

            //    foreach (Recipe x in xs)
            //    {
            //        Console.WriteLine(x.PrepMethod);
            //    }
            //    -----------------GetrecipeBycategoryid--------------
            //int x = 13;
            //Category category = new Category();
            //User user = new User();
            //Difficulty difficulty = new Difficulty();
            //Recipe y = new Recipe();
            //float w;

            //w = RatingRepo.GetAvgRatingValue(30);
            //Console.WriteLine(w);

            // List<MesuredIngredientList> x = AmountIngredientRepository.GetListMeasuredIngredients(30);

            //foreach(var y in x)
            // {
            //     Console.WriteLine($"{y.IngredientName} {y.IngredientQuantity} {y.UsedMesurament}" );

            // }

            //List<FavoriteRecipe> favList = FvSer.GetFavoritesByUserId(x);
            //List<Recipe> recipeList = RecipeService.GetRecipeByDifficultyId(x);

            //foreach (var fav in favList)
            //{
            //    Recipe recipe = new Recipe();
            //    recipe = RecipeService.GetById(fav.RecipeId.Id);
            //    Console.WriteLine($"Fav Id: {fav.Id}, Recipe Title: {recipe.Title}");
            //}


            //    -----------------Add / Update / Delete-------------------- -
            //User x = new User();

            //x.FirstName = "jose";
            //x.LastName = "marcos";
            //x.Username = "jmarcos";
            //x.Password = "1234";
            //x.Email = "jose@email.com";

            //UserService.Add(x);


            //    -------------login-------------- -
            //User user = new User();


            //user.Username = "123456";
            //user.Password = "dwd";


            //user = UserService.Login(user.Username, user.Password);

            List<Recipe> recipes = new List<Recipe>();
            
            recipes = RecipeService.GetThreeRandomRecipe();

          
            foreach(var recipe in recipes)
            {
            Console.WriteLine(recipe.Title);

            }



        }

    }
}