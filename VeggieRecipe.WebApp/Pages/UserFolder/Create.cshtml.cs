using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.UserFolder
{
    public class CreateModel : PageModel
    {
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo); public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public void OnGet()
        {
            GetSessionUser();
        }
        public IActionResult OnPost()
        {
            User user = new User();
            user.FirstName = Request.Form["firstName"].ToString();
            user.LastName = Request.Form["lastName"].ToString();
            user.Username = Request.Form["username"].ToString();
            user.Email = Request.Form["email"].ToString();
            user.Password = Request.Form["password"].ToString();
            user.IsBlocked = false;
            user.IsAdmin = false;

            UserService.Add(user);

            return new RedirectToPageResult("/Login/Login");

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
