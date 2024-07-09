using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.FavoriteRecipeRepository
{
    public class FavoriteRecipeRepository : IFavoriteRecipeRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        private IUserRepository _userRepo;
        private IRecipeRepository _recipeRepo;

        public List<FavoriteRecipe> GetAll()
        {
            List<FavoriteRecipe> favoriteRecipes = new List<FavoriteRecipe>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FavoriteRecipe;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FavoriteRecipe favRecipe = new FavoriteRecipe();
                            favRecipe.UserId = new User();
                            favRecipe.RecipeId = new Recipe();

                            favRecipe.Id = Convert.ToInt32(reader["favoriteID"]);
                            favRecipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            favRecipe.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);

                            favoriteRecipes.Add(favRecipe);
                        }
                    }
                }
            }
            return favoriteRecipes;
        }
        public FavoriteRecipe GetById(int id)
        {
            FavoriteRecipe favRecipe = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FavoriteRecipe WHERE favoriteID = @favoriteID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@favoriteID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            favRecipe = new FavoriteRecipe();
                            favRecipe.UserId = new User();
                            favRecipe.RecipeId = new Recipe();

                            favRecipe.Id = Convert.ToInt32(reader["favoriteID"]);
                            favRecipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            favRecipe.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                        }
                    }
                }
            }
            return favRecipe;
        }
        public FavoriteRecipe Add(FavoriteRecipe entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO FavoriteRecipe (userId, recipeID) VALUES (@userId, @recipeID);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@recipeID", entity.RecipeId.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public FavoriteRecipe Update(FavoriteRecipe entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE FavoriteRecipe SET " +
                     "userId = @userId, " +
                     "recipeID = @recipeID " +
                     "WHERE favoriteID = @favoriteID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@favoriteID", entity.Id);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@recipeID", entity.RecipeId.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public FavoriteRecipe Delete(FavoriteRecipe entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM FavoriteRecipe " +
                    "WHERE favoriteID = @favoriteID " +
                    "AND userId = @userId " +
                    "AND recipeId = @recipeId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@favoriteID", entity.Id);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@recipeID", entity.RecipeId.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public FavoriteRecipe Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM FavoriteRecipe WHERE favoriteID = @favoriteID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@favoriteID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(id);
        }
        public List<FavoriteRecipe> GetFavoritesByUserId(int id)
        {
            List<FavoriteRecipe> favoritesByUser = new List<FavoriteRecipe>();


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FavoriteRecipe WHERE userId = @userId;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            FavoriteRecipe favRecipe = new FavoriteRecipe();
                            favRecipe.UserId = new User();
                            favRecipe.RecipeId = new Recipe();

                            favRecipe.Id = Convert.ToInt32(reader["favoriteID"]);
                            favRecipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            favRecipe.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);

                            favoritesByUser.Add(favRecipe);
                        }
                    }
                }
            }
            return favoritesByUser;
        }
        public FavoriteRecipe GetFavoritesByUserAndRecipeId(int userId, int recipeID)
        {
            FavoriteRecipe favRecipe = new FavoriteRecipe();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FavoriteRecipe WHERE userId = @userId AND recipeID = @recipeID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            favRecipe.UserId = new User();
                            favRecipe.RecipeId = new Recipe();

                            favRecipe.Id = Convert.ToInt32(reader["favoriteID"]);
                            favRecipe.UserId.Id = Convert.ToInt32(reader["userId"]);
                            favRecipe.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                        }
                    }
                }
            }
            return favRecipe;
        }
    }
}
