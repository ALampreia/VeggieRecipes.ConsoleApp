using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.DifficultyRepository
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";

        public List<Difficulty> GetAll()
        {
            List<Difficulty> difficulties = new List<Difficulty>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Difficulty;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Difficulty difficulty = new Difficulty();

                            difficulty.Id = Convert.ToInt32(reader["difficultyID"]);
                            difficulty.DifficultyName = reader["difficultyName"].ToString();

                            difficulties.Add(difficulty);
                        }
                    }
                }
            }

            return difficulties;
        }
        public Difficulty GetById(int id)
        {
            Difficulty difficulty = new Difficulty();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Difficulty WHERE difficultyID = @difficultyID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@difficultyID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            difficulty = new Difficulty();

                            difficulty.Id = Convert.ToInt32(reader[("difficultyID")]);
                            difficulty.DifficultyName = reader["DifficultyName"].ToString();

                        }
                    }
                }
            }
            return difficulty;
        }
        public Difficulty Add(Difficulty entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Difficulty (difficultyName) VALUES (@difficultyName); ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@difficultyName", entity.DifficultyName);                   

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Difficulty Update(Difficulty entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Difficulty SET " +
                                   "difficultyName = @difficultyName " +
                                   "WHERE difficultyID = @difficultyID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@difficultyID", entity.Id);
                    cmd.Parameters.AddWithValue("@difficultyName", entity.DifficultyName);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public Difficulty Delete(Difficulty entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Difficulty " +
                                   "WHERE difficultyID = @difficultyID " +
                                   "AND difficultyName = @difficultyName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@difficultyID", entity.Id);
                    cmd.Parameters.AddWithValue("@difficultyName", entity.DifficultyName);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Difficulty Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Difficulty WHERE difficultyID = @difficultyID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@difficultyID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(id);
        }
    }
}
