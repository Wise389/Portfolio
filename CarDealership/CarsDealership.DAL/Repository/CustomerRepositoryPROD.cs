using CarDealership.DAL.Interface;
using CarDealership.Models;
using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Repository
{
    public class CustomerRepositoryPROD : ICustomerRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

        public void AddContact(Contact contact)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateContact", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@Message", contact.Message);

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

        public void Create(Customer customer)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateCustomer", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Street1", customer.Street1);
                cmd.Parameters.AddWithValue("@Street2", customer.Street2);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@StateId", customer.State);
                cmd.Parameters.AddWithValue("@Zipcode", customer.Zipcode);

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
                SqlCommand cmd = new SqlCommand("DeleteCustomer", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", id);

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
        public Customer GetById(int id)
        {
            Customer customers = new Customer();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetById", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        customers.Name = dr["Name"].ToString();
                        customers.Phone = dr["Phone"].ToString();
                        customers.Email = dr["Email"].ToString();
                        customers.Street1 = dr["Street1"].ToString();
                        customers.Street2 = dr["Street2"].ToString();
                        customers.City = dr["City"].ToString();
                        customers.State = (State)Convert.ToInt32(dr["StateId"]);
                        customers.Zipcode = Convert.ToInt32(dr["Zipcode"]);
                    }
                }
            }
            return (customers);
        }
    }
}
