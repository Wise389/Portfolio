using CarDealership.Models;
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
    public class SpecialsRepositoryPROD : ISpecialsRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;
        public void Create(Special special)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateSpecial", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                cmd.Parameters.AddWithValue("@SpecialMessage", special.SpecialMessage);
                cmd.Parameters.AddWithValue("@ImageFilePath", special.ImageFilePath);

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

        public void Delete(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecial", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialId", id);
                
                try {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception e)
                {

                }
            }
        }

        public List<Special> GetAll()
        {
            List<Special> specials = new List<Special>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetSpecials", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special special = new Special();
                        special.SpecialId = Convert.ToInt32(dr["SpecialId"]);
                        special.SpecialMessage = dr["SpecialMessage"].ToString();
                        special.SpecialTitle = dr["SpecialTitle"].ToString();
                        special.ImageFilePath = dr["ImageFilePath"].ToString();

                        specials.Add(special);
                    }
                }
            }
            return specials;

        }

        public Special GetById(int id)
        {
            Special special = new Special();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetSpecialById", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialId", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        special.SpecialId = Convert.ToInt32(dr["SpecialId"]);
                        special.SpecialMessage = dr["SpecialMessage"].ToString();
                        special.SpecialTitle = dr["SpecialTitle"].ToString();
                        special.ImageFilePath = dr["ImageFilePath"].ToString();

                    }
                }
            }
            return special;
        }
    }
}
