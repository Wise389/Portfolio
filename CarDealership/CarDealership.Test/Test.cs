using CarDealership.DAL.Repository;
using CarDealership.Models;
using CarDealership.Models.Enumerations;
using CarsDealership.DAL.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Test
{
    
    [TestFixture]
    public class Test
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;
        public void DBReset()
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Exec DBReset", cn);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        [Test]
        public void AddVehicleTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var make = repo.GetAllMakes();
            var model = repo.GetAllModels();
            var startList = repo.GetAll();

            var vehicle = new Vehicle()
            {
                Make = make.FirstOrDefault(),
                Model = model.FirstOrDefault(),
                Condition = (Condition)1,
                BodyStyle = (BodyStyle)1,
                Year = 2020,
                Transmission = (Transmission)1,
                Color = (Color)1,
                Interior = (Interior)1,
                Mileage = 20000,
                VIN = "JH4KA7660NC003110",
                MSRP = 2000,
                SalesPrice = 3000,
                Description = "Test",
                ImgUrl = $"/images/vehicle-{new Guid()}.jpeg",
                Sold = false
            };

            repo.Create(vehicle);

            var endlist = repo.GetAll();

            Assert.AreEqual(endlist.Count, startList.Count + 1);
            DBReset();
        }
        [Test]
        public void DeleteVehicleTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();

            var startList = repo.GetAll();
            var vehicleToDelete = startList.FirstOrDefault();
            
            repo.Delete(vehicleToDelete.VehicleId);

            var endlist = repo.GetAll();

            Assert.AreNotEqual(endlist.Count, startList.Count);
            DBReset();
        }
        [Test]
        public void UpdateVehicleTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var make = repo.GetAllMakes();
            var model = repo.GetAllModels();
            var vehicles = repo.GetAll();
            var toCompare = vehicles.FirstOrDefault();

            var vehicle = new Vehicle()
            {
                VehicleId = toCompare.VehicleId,
                Make = make.FirstOrDefault(),
                Model = model.FirstOrDefault(),
                Condition = (Condition)1,
                BodyStyle = (BodyStyle)1,
                Year = 2020,
                Transmission = (Transmission)1,
                Color = (Color)1,
                Interior = (Interior)1,
                Mileage = 20000,
                VIN = "JH4KA7660NC003110",
                MSRP = 2000,
                SalesPrice = 3000,
                Description = "Test",
                ImgUrl = $"/images/vehicle-{new Guid()}.jpeg",
                Sold = false
            };

            repo.Update(vehicle);

            Assert.AreNotSame(vehicle, toCompare);
            DBReset();
        }
        [Test]
        public void GetVehicleByIdTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var vehicles = repo.GetAll();
            var checkId = vehicles.FirstOrDefault();
            var compareId = repo.GetById(checkId.VehicleId);

            Assert.AreEqual(compareId.VehicleId, checkId.VehicleId);
            DBReset();
        }
        [Test]
        public void GetAllVehicleTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var make = repo.GetAllMakes();
            var model = repo.GetAllModels();
            var vehicles = repo.GetAll();
            var vehicle = new Vehicle()
            {
                Make = make.FirstOrDefault(),
                Model = model.FirstOrDefault(),
                Condition = (Condition)1,
                BodyStyle = (BodyStyle)1,
                Year = 2020,
                Transmission = (Transmission)1,
                Color = (Color)1,
                Interior = (Interior)1,
                Mileage = 20000,
                VIN = "JH4KA7660NC003110",
                MSRP = 2000,
                SalesPrice = 3000,
                Description = "Test",
                ImgUrl = $"/images/vehicle-{new Guid()}.jpeg",
                Sold = false
            };
            repo.Create(vehicle);
            var toCompare = repo.GetAll();
            Assert.AreEqual(vehicles.Count + 1, toCompare.Count);
            DBReset();
        }
        [Test]
        public void GetFeaturedVehicleTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var vehicles = repo.GetAll();
            var featured = repo.GetAllFeatured();
            Assert.AreNotEqual(vehicles.Count, featured.Count);
            DBReset();
        }
        [Test]
        public void FindNewTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var vehicles = repo.GetAll();
            var newVehicles = repo.FindNew();
            Assert.AreNotEqual(vehicles.Count, newVehicles.Count);
            DBReset();
        }
        [Test]
        public void FindUsedTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var vehicles = repo.GetAll();
            var usedVehicles = repo.FindUsed();
            Assert.AreNotEqual(vehicles.Count, usedVehicles.Count);
            DBReset();
        }
        [Test]
        public void GetNewVehicleSearch()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var searchCompare = repo.FindNew();
            var searched = repo.GetNewVehicleSearch(null, null, null, null, null);
            Assert.AreEqual(searchCompare.Count, searched.Count);
            DBReset();
        }
        [Test]
        public void GetUsedVehicleSearch()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var searchCompare = repo.FindUsed();
            var searched = repo.GetUsedVehicleSearch(null, null, null, null, null);
            Assert.AreEqual(searchCompare.Count, searched.Count);
            DBReset();
        }
        [Test]
        public void GetVehicleSearch()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var searchCompare = repo.GetAll().FindAll(o => o.Sold == false);
            var searched = repo.GetSearchedVehicles(null, null, null, null, null);
            Assert.AreEqual(searchCompare.Count, searched.Count);
            DBReset();
        }
        [Test]
        public void AddMakeTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var start = repo.GetAllMakes();
            Make make = new Make
            {
                MakeName = "Honda",
                DateAdded = DateTime.Now,
                UserEmail = "Email@email.edu",
                UserID = ""
            };
            repo.AddMake(make);
            var end = repo.GetAllMakes();
            Assert.AreNotEqual(start, end);
            DBReset();
        }
        [Test]
        public void AddModelTest()
        {
            VehicleRepositoryPROD repo = new VehicleRepositoryPROD();
            var makes = repo.GetAllMakes();
            var start = repo.GetAllModels();
            Model model = new Model
            {
                ModelName = "Hype",
                Make = makes.FirstOrDefault(),
                DateAdded = DateTime.Now,
                UserID = ""
            };
            repo.AddModel(model);
            var end = repo.GetAllModels();
            Assert.AreNotEqual(start, end);
            DBReset();
        }
        [Test]
        public void CreateContactTest()
        {
            ContactRepositoryPROD repo = new ContactRepositoryPROD();
            Contact contact = new Contact
            {
                Name = "Rick",
                Email = "James@Email.com",
                Phone = "",
                Message = "",
            };
            repo.Create(contact);
            DBReset();
        }
        [Test]
        public void GetSaleByIdTest()
        {
            SalesRepositoryPROD repo = new SalesRepositoryPROD();
            var sales = repo.GetAllSales();
            var sale = sales.FirstOrDefault();
            var check = repo.GetSaleById(sale.Vehicle.VehicleId);

            Assert.AreEqual(sale.SalesId, check.SalesId);
            DBReset();
        }
    
        [Test]
        public void PurchaseTest()
        {
            SalesRepositoryPROD repo = new SalesRepositoryPROD();
            VehicleRepositoryPROD vehicleRepo = new VehicleRepositoryPROD();
            UserRepositoryPROD userRepo = new UserRepositoryPROD();
            var startList = repo.GetAllSales();
            var toSell = vehicleRepo.GetAll().FirstOrDefault();
            Sale sale = new Sale()
            {
                PurchasePrice = 20000m,
                SalesType = SalesType.Cash,
                SalesDate = DateTime.Now,
                Vehicle = toSell,
                SalesPerson = userRepo.GetAllUsers().FirstOrDefault().FirstName,
                Customer = new Customer()
            };
            repo.Create(sale);
            var endlist = repo.GetAllSales();

            Assert.AreEqual(endlist.Count, startList.Count + 1);
            DBReset();
        }
        [Test]
        public void GetAllSalesTest()
        {
            VehicleRepositoryPROD vehicleRepo = new VehicleRepositoryPROD();
            SalesRepositoryPROD repo = new SalesRepositoryPROD();
            UserRepositoryPROD userRepo = new UserRepositoryPROD();
            var start = repo.GetAllSales();
            var toSell = vehicleRepo.GetAll().FirstOrDefault();
            Sale sale = new Sale()
            {
                PurchasePrice = 20000m,
                SalesType = SalesType.Cash,
                SalesDate = DateTime.Now,
                Vehicle = toSell,
                SalesPerson = userRepo.GetAllUsers().FirstOrDefault().FirstName,
                Customer = new Customer()
            };
            repo.Create(sale);
            var end = repo.GetAllSales();
            Assert.AreEqual(start.Count + 1, end.Count);
            DBReset();
        }
        //[Test]
        //public void GetAllUserTest()
        //{
        //    UserRepositoryPROD userRepo = new UserRepositoryPROD();
        //    var start = userRepo.GetAllUsers();

        //}
    }
}
