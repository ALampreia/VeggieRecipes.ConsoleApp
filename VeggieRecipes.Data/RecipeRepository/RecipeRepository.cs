using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.CategoryRepository;
using VeggieRecipes.Data.DifficultyRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.RecipeRepository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        private IUserRepository _userRepo;
        private IDifficultyRepository _difficultyRepo;
        private ICategoryRepository _categoryRepo;
        public List<Recipe> GetAll()
        {
            List<Recipe> recipes = new List<Recipe>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Recipe;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe();
                            recipe.UserId = new User();
                            recipe.RecipeCategory = new Category();
                            recipe.RecipeDifficulty = new Difficulty();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                            recipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            recipe.Title = reader["title"].ToString();
                            recipe.PrepMethod = reader["preparationMethod"].ToString();
                            recipe.PrepTime = Convert.ToInt32(reader["preparationTime"]);
                            recipe.RecipeCategory.Id = Convert.ToInt32(reader["categoryID"]);
                            recipe.RecipeDifficulty.Id = Convert.ToInt32(reader["difficultyID"]);
                            recipe.IsBlocked = Convert.ToBoolean(reader["blocked"]);

                            recipes.Add(recipe);
                        }
                    }
                }
            }
            return recipes;
        }
        public Recipe GetById(int id)
        {
            Recipe recipe = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Recipe WHERE recipeID = @recipeID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            recipe = new Recipe();
                            recipe.UserId = new User();
                            recipe.RecipeCategory = new Category();
                            recipe.RecipeDifficulty = new Difficulty();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                            recipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            recipe.Title = reader["title"].ToString();
                            recipe.PrepMethod = reader["preparationMethod"].ToString();
                            recipe.PrepTime = Convert.ToInt32(reader["preparationTime"]);
                            recipe.RecipeCategory.Id = Convert.ToInt32(reader["categoryID"]);
                            recipe.RecipeDifficulty.Id = Convert.ToInt32(reader["difficultyID"]);
                            recipe.IsBlocked = Convert.ToBoolean(reader["blocked"]);
                        }
                    }
                }
            }
            return recipe;
        }
        public int GetLastRecipe()
        {
            Recipe recipe = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT TOP 1 * FROM Recipe ORDER BY recipeID DESC;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            recipe = new Recipe();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                        }
                    }
                }
            }
            return recipe.Id;
        }
        public List<Recipe> GetRecipeByCategoryId(int id)
        {
            List<Recipe> recipesByCategory = new List<Recipe>(); ;


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Recipe WHERE categoryID = @categoryID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@categoryID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Recipe recipe = new Recipe();
                            recipe.UserId = new User();
                            recipe.RecipeCategory = new Category();
                            recipe.RecipeDifficulty = new Difficulty();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                            recipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            recipe.Title = reader["title"].ToString();
                            recipe.PrepMethod = reader["preparationMethod"].ToString();
                            recipe.PrepTime = Convert.ToInt32(reader["preparationTime"]);
                            recipe.RecipeCategory.Id = Convert.ToInt32(reader["categoryID"]);
                            recipe.RecipeDifficulty.Id = Convert.ToInt32(reader["difficultyID"]);

                            recipesByCategory.Add(recipe);
                        }
                    }
                }
            }
            return recipesByCategory;
        }
        public List<Recipe> GetRecipeByUserId(int id)
        {
            List<Recipe> recipesByUser = new List<Recipe>(); ;


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Recipe WHERE userId = @userId;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Recipe recipe = new Recipe();
                            recipe.UserId = new User();
                            recipe.RecipeCategory = new Category();
                            recipe.RecipeDifficulty = new Difficulty();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                            recipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            recipe.Title = reader["title"].ToString();
                            recipe.PrepMethod = reader["preparationMethod"].ToString();
                            recipe.PrepTime = Convert.ToInt32(reader["preparationTime"]);
                            recipe.RecipeCategory.Id = Convert.ToInt32(reader["categoryID"]);
                            recipe.RecipeDifficulty.Id = Convert.ToInt32(reader["difficultyID"]);
                            recipe.IsBlocked = Convert.ToBoolean(reader["blocked"]);

                            recipesByUser.Add(recipe);
                        }
                    }
                }
            }
            return recipesByUser;
        }
        public List<Recipe> GetRecipeByDifficultyId(int id)
        {
            List<Recipe> recipesByDifficulty = new List<Recipe>(); ;


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Recipe WHERE difficultyID = @difficultyID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@difficultyID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Recipe recipe = new Recipe();
                            recipe.UserId = new User();
                            recipe.RecipeCategory = new Category();
                            recipe.RecipeDifficulty = new Difficulty();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                            recipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            recipe.Title = reader["title"].ToString();
                            recipe.PrepMethod = reader["preparationMethod"].ToString();
                            recipe.PrepTime = Convert.ToInt32(reader["preparationTime"]);
                            recipe.RecipeCategory.Id = Convert.ToInt32(reader["categoryID"]);
                            recipe.RecipeDifficulty.Id = Convert.ToInt32(reader["difficultyID"]);
                            recipe.IsBlocked = Convert.ToBoolean(reader["blocked"]);

                            recipesByDifficulty.Add(recipe);
                        }
                    }
                }
            }
            return recipesByDifficulty;
        }
        public List<Recipe> GetThreeLastRecipe()
        {
            List<Recipe> recipes = new List<Recipe>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT TOP 3 * FROM Recipe WHERE blocked = 0 ORDER BY recipeID DESC;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe();
                            recipe.UserId = new User();
                            recipe.RecipeCategory = new Category();
                            recipe.RecipeDifficulty = new Difficulty();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                            recipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            recipe.Title = reader["title"].ToString();
                            recipe.PrepMethod = reader["preparationMethod"].ToString();
                            recipe.PrepTime = Convert.ToInt32(reader["preparationTime"]);
                            recipe.RecipeCategory.Id = Convert.ToInt32(reader["categoryID"]);
                            recipe.RecipeDifficulty.Id = Convert.ToInt32(reader["difficultyID"]);
                            recipe.IsBlocked = Convert.ToBoolean(reader["blocked"]);

                            recipes.Add(recipe);
                        }
                    }
                }
            }
            return recipes;
        }
        public int GetMinRecipeId()
        {
            int min = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT MIN(recipeID) AS minRecipeId FROM Recipe;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            min = Convert.ToInt32(reader["minRecipeId"].ToString());
                        }
                    }
                }
                return min;
            }
        }
        public int GetMaxRecipeId()
        {
            int max = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT MAX(recipeID) AS maxRecipeId FROM Recipe;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            max = Convert.ToInt32(reader["maxRecipeId"].ToString());
                        }
                    }
                }
                return max;
            }
        }
        public List<Recipe> GetThreeRandomRecipe()
        {
            int min = GetMinRecipeId();
            int max = GetMaxRecipeId();
            List<Recipe> recipes = new List<Recipe>();
            HashSet<int> foundIds = new HashSet<int>();
            Random random = new Random();

            while (recipes.Count < 3)
            {
                int randomId = random.Next(min, max);
                if (!foundIds.Contains(randomId))
                {
                    Recipe recipe = GetById(randomId);
                    if (recipe != null)
                    {
                        recipes.Add(recipe);
                        foundIds.Add(randomId);
                    }
                }
            }

            return recipes;
        }
        public List<Recipe> GetRecipesByBlockedStatus(string filterOption)
        {
            List<Recipe> Recipes = new List<Recipe>();
            string query;

            switch (filterOption)
            {
                case "Blocked":
                    query = "SELECT * FROM Recipe WHERE blocked = 1;";
                    break;
                case "NotBlocked":
                    query = "SELECT * FROM Recipe WHERE blocked = 0;";
                    break;
                case "All":
                default:
                    query = "SELECT * FROM Recipe;";
                    break;
            }

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Recipe recipe = new Recipe();
                            recipe.UserId = new User();
                            recipe.RecipeCategory = new Category();
                            recipe.RecipeDifficulty = new Difficulty();

                            recipe.Id = Convert.ToInt32(reader["recipeID"]);
                            recipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            recipe.Title = reader["title"].ToString();
                            recipe.PrepMethod = reader["preparationMethod"].ToString();
                            recipe.PrepTime = Convert.ToInt32(reader["preparationTime"]);
                            recipe.RecipeCategory.Id = Convert.ToInt32(reader["categoryID"]);
                            recipe.RecipeDifficulty.Id = Convert.ToInt32(reader["difficultyID"]);
                            recipe.IsBlocked = Convert.ToBoolean(reader["blocked"]);

                            Recipes.Add(recipe);
                        }
                    }
                }
            }
            return Recipes;
        }
        public Recipe Add(Recipe entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Recipe(userId, categoryID, difficultyID, title, preparationMethod, preparationTime, blocked) VALUES (@userId, @recipeCategory, @recipeDifficulty, @title, @prepMethod, @prepTime, @isBlocked); ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@recipeCategory", entity.RecipeCategory.Id);
                    cmd.Parameters.AddWithValue("@recipeDifficulty", entity.RecipeDifficulty.Id);
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.Parameters.AddWithValue("@prepMethod", entity.PrepMethod);
                    cmd.Parameters.AddWithValue("@prepTime", entity.PrepTime);
                    cmd.Parameters.AddWithValue("@isBlocked", entity.IsBlocked);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Recipe Update(Recipe entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Recipe SET " +
                    "userId = @userId, " +
                    "categoryID = @category, " +
                    "difficultyID = @difficulty, " +
                    "title = @title, " +
                    "preparationMethod = @prepMethod, " +
                    "preparationTime = @prepTime, " +
                    "blocked = 1 " +
                    "WHERE recipeID = @recipeID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", entity.Id);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@category", entity.RecipeCategory.Id);
                    cmd.Parameters.AddWithValue("@difficulty", entity.RecipeDifficulty.Id);
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.Parameters.AddWithValue("@prepMethod", entity.PrepMethod);
                    cmd.Parameters.AddWithValue("@prepTime", entity.PrepTime);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public Recipe UpdateRecipeBlockStatus(Recipe entity, bool isBlocked)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Recipe SET " +
                    "blocked = @isBlocked " +
                    "WHERE recipeID = @recipeID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", entity.Id);
                    cmd.Parameters.AddWithValue("@isBlocked", isBlocked);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public Recipe Delete(Recipe entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Recipe " +
                    "WHERE recipeId = @recipeID " +
                    "AND userId = @userId " +
                    "AND categoryID = @recipeCategory " +
                    "AND difficultyID = @recipeDifficulty " +
                    "AND title = @title " +
                    "AND preparationMethod = @prepMethod " +
                    "AND blocked = @isBlocked " +
                    "AND preparationTime = @prepTime";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", entity.Id);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@recipeCategory", entity.RecipeCategory.Id);
                    cmd.Parameters.AddWithValue("@recipeDifficulty", entity.RecipeDifficulty.Id);
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.Parameters.AddWithValue("@prepMethod", entity.PrepMethod);
                    cmd.Parameters.AddWithValue("@prepTime", entity.PrepTime);
                    cmd.Parameters.AddWithValue("@isBlocked", entity.IsBlocked);

                    cmd.ExecuteNonQuery();

                }
            }
            return entity;
        }
        public Recipe Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Recipe WHERE recipeID = @recipeID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", id);

                    cmd.ExecuteNonQuery();

                }
            }
            return GetById(id);
        }
    }
}
