using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.MesuramentRepository
{
    public class MesuramentRepository : IMesuramentRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        public List<Mesurament> GetAll()
        {
            List<Mesurament> mesuraments = new List<Mesurament>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Mesurament;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Mesurament mesurament = new Mesurament();

                            mesurament.Id = Convert.ToInt32(reader["mesuramentID"]);
                            mesurament.MesuramentTitle = reader["MesuramentTitle"].ToString();

                            mesuraments.Add(mesurament);
                        }
                    }
                }
            }
            return mesuraments;
        }
        public Mesurament GetById(int id)
        {
            Mesurament mesurament = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Mesurament WHERE mesuramentID = @mesuramentID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@mesuramentID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mesurament = new Mesurament();

                            mesurament.Id = Convert.ToInt32(reader["mesuramentID"]);
                            mesurament.MesuramentTitle = reader["mesuramentTitle"].ToString();
                        }                        
                    }
                }
                return mesurament;
            }
        }
        public Mesurament Add(Mesurament entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Mesurament (mesuramentTitle) VALUES (@mesuramentTitle);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@mesuramentTitle", entity.MesuramentTitle);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Mesurament Update(Mesurament entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Mesurament SET " +
                                   "mesuramentTitle = @mesuramentTitle " +
                                   "WHERE mesuramentID = @mesuramentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@mesuramentID", entity.Id);
                    cmd.Parameters.AddWithValue("@mesuramentTitle", entity.MesuramentTitle);                

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public Mesurament Delete(Mesurament entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Mesurament " +
                    "WHERE mesuramentID = @mesuramentID " +
                    "AND mesuramentTitle = @mesuramentTitle";               

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@mesuramentID", entity.Id);
                    cmd.Parameters.AddWithValue("@mesuramentTitle", entity.MesuramentTitle);

                    cmd.ExecuteNonQuery();
                }
            }
            return entity;
        }
        public Mesurament Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Mesurament WHERE mesuramentID = @mesuramentID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@mesuramentID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(id);
        }
    }
}
