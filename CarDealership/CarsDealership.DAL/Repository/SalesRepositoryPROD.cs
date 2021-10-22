using CarDealership.DAL.Interface;
using CarDealership.Models;
using CarDealership.Models.Enumerations;
using CarsDealership.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Repository
{
    public class SalesRepositoryPROD : ISalesRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;
        public void Create(Sale Sales)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateSale", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchasePrice", Sales.PurchasePrice);
                cmd.Parameters.AddWithValue("@SalesType", Sales.SalesType);
                cmd.Parameters.AddWithValue("@SalesDate", Sales.SalesDate);
                cmd.Parameters.AddWithValue("@VehicleId", Sales.Vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@UserName", Sales.SalesPerson);
                cmd.Parameters.AddWithValue("@Name", Sales.Customer.Name);
                cmd.Parameters.AddWithValue("@Phone", Sales.Customer.Phone);
                cmd.Parameters.AddWithValue("@Email", Sales.Customer.Email);
                cmd.Parameters.AddWithValue("@Street1", Sales.Customer.Street1);
                if (Sales.Customer.Street2 == null)
                {
                    cmd.Parameters.AddWithValue("@Street2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Street2", Sales.Customer.Street2);
                }
                cmd.Parameters.AddWithValue("@City", Sales.Customer.City);
                cmd.Parameters.AddWithValue("@StateId", Sales.Customer.State);
                cmd.Parameters.AddWithValue("@Zipcode", Sales.Customer.Zipcode);
                //cmd.Parameters.AddWithValue("@Sold", Sales.Vehicle.Sold);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }
        }
        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllSales", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale sale = new Sale();
                        sale.SalesId = Convert.ToInt32(dr["SalesId"]);
                        //sales.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                        //sales.SalesType = (SalesType) Convert.ToInt32(dr["SalesType"]);  //Enum
                        //sales.SalesDate = Convert.ToDateTime(dr["SalesDate"]);
                        sale.Customer.CustomerId = dr["CustomerId"] != DBNull.Value ? Convert.ToInt32(dr["CustomerId"]) : 0;
                        sale.Vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                        //sales.SalesPerson = dr["UserId"].ToString();
                        sale.Vehicle.Make.MakeId = Convert.ToInt32(dr["MakeId"]);
                        sale.Vehicle.Make.MakeName = dr["MakeName"].ToString();
                        sale.Vehicle.Model.ModelId = Convert.ToInt32(dr["ModelId"]);
                        sale.Vehicle.Model.ModelName = dr["ModelName"].ToString();
                        sale.Vehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                        sale.Vehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                        sale.Vehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                        sale.Vehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                        sale.Vehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                        sale.Vehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                        sale.Vehicle.VIN = dr["VIN"].ToString();
                        sale.Vehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                        sale.Vehicle.Year = Convert.ToInt32(dr["Year"]);
                        sale.Vehicle.Description = dr["Description"].ToString();
                        sale.Vehicle.ImgUrl = dr["ImageFilePath"].ToString();
                        sale.Vehicle.Sold = Convert.ToBoolean(dr["Sold"]);

                        sales.Add(sale);
                    }
                }
            }
            return (sales);
        }

        public Sale GetSaleById(int id)
        {
            Sale sales = new Sale();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetSaleById", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sales.Vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                        sales.SalesId = Convert.ToInt32(dr["SalesId"]);
                        sales.Vehicle.SalesPrice = Convert.ToDecimal(dr["SalesPrice"]);                       
                        sales.Customer.CustomerId= dr["CustomerId"] != DBNull.Value ? Convert.ToInt32(dr["CustomerId"]): 0;                       
                        //sales.Customer.CustomerId = Convert.ToInt32((dr["CustomerId"]) ?? 0);
                        sales.Vehicle.Make.MakeId = Convert.ToInt32(dr["MakeId"]);
                        sales.Vehicle.Make.MakeName = dr["MakeName"].ToString();
                        sales.Vehicle.Model.ModelId = Convert.ToInt32(dr["ModelId"]);
                        sales.Vehicle.Model.ModelName = dr["ModelName"].ToString();
                        sales.Vehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                        sales.Vehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                        sales.Vehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                        sales.Vehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                        sales.Vehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                        sales.Vehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                        sales.Vehicle.VIN = dr["VIN"].ToString();
                        sales.Vehicle.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        sales.Vehicle.Year = Convert.ToInt32(dr["Year"]);
                        sales.Vehicle.Description = dr["Description"].ToString();
                        sales.Vehicle.ImgUrl = dr["ImageFilePath"].ToString();
                        sales.Vehicle.Sold = Convert.ToBoolean(dr["Sold"]);
                    }
                }
            }
            return sales;
        }
        public List<Sale> GetSearchedSales(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            List<Sale> sales = new List<Sale>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SalesSearch", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (minPrice == null)
                {
                    cmd.Parameters.AddWithValue("@minPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@minPrice", minPrice);
                }
                if (maxPrice == null)
                {
                    cmd.Parameters.AddWithValue("@maxPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                }
                if (minYear == null)
                {
                    cmd.Parameters.AddWithValue("@minYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@minYear", minYear);
                }
                if (maxYear == null)
                {
                    cmd.Parameters.AddWithValue("@maxYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@maxYear", maxYear);
                }
                if (searchString == null)
                {
                    cmd.Parameters.AddWithValue("@searchString", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@searchString", searchString);
                }

                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Sale sale = new Sale();
                            sale.Vehicle.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                            sale.Vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                            sale.Vehicle.Make.MakeId = Convert.ToInt32(dr["MakeId"]);
                            sale.Vehicle.Make.MakeName = dr["MakeName"].ToString();
                            sale.Vehicle.Model.ModelId = Convert.ToInt32(dr["ModelId"]);
                            sale.Vehicle.Model.ModelName = dr["ModelName"].ToString();
                            sale.Vehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                            sale.Vehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                            sale.Vehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                            sale.Vehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                            sale.Vehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                            sale.Vehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                            sale.Vehicle.VIN = dr["VIN"].ToString();
                            sale.Vehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                            sale.Vehicle.Year = Convert.ToInt32(dr["Year"]);
                            sale.Vehicle.Description = dr["Description"].ToString();
                            sale.Vehicle.ImgUrl = dr["ImageFilePath"].ToString();
                            sale.Vehicle.Sold = Convert.ToBoolean(dr["Sold"]);

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

        public void Update(Sale sales)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateSales", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalesId", sales.SalesId);
                cmd.Parameters.AddWithValue("@CustomerId", sales.Customer.CustomerId);
                cmd.Parameters.AddWithValue("@SalesPrice", sales.PurchasePrice);
                cmd.Parameters.AddWithValue("@SalesDate", sales.SalesDate);
                cmd.Parameters.AddWithValue("@VehicleId", sales.Vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@UserId", sales.SalesPerson);

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
