using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.RecipeService;
using VeggieRecipes.Services.UserService;

namespace VeggieRecipe.WebApp.Pages.Admin
{
    public class AdminUsersManageModel : PageModel
    {
        public static IRecipeRepository RecipeRepo = new RecipeRepository();
        public static IRecipeService RecipeService = new RecipeService(RecipeRepo);
        public static IUserRepository UserRepo = new UserRepository();
        public static IUserService UserService = new UserService(UserRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public List<User> UserList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterOption { get; set; }
        public void OnGet()
        {
            GetSessionUser();
            UserList = UserService.GetUsersByStatusAndRole(FilterOption);
        }
        public IActionResult OnPost()
        {
            UserList = UserService.GetUsersByStatusAndRole(FilterOption);

            foreach (var user in UserList)
            {
                bool isBlocked = Request.Form["blockedStatus_" + user.Id].ToString() == "Blocked";
                
                    UserService.UpdateUserBlockStatus(user, isBlocked);
                    bool isAdmin = Request.Form["role_" + user.Id].ToString() == "Admin";
                    UserService.UpdateUserRole(user, isAdmin);
            }
            return RedirectToPage("/Admin/AdminUsersManage");
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
