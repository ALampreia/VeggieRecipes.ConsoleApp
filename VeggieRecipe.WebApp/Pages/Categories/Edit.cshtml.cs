using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;

namespace VeggieRecipe.WebApp.Pages.Categories
{
    public class EditModel : PageModel
    {
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public User SessionUser { get; set; }
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = CategoryService.GetById(id);
            GetSessionUser();
        }

        public IActionResult OnPost()
        {
            Category category = new Category();

            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.CategoryName = Request.Form["categoryName"].ToString();

            CategoryService.Update(category);

            return Redirect("/Categories/ListAll");
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
