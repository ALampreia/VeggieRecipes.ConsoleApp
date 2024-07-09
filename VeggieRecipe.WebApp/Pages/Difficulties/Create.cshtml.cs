using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;

namespace VeggieRecipe.WebApp.Pages.Difficulties
{
    public class CreateModel : PageModel
    {
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public Difficulty Difficulty { get; set; }
        public User SessionUser { get; set; }
        public void OnGet()
        {
            GetSessionUser();
        }

        public IActionResult OnPost()
        {

            Difficulty difficulty = new Difficulty();

            difficulty.DifficultyName = Request.Form["difficultyName"].ToString();

            DifficultyService.Add(difficulty);

            return Redirect("/Difficulties/Create");
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
