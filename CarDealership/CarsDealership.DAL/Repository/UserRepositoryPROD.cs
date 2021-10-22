using CarDealership.Models;
using CarDealership.Models.Enumerations;
using CarsDealership.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Repository
{
    public class UserRepositoryPROD : IUserRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User user = new User();
                        user.UserId = dr["UserId"].ToString();
                        string[] names = dr["UserName"].ToString().Split(' ');
                        user.FirstName = names[0];
                        user.LastName = names.Length > 1 ? names[1] : "";
                        user.Email = dr["Email"].ToString();
                        user.Role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString(), true);

                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public User GetUserById(string id)
        {
            User user = new User();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUserById", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        user.UserId = dr["UserId"].ToString();
                        string[] names = dr["UserName"].ToString().Split(' ');
                        user.FirstName = names[0];
                        user.LastName = names.Length > 1 ? names[1] : "";
                        user.Email = dr["Email"].ToString();
                        user.Role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString(), true);

                    }
                }
            }
            return user;
        }
        public void RemoveDuplicates(string userId, string roleId)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("RemoveOldUserRoles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception e)
                {

                }
            }
        }
        public void UpdateUserName(string userId, string userName)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("RemoveOldUserRoles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@UserName", userName);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
