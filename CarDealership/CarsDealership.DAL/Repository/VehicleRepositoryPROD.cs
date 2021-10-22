  using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CarDealership.DAL.Interface;
using CarDealership.Models.Enumerations;
using System.Data.SqlClient;
using System.Configuration;

namespace CarDealership.DAL.Repository
{
    
    public class VehicleRepositoryPROD : IVehicleRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;
        public void AddMake(Make make)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateMake", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@DateAdded", make.DateAdded);
                cmd.Parameters.AddWithValue("@UserId", make.UserID);

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

        public void AddModel(Model model)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateModel", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeId", model.Make.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@DateAdded", model.DateAdded);
                cmd.Parameters.AddWithValue("@UserId", model.UserID);

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

        public int Create(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.Make.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.Model.ModelId);
                cmd.Parameters.AddWithValue("@ConditionId", vehicle.Condition);
                cmd.Parameters.AddWithValue("@BodystyleId", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.Color);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@ImageFilePath", vehicle.ImgUrl);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@Sold", vehicle.Sold);
                SqlParameter ReturnValue = new SqlParameter();
                ReturnValue.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ReturnValue);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception e)
                {

                }
                return Convert.ToInt32(ReturnValue.Value);
            }
        }

        public void Delete(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", id);

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

        public List<Vehicle> FindNew()
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetNewVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConditionID", 1);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle newVehicle = new Vehicle();
                        newVehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                        newVehicle.Year = Convert.ToInt32(dr["Year"]);
                        newVehicle.Make.MakeName = dr["MakeName"].ToString();
                        newVehicle.Model.ModelName = dr["ModelName"].ToString();
                        newVehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                        newVehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                        newVehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                        newVehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                        newVehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                        newVehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                        newVehicle.VIN = dr["VIN"].ToString();
                        newVehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                        newVehicle.Year = Convert.ToInt32(dr["Year"]);
                        newVehicle.ImgUrl = dr["ImageFilePath"].ToString();


                        vehicle.Add(newVehicle);
                    }
                }
            }
            return vehicle;
        }

        public List<Vehicle> FindUsed()
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUsedVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConditionID", 2);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle newVehicle = new Vehicle();
                        newVehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                        newVehicle.Year = Convert.ToInt32(dr["Year"]);
                        newVehicle.Make.MakeName = dr["MakeName"].ToString();
                        newVehicle.Model.ModelName = dr["ModelName"].ToString();
                        newVehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                        newVehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                        newVehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                        newVehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                        newVehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                        newVehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                        newVehicle.VIN = dr["VIN"].ToString();
                        newVehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                        newVehicle.Year = Convert.ToInt32(dr["Year"]);
                        newVehicle.ImgUrl = dr["ImageFilePath"].ToString();

                        vehicle.Add(newVehicle);
                    }
                }
            }
            return vehicle;
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                        vehicle.Year = Convert.ToInt32(dr["Year"]);
                        vehicle.Make.MakeId = Convert.ToInt32(dr["MakeId"]);
                        vehicle.Make.MakeName = dr["MakeName"].ToString();
                        vehicle.Make.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                        vehicle.Model.ModelName = dr["ModelName"].ToString();
                        vehicle.Model.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                        vehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                        vehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                        vehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                        vehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                        vehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                        vehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                        vehicle.Year = Convert.ToInt32(dr["Year"]);
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.ImgUrl = dr["ImageFilePath"].ToString();
                        vehicle.Featured = Convert.ToBoolean(dr["Featured"]);
                        vehicle.Sold = Convert.ToBoolean(dr["Sold"]);


                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }

        public List<Vehicle> GetAllFeatured()
        {
            List<Vehicle> featured = new List<Vehicle>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetFeaturedVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                        vehicle.Year = Convert.ToInt32(dr["Year"]);
                        vehicle.Make.MakeName = dr["MakeName"].ToString();
                        vehicle.Model.ModelName = dr["ModelName"].ToString();
                        vehicle.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        vehicle.ImgUrl = dr["ImageFilePath"].ToString();
                        vehicle.SalesPrice = Convert.ToDecimal(dr["SalesPrice"]);

                        featured.Add(vehicle);
                    }
                }
            }
            return featured;
        }

        public List<Make> GetAllMakes()
        {
            List<Make> makes = new List<Make>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllMakes", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make make = new Make();
                        make.MakeId = Convert.ToInt32(dr["MakeId"]);
                        make.MakeName = dr["MakeName"].ToString();
                        make.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                        make.UserEmail = dr["Email"].ToString();

                        makes.Add(make);
                    }
                }
            }
            return makes;
        }

        public List<Model> GetAllModels()
        {
            List<Model> models = new List<Model>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllModels", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model model = new Model();
                        model.ModelId = Convert.ToInt32(dr["ModelId"]);
                        model.ModelName = dr["ModelName"].ToString();
                        model.Make.MakeId = Convert.ToInt32(dr["MakeId"]);
                        model.Make.MakeName = dr["MakeName"].ToString();
                        model.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                        model.UserID = dr["UserId"].ToString();
                        model.UserEmail = dr["Email"].ToString();

                        models.Add(model);
                    }
                }
            }
            return models;
        }
        public Vehicle GetById(int id)
         {
            Vehicle vehicle = new Vehicle();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetVehiclesById", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                        vehicle.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                        vehicle.Year = Convert.ToInt32(dr["Year"]);
                        vehicle.Make.MakeId = Convert.ToInt32(dr["MakeId"]);
                        vehicle.Make.MakeName = dr["MakeName"].ToString();
                        vehicle.Model.ModelId = Convert.ToInt32(dr["ModelId"]);
                        vehicle.Model.ModelName = dr["ModelName"].ToString();
                        vehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                        vehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                        vehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                        vehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                        vehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                        vehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                        vehicle.Year = Convert.ToInt32(dr["Year"]);
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.ImgUrl = dr["ImageFilePath"].ToString();
                        vehicle.Sold = Convert.ToBoolean(dr["Sold"]);
                    }
                }
            }
            return vehicle;
        }
        public List<Vehicle> GetNewVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("NewVehicleSearch", cn);
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
                            Vehicle newVehicle = new Vehicle();
                            newVehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                            newVehicle.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                            newVehicle.Year = Convert.ToInt32(dr["Year"]);
                            newVehicle.Make.MakeName = dr["MakeName"].ToString();
                            newVehicle.Model.ModelName = dr["ModelName"].ToString();
                            newVehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                            newVehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                            newVehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                            newVehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                            newVehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                            newVehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                            newVehicle.VIN = dr["VIN"].ToString();
                            newVehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                            newVehicle.Year = Convert.ToInt32(dr["Year"]);
                            newVehicle.ImgUrl = dr["ImageFilePath"].ToString();

                            vehicles.Add(newVehicle);
                        }
                    }
                }
                catch (Exception e)
                {

                }
                return vehicles;
            }
        }

        public List<Vehicle> GetSearchedVehicles(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("VehicleSearch", cn);
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
                            Vehicle vehicle = new Vehicle();
                            vehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                            vehicle.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                            vehicle.Year = Convert.ToInt32(dr["Year"]);
                            vehicle.Make.MakeId = Convert.ToInt32(dr["MakeId"]);
                            vehicle.Make.MakeName = dr["MakeName"].ToString();
                            vehicle.Make.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                            vehicle.Model.ModelId = Convert.ToInt32(dr["ModelId"]);
                            vehicle.Model.ModelName = dr["ModelName"].ToString();
                            vehicle.Model.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                            vehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                            vehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                            vehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                            vehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                            vehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                            vehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                            vehicle.VIN = dr["VIN"].ToString();
                            vehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                            vehicle.Year = Convert.ToInt32(dr["Year"]);
                            vehicle.Description = dr["Description"].ToString();
                            vehicle.ImgUrl = dr["ImageFilePath"].ToString();
                            vehicle.Featured = Convert.ToBoolean(dr["Featured"]);
                            vehicle.Sold = Convert.ToBoolean(dr["Sold"]);

                            vehicles.Add(vehicle);
                        }
                    }
                }
                catch (Exception e)
                {

                }
                return vehicles;
            }
        }

        public List<Vehicle> GetUsedVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UsedVehicleSearch", cn);
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
                            Vehicle usedVehicle = new Vehicle();
                            usedVehicle.VehicleId = Convert.ToInt32(dr["VehicleId"]);
                            usedVehicle.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                            usedVehicle.Year = Convert.ToInt32(dr["Year"]);
                            usedVehicle.Make.MakeName = dr["MakeName"].ToString();
                            usedVehicle.Model.ModelName = dr["ModelName"].ToString();
                            usedVehicle.Condition = (Condition)Convert.ToInt32(dr["ConditionId"]);
                            usedVehicle.BodyStyle = (BodyStyle)Convert.ToInt32(dr["BodyStyleId"]);
                            usedVehicle.Transmission = (Transmission)Convert.ToInt32(dr["TransmissionId"]);
                            usedVehicle.Color = (Color)Convert.ToInt32(dr["ColorId"]);
                            usedVehicle.Interior = (Interior)Convert.ToInt32(dr["InteriorId"]);
                            usedVehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                            usedVehicle.VIN = dr["VIN"].ToString();
                            usedVehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                            usedVehicle.Year = Convert.ToInt32(dr["Year"]);
                            usedVehicle.ImgUrl = dr["ImageFilePath"].ToString();

                            vehicles.Add(usedVehicle);
                        }
                    }
                }
                catch (Exception e)
                {

                }
                return vehicles;
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.Make.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.Model.ModelId);
                cmd.Parameters.AddWithValue("@ConditionId", vehicle.Condition);
                cmd.Parameters.AddWithValue("@BodystyleId", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.Color);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@ImageFilePath", vehicle.ImgUrl);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@Sold", vehicle.Sold);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);

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
