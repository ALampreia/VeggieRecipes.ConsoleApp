using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Data.UserRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.RatingRepository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        private IUserRepository _userRepo;
        private IRecipeRepository _recipeRepo;

        public List<Rating> GetAll()
        {
            List<Rating> ratings = new List<Rating>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Rating;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rating rating = new Rating();
                            rating.UserId = new User();
                            rating.RecipeId = new Recipe();

                            rating.Id = Convert.ToInt32(reader["ratingID"]);
                            rating.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                            rating.UserId.Id = Convert.ToInt32(reader["userId"]);
                            rating.Value = (float)(double)reader["value"];
                            rating.Comment = reader["comment"].ToString();

                            ratings.Add(rating);
                        }
                    }
                }
            }
            return ratings;
        }
        public Rating GetById(int id)
        {
            Rating rating = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Rating WHERE ratingID = @ratingID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ratingID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rating = new Rating();
                            rating.UserId = new User();
                            rating.RecipeId = new Recipe();

                            rating.Id = Convert.ToInt32(reader["ratingID"]);
                            rating.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                            rating.UserId.Id = Convert.ToInt32(reader["userId"]);
                            rating.Value = (float)(double)reader["value"];
                            rating.Comment = reader["comment"].ToString();
                        }
                    }
                }
            }
            return rating;
        }
        public Rating Add(Rating entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Rating(value, recipeID, userId, comment) VALUES (@value, @recipeId, @userId, @comment);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@value", entity.Value);
                    cmd.Parameters.AddWithValue("@recipeId", entity.RecipeId.Id);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@comment", entity.Comment);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Rating Update(Rating entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Rating SET " +
                    "value = @value, " +
                    "recipeID = @recipeID, " +
                    "userId = @userId, " +
                    "comment = @comment " +
                    "WHERE ratingID = @ratingID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ratingID", entity.Id);
                    cmd.Parameters.AddWithValue("@value", entity.Value);
                    cmd.Parameters.AddWithValue("@recipeId", entity.RecipeId.Id);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@comment", entity.Comment);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id); ;
        }
        public Rating Delete(Rating entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Rating " +
                    "WHERE ratingId = @ratingID " +
                    "AND value = @value " +
                    "AND recipeID = @recipeID " +
                    "AND userId = @userId " +
                    "AND comment = @comment";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ratingID", entity.Id);
                    cmd.Parameters.AddWithValue("@value", entity.Value);
                    cmd.Parameters.AddWithValue("@recipeId", entity.RecipeId.Id);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId.Id);
                    cmd.Parameters.AddWithValue("@comment", entity.Comment);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Rating Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Rating WHERE ratingID = @ratingID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ratingID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(id);
        }
        public List<Rating> GetRatingsByRecipeId(int id)
        {
            List<Rating> ratingsByRecipe = new List<Rating>();


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Rating WHERE recipeID = @recipeID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Rating rating = new Rating();
                            rating.UserId = new User();
                            rating.RecipeId = new Recipe();

                            rating.Id = Convert.ToInt32(reader["ratingID"]);
                            rating.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                            rating.UserId.Id = Convert.ToInt32(reader["userId"]);
                            rating.Value = (float)(double)reader["value"];
                            rating.Comment = reader["comment"].ToString();

                            ratingsByRecipe.Add(rating);
                        }
                    }
                }
            }
            return ratingsByRecipe;
        }
        public float GetAvgRatingValue(int id)
        {
            float avgRatingValue = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT AVG(value) AS avgRatingValue FROM Rating WHERE recipeID = @recipeID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["avgRatingValue"] != DBNull.Value)
                            {
                                avgRatingValue = Convert.ToSingle(reader["avgRatingValue"]);
                            }
                        }
                    }
                }
                double roundedAvgRatingValue = Math.Round(avgRatingValue, 1);

                return (float)roundedAvgRatingValue;
            }
        }
        public Rating GetRatingsByUserIdAndRecipeId(int userId, int recipeID)
        {
            Rating rating = new Rating();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Rating WHERE recipeID = @recipeID AND userId = @userId;";

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
                            rating.UserId = new User();
                            rating.RecipeId = new Recipe();

                            rating.Id = Convert.ToInt32(reader["ratingID"]);
                            rating.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                            rating.UserId.Id = Convert.ToInt32(reader["userId"]);
                            rating.Value = (float)(double)reader["value"];
                            rating.Comment = reader["comment"].ToString();
                        }
                    }
                }
            }
            return rating;
        }
    }
}
