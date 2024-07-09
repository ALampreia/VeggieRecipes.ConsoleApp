using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.IngredientRepository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        public List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Ingredient;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ingredient ingredient = new Ingredient();

                            ingredient.Id = Convert.ToInt32(reader["ingredientID"]);
                            ingredient.IngredientName = reader["ingredientName"].ToString();

                            ingredients.Add(ingredient);
                        }
                    }
                }
            }
            return ingredients;
        }
        public Ingredient GetById(int id)
        {
            Ingredient ingredient = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Ingredient WHERE ingredientID = @ingredientID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ingredientID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ingredient = new Ingredient();

                            ingredient.Id = Convert.ToInt32(reader["ingredientID"]);
                            ingredient.IngredientName = reader["ingredientName"].ToString();
                        }
                    }
                }
                return ingredient;
            }
        }
        public Ingredient Add(Ingredient entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Ingredient (ingredientName) VALUES (@ingredientName);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ingredientName", entity.IngredientName);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Ingredient Update(Ingredient entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Ingredient SET " +
                                   "ingredientName = @ingredientName " +
                                   "WHERE ingredientID = @ingredientID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ingredientID", entity.Id);
                    cmd.Parameters.AddWithValue("@ingredientName", entity.IngredientName);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public Ingredient Delete(Ingredient entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Ingredient " +
                    "WHERE ingredientID = @ingredientID " +
                    "AND ingredientName = @ingredientName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ingredientID", entity.Id);
                    cmd.Parameters.AddWithValue("@ingredientName", entity.IngredientName);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Ingredient Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Ingredient WHERE ingredientID = @ingredientID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@ingredientID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(id);
        }

    }
}
