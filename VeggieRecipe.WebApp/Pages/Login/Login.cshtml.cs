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

namespace VeggieRecipe.WebApp.Pages.Login
{
    public class LoginModel : PageModel
    {
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (SetSessionUser() == false)
            {
                TempData["error"] = "Failed Login";
                return Redirect("Login");
            }
            else
            {
                GetSessionUser();
            }
            if (SessionUser.IsAdmin == true)
            {
                return Redirect("/Admin/Admin");
            }
            return Redirect("/Index");
        }

        public bool SetSessionUser()
        {
            string username = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();
            User? login = UserService.Login(username, password);
            if (login == null)
            {
                return false;
            }

            string jsonString = JsonSerializer.Serialize(login);
            HttpContext.Session.SetString("user", jsonString);
            return true;
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
