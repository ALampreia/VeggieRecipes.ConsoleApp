using VeggieRecipes.Data.AmountIngredientRepository;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.FavoriteRecipeRepository;
using VeggieRecipes.Data.IngredientRepository;
using VeggieRecipes.Data.MesuramentRepository;
using VeggieRecipes.Data.RatingRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Interfaces;
using VeggieRecipes.Services.AmountIngredientService;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.FavoriteRecipeService;
using VeggieRecipes.Services.IngredientService;
using VeggieRecipes.Services.MesuramentService;
using VeggieRecipes.Services.RatingService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "Login";
                options.IdleTimeout = TimeSpan.FromHours(8);
                options.Cookie.IsEssential = true;
            });
            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IAmountIngredientRepository, AmountIngredientRepository>();
            builder.Services.AddScoped<IAmountIngredientService, AmountIngredientService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();
            builder.Services.AddScoped<IDifficultyService, DifficultyService>();
            builder.Services.AddScoped<IFavoriteRecipeRepository, FavoriteRecipeRepository>();
            builder.Services.AddScoped<IFavoriteRecipeService, FavoriteRecipeService>();
            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<IMesuramentRepository, MesuramentRepository>();
            builder.Services.AddScoped<IMesuramentService, MesuramentService>();
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();
            builder.Services.AddScoped<IRatingService, RatingService>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            
                
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseMvc();

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            
            app.Run();
        }
    }
}