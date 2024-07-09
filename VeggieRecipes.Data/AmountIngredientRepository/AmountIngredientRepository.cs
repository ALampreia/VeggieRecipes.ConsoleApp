using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Data.IngredientRepository;
using VeggieRecipes.Data.MesuramentRepository;
using VeggieRecipes.Data.RecipeRepository;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.AmountIngredientRepository
{
    public class AmountIngredientRepository : IAmountIngredientRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        private IRecipeRepository _recipeRepo;
        private IIngredientRepository _ingredientRepo;
        private IMesuramentRepository _mesuramentRepo;
        public List<AmountIngredient> GetAll()
        {
            List<AmountIngredient> amounts = new List<AmountIngredient>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM AmountIngredient;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AmountIngredient amount = new AmountIngredient();
                            amount.IngredientId = new Ingredient();
                            amount.MesuramentId = new Mesurament();
                            amount.RecipeId = new Recipe();

                            amount.Id = Convert.ToInt32(reader["amountIngredientID"]);
                            amount.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                            amount.IngredientId.Id = Convert.ToInt32(reader["ingredientID"]);
                            amount.MesuramentId.Id = Convert.ToInt32(reader["mesuramentID"]);
                            amount.Quantity = (float)(double)reader["quantity"];
                            amounts.Add(amount);
                        }
                    }
                }
            }
            return amounts;
        }
        public AmountIngredient GetById(int id)
        {
            AmountIngredient amount = null;


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM AmountIngredient WHERE amountIngredientID = @amountIngredientID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@amountIngredientID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            amount = new AmountIngredient();
                            amount.IngredientId = new Ingredient();
                            amount.MesuramentId = new Mesurament();
                            amount.RecipeId = new Recipe();

                            amount.Id = Convert.ToInt32(reader["amountIngredientID"]);
                            amount.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                            amount.IngredientId.Id = Convert.ToInt32(reader["ingredientID"]);
                            amount.MesuramentId.Id = Convert.ToInt32(reader["mesuramentID"]);
                            amount.Quantity = (float)(double)reader["quantity"];
                        }
                    }
                }
            }
            return amount;
        }
        public AmountIngredient Add(AmountIngredient entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO AmountIngredient (recipeID, ingredientID, mesuramentID, quantity) VALUES (@recipeID, @ingredientID, @mesuramentID, @quantity); ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", entity.RecipeId.Id);
                    cmd.Parameters.AddWithValue("@ingredientID", entity.IngredientId.Id);
                    cmd.Parameters.AddWithValue("@mesuramentID", entity.MesuramentId.Id);
                    cmd.Parameters.AddWithValue("@quantity", entity.Quantity);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public AmountIngredient Update(AmountIngredient entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE AmountIngredient SET " +
                    "recipeID = @recipeID, " +
                    "ingredientID = @ingredientID, " +
                    "mesuramentID = @mesuramentID, " +
                    "quantity = @quantity " +
                    "WHERE amountIngredientID = @amountIngredientID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@amountIngredientID", entity.Id);
                    cmd.Parameters.AddWithValue("@recipeID", entity.RecipeId.Id);
                    cmd.Parameters.AddWithValue("@ingredientID", entity.IngredientId.Id);
                    cmd.Parameters.AddWithValue("@mesuramentID", entity.MesuramentId.Id);
                    cmd.Parameters.AddWithValue("@quantity", entity.Quantity);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public AmountIngredient Delete(AmountIngredient entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM AmountIngredient " +
                    "WHERE amountIngredientID = @amountIngredientID " +
                    "AND recipeId = @recipeId " +
                    "AND ingredientID = @ingredientID " +
                    "AND mesuramentID = @mesuramentID " +
                    "AND quantity = @quantity";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@amountIngredientID", entity.Id);
                    cmd.Parameters.AddWithValue("@recipeID", entity.RecipeId.Id);
                    cmd.Parameters.AddWithValue("@ingredientID", entity.IngredientId.Id);
                    cmd.Parameters.AddWithValue("@mesuramentID", entity.MesuramentId.Id);
                    cmd.Parameters.AddWithValue("@quantity", entity.Quantity);

                    cmd.ExecuteNonQuery();

                }
            }
            return entity;
        }
        public AmountIngredient Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM AmountIngredient WHERE amountIngredientID = @amountIngredientID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@amountIngredientID", id);

                    cmd.ExecuteNonQuery();

                }
            }
            return GetById(id);
        }
        public List<AmountIngredient> GetAmountIngredientByRecipeId(int id)
        {

            List<AmountIngredient> ListAmountIngredients = new List<AmountIngredient>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM AmountIngredient WHERE recipeID = @recipeID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AmountIngredient amount = new AmountIngredient();

                            amount = new AmountIngredient();
                            amount.IngredientId = new Ingredient();
                            amount.MesuramentId = new Mesurament();
                            amount.RecipeId = new Recipe();

                            amount.Id = Convert.ToInt32(reader["amountIngredientID"]);
                            amount.RecipeId.Id = Convert.ToInt32(reader["recipeID"]);
                            amount.IngredientId.Id = Convert.ToInt32(reader["ingredientID"]);
                            amount.MesuramentId.Id = Convert.ToInt32(reader["mesuramentID"]);
                            amount.Quantity = (float)(double)reader["quantity"];

                            ListAmountIngredients.Add(amount);
                        }
                    }
                }
            }
            return ListAmountIngredients;
        } 

        public List<MesuredIngredientList> GetListMeasuredIngredients(int id)
        {
            List<MesuredIngredientList> listMeasuredIngredients = new List<MesuredIngredientList>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT i.ingredientName, ai.quantity, m.mesuramentTitle " +
                    "FROM AmountIngredient ai " +
                    "JOIN Ingredient i ON ai.ingredientID = i.ingredientID " +
                    "JOIN Mesurament m ON ai.mesuramentID = m.mesuramentID " +
                    "WHERE recipeID = @recipeID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@recipeID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MesuredIngredientList list = new MesuredIngredientList();

                            list.IngredientName = Convert.ToString(reader["ingredientName"]);
                            list.IngredientQuantity = (float)(double)reader["quantity"];
                            list.UsedMesurament = Convert.ToString(reader["mesuramentTitle"]);

                            listMeasuredIngredients.Add(list);
                        }
                    }
                }
            }
            return listMeasuredIngredients;
            //}//may create errors
        }
    }
}

