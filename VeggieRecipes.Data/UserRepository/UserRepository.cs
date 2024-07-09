using Azure.Identity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Interfaces;
using VeggieRecipes.Domain.Model;

namespace VeggieRecipes.Data.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = @"Server=ANDRE\SQLEXPRESS;Database=final;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [User];";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User();

                            user.Id = Convert.ToInt32(reader["userId"]);
                            user.FirstName = reader["firstName"].ToString();
                            user.LastName = reader["lastName"].ToString();
                            user.Email = reader["email"].ToString();
                            user.Username = reader["username"].ToString();
                            user.Password = reader["password"].ToString();
                            user.IsAdmin = Convert.ToBoolean(reader["admin"]);
                            user.IsBlocked = Convert.ToBoolean(reader["blocked"]);


                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }
        public User GetById(int id)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [User] WHERE userId = @userId;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new User();

                            user.Id = Convert.ToInt32(reader["userId"]);
                            user.FirstName = reader["firstName"].ToString();
                            user.LastName = reader["lastName"].ToString();
                            user.Email = reader["email"].ToString();
                            user.Username = reader["username"].ToString();
                            user.Password = reader["password"].ToString();
                            user.IsAdmin = Convert.ToBoolean(reader["admin"]);
                            user.IsBlocked = Convert.ToBoolean(reader["blocked"]);

                        }
                    }
                }
            }
            return user;
        }
        public List<User> GetUsersByStatusAndRole(string filterOption)
        {
            List<User> users = new List<User>();
            string query;

            switch (filterOption)
            {
                case "Blocked":
                    query = "SELECT * FROM [User] WHERE blocked = 1;";
                    break;
                case "NotBlocked":
                    query = "SELECT * FROM [User] WHERE blocked = 0;";
                    break;
                case "Admin":
                    query = "SELECT * FROM [User] WHERE admin = 1;";
                    break;
                case "User":
                    query = "SELECT * FROM [User] WHERE admin = 0;";
                    break;
                case "All":
                default:
                    query = "SELECT * FROM [User];";
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

                            User user = new User();

                            user.Id = Convert.ToInt32(reader["userId"]);
                            user.FirstName = reader["firstName"].ToString();
                            user.LastName = reader["lastName"].ToString();
                            user.Email = reader["email"].ToString();
                            user.Username = reader["username"].ToString();
                            user.Password = reader["password"].ToString();
                            user.IsAdmin = Convert.ToBoolean(reader["admin"]);
                            user.IsBlocked = Convert.ToBoolean(reader["blocked"]);


                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }
        public User Add(User entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO [User] (username, firstName, lastName, email, password, admin, blocked) VALUES (@username, @firstName, @lastName, @email, @password, @isAdmin, @isBlocked);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@username", entity.Username);
                    cmd.Parameters.AddWithValue("@firstName",entity.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                    cmd.Parameters.AddWithValue("@email", entity.Email);
                    cmd.Parameters.AddWithValue("@password", entity.Password);
                    cmd.Parameters.AddWithValue("@isAdmin", entity.IsAdmin);
                    cmd.Parameters.AddWithValue("@isBlocked", entity.IsBlocked);

                   
                    cmd.ExecuteNonQuery();

                }
            }
           return entity;
        }
        public User Update(User entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                int blocked;
                int admin;
                if (entity.IsBlocked)
                {
                     blocked = 1;
                }
                else
                {
                    blocked = 0;
                }
                if (entity.IsAdmin)
                {
                    admin = 1;
                }
                else
                {
                    admin = 0;
                }
                    
                string query = "UPDATE [User] SET " + 
                                   "username = @username," +
                                   "firstName = @firstName," +
                                   "lastName = @lastName," +
                                   "email = @email," +
                                   "password = @password," +
                                   "admin = @isAdmin," +
                                   "blocked = @isBlocked " +
                                   " WHERE userId = @userId;";
                    
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", entity.Id);
                    cmd.Parameters.AddWithValue("@username", entity.Username);
                    cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                    cmd.Parameters.AddWithValue("@email", entity.Email);
                    cmd.Parameters.AddWithValue("@password", entity.Password);
                    cmd.Parameters.AddWithValue("@isAdmin", admin);
                    cmd.Parameters.AddWithValue("@isBlocked", blocked);
                  
                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public User UpdateUserBlockStatus(User entity, bool isBlocked)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE [User] SET " +
                    "blocked = @isBlocked " +
                    "WHERE userId = @userId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", entity.Id);
                    cmd.Parameters.AddWithValue("@isBlocked", isBlocked);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public User UpdateUserRole(User entity, bool isAdmin)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE [User] SET " +
                    "admin = @isAdmin " +
                    "WHERE userId = @userId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", entity.Id);
                    cmd.Parameters.AddWithValue("@isAdmin", isAdmin);

                    cmd.ExecuteNonQuery();
                }
            }
            return GetById(entity.Id);
        }
        public User Delete(User entity)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM [User] " +
                    "WHERE userId = @userId " +
                    "AND username = @username " +
                    "AND firstName = @firstName " +
                    "AND lastName = @lastName " +
                    "AND email = @email " +
                    "AND password = @password " +
                    "AND admin = @isAdmin " +
                    "AND blocked = @isBlocked";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", entity.Id);
                    cmd.Parameters.AddWithValue("@username", entity.Username);
                    cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                    cmd.Parameters.AddWithValue("@email", entity.Email);
                    cmd.Parameters.AddWithValue("@password", entity.Password);
                    cmd.Parameters.AddWithValue("@isAdmin", entity.IsAdmin);
                    cmd.Parameters.AddWithValue("@isBlocked", entity.IsBlocked);

                    cmd.ExecuteNonQuery();

                    return entity;
                }
            }
        }
        public User Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM [User] WHERE userId = @userId;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@userId", id);  


                    cmd.ExecuteNonQuery();

                }
            }
            return GetById(id);
        }
        public User Login(string username, string password)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [User] WHERE username = @username AND password = @password;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new User();

                            user.Id = Convert.ToInt32(reader["userId"]);
                            user.FirstName = reader["firstName"].ToString();
                            user.LastName = reader["lastName"].ToString();
                            user.Email = reader["email"].ToString();
                            user.Username = reader["username"].ToString();
                            user.Password = reader["password"].ToString();
                            user.IsAdmin = Convert.ToBoolean(reader["admin"]);
                            user.IsBlocked = Convert.ToBoolean(reader["blocked"]);

                        }
                    }
                }
            }
            return user;
        }
    }
}
