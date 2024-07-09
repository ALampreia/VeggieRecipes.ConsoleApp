using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.MesuramentRepository;
using VeggieRecipes.Domain.Model;
using VeggieRecipes.Services.CategoryService;
using VeggieRecipes.Services.DifficultyService;
using VeggieRecipes.Services.MesuramentService;

namespace VeggieRecipe.WebApp.Pages.Mesuraments
{
    public class EditModel : PageModel
    {
        public static IMesuramentRepository MesuramentRepo = new MesuramentRepository();
        public static IMesuramentService MesuramentService = new MesuramentService(MesuramentRepo);
        public static ICategoryRepository CategoryRepo = new CategoryRepository();
        public static ICategoryService CategoryService = new CategoryService(CategoryRepo);
        public static IDifficultyRepository DifficultyRepo = new DifficultyRepository();
        public static IDifficultyService DifficultyService = new DifficultyService(DifficultyRepo);
        public User SessionUser { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Difficulty> DifficultyList { get; set; }
        public Mesurament Mesurament { get; set; }
        public void OnGet(int id)
        {
            Mesurament = MesuramentService.GetById(id);
            GetSessionUser();
        }

        public IActionResult OnPost()
        { 
            Mesurament mesurament = new Mesurament();

            mesurament.Id = Convert.ToInt32(Request.Form["id"]);
            mesurament.MesuramentTitle = Request.Form["mesuramentTitle"].ToString();

            MesuramentService.Update(mesurament);
            return Redirect("/Mesuraments/ListAll");
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
