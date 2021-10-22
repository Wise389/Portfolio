using CarsDealership.DAL.Interface;
using CarsDealership.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Repository
{
    public class ReportsRepositoryPROD : IReportsRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;


        public List<InventoryReport> GetNew()
        {
            List<InventoryReport> inventory = new List<InventoryReport>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetInventoryReport", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConditionID", 1);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport newInventory = new InventoryReport();
                        newInventory.Year = Convert.ToInt32(dr["Year"]);
                        newInventory.Make = dr["MakeName"].ToString();
                        newInventory.Model = dr["ModelName"].ToString();
                        newInventory.Count = Convert.ToInt32(dr["Count"]);
                        newInventory.StockValue = Convert.ToInt32(dr["Stock Value"]);

                        inventory.Add(newInventory);
                    }
                }
            }
            return (inventory);
        }

        public List<InventoryReport> GetUsed()
        {
            List<InventoryReport> inventory = new List<InventoryReport>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetInventoryReport", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConditionID", 2);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport usedInventory = new InventoryReport();
                        usedInventory.Year = Convert.ToInt32(dr["Year"]);
                        usedInventory.Make = dr["MakeName"].ToString();
                        usedInventory.Model = dr["ModelName"].ToString();
                        usedInventory.Count = Convert.ToInt32(dr["Count"]);
                        usedInventory.StockValue = Convert.ToInt32(dr["Stock Value"]);

                        inventory.Add(usedInventory);
                    }
                }
            }
            return (inventory);
        }
        public List<SalesReport> GetSalesReports(string User, DateTime? fromDate, DateTime? toDate)
        {
            List<SalesReport> sales = new List<SalesReport>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetSalesReport", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (fromDate == null)
                {
                    cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@StartDate", fromDate);
                }
                if (toDate == null)
                {
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EndDate", toDate);
                }
                if (string.IsNullOrEmpty(User))
                {
                    cmd.Parameters.AddWithValue("@UserId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UserId", User);
                }

                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SalesReport sale = new SalesReport();
                            sale.User = dr["UserName"].ToString();
                            sale.TotalSales = Convert.ToInt32(dr["TotalSales"]);
                            sale.TotalVehicles = Convert.ToInt32(dr["TotalVehicles"]);


                            sales.Add(sale);
                        }
                    }
                }
                catch (Exception e)
                {

                }
                return sales;
            }
        }
    }
}
