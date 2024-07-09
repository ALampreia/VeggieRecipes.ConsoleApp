using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Category;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category category = new Category();

                            category.Id = Convert.ToInt32(reader["categoryID"]);
                            category.CategoryName = reader["categoryName"].ToString();

                            categories.Add(category);
                        }
                    }
                }
            }
            return categories;
        }
        public Category GetById(int id)
        {
            Category category = new Category();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Category WHERE categoryID = @categoryID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@categoryID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            category = new Category();

                            category.Id = Convert.ToInt32(reader[("categoryID")]);
                            category.CategoryName = reader["categoryName"].ToString();

                        }
                    }
                }
            }
            return category;
        }
        public Category Add(Category entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Category (categoryName) VALUES (@categoryName);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@categoryName", entity.CategoryName);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Category Update(Category entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Category SET " +
                                   "categoryName = @categoryName " +
                                   "WHERE categoryID = @categoryID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@categoryID", entity.Id);
                    cmd.Parameters.AddWithValue("@categoryName", entity.CategoryName);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public Category Delete(Category entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Category " +
                    "WHERE categoryID = @categoryID " +
                    "AND categoryName = @categoryName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@categoryID", entity.Id);
                    cmd.Parameters.AddWithValue("@categoryName", entity.CategoryName);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Category Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Category WHERE categoryID = @categoryID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@categoryID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(id);
        }
    }
}
