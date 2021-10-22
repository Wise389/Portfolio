using CarDealership.DAL.Interface;
using CarDealership.Models;
using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Repository
{
    public class VehicleInMemoryRepository : IVehicleRepository
    {
        private static List<Vehicle> vehicles = new List<Vehicle>
        {
       
        new Vehicle
            {
                VehicleId=1,
                Make = new Make
                {
                    MakeId = 2,
                    MakeName = "Ford",
                    DateAdded = DateTime.Now,
                    UserEmail = "732@email.com",
                    UserID = "2",

                },
                Model = new Model
                {
                    ModelId = 2,
                    ModelName = "ThunderCougar"
                },
            Condition=Condition.Used,
            BodyStyle=BodyStyle.Van, Year=2020,
            Transmission=Transmission.Manual,
            Color=Color.Red, Interior=Interior.Green,
            Mileage=99933, VIN="eiwit29dw92",
            MSRP=14000, SalesPrice=15000,
            Description="someg",
            Featured=true,
            ImgUrl = "/images/inventory-a7618dc6-acf6-428a-888a-342590b45de8.jpg",
            Sold = false
            },
        new Vehicle
            {
                VehicleId=2,
                Make = new Make
                {
                    MakeId = 2,
                    MakeName = "Honda",
                    DateAdded = DateTime.Now,
                    UserEmail = "732@email.com",
                    UserID = "2",

                },
                Model = new Model
                {
                    ModelId = 2,
                    ModelName = "Civic"
                },
            Condition=Condition.New,
            BodyStyle=BodyStyle.Van, Year=2020,
            Transmission=Transmission.Manual,
            Color=Color.Red, Interior=Interior.Green,
            Mileage=99933, VIN="eiwit29dw92",
            MSRP=14000, SalesPrice=15000,
            Description="someg",
            Featured=true,
            ImgUrl = "/images/inventory-60d78858-9f28-412f-988a-baaba3972adf.jpg",
            Sold = true
            },
        };



        private static List<Model> models = new List<Model> {
            new Model
            {
                Make = new Make
                {
                    MakeId = 3,
                    MakeName = "Honda",
                    UserEmail = "932@email.com",
                    UserID = "1",
                    DateAdded = DateTime.Now
                },
                ModelId = 1,
                ModelName = "Civic",
                UserEmail = "932@email.com",
                UserID = "1",
                DateAdded = DateTime.Now
            },
             new Model
            {
                Make = new Make
                {
                    MakeId = 3,
                    MakeName = "YourMom",
                    UserEmail = "732@email.com",
                    UserID = "2",
                    DateAdded = DateTime.Now
                },
                ModelId = 2,
                ModelName = "Thunderbird",
                UserEmail = "732@email.com",
                UserID = "2",
                DateAdded = DateTime.Now
            },
             new Model
            {
                Make = new Make
                {
                    MakeId = 3,
                    MakeName = "MotherEarth",
                    UserEmail = "962@email.com",
                    UserID = "3",
                    DateAdded = DateTime.Now
                },
                ModelId = 3,
                ModelName = "Greentree",
                UserEmail = "962@email.com",
                UserID = "3",
                DateAdded = DateTime.Now
            },
        };
        private static List<Make> makes = new List<Make> {
            new Make
            {
                MakeId = 1,
                MakeName = "Toyota",
                UserEmail = "932@email.com",
                UserID = "1",
                DateAdded = DateTime.Now
            },
             new Make
            {
                MakeId = 2,
                MakeName = "Chrystler",
                UserEmail = "732@email.com",
                UserID = "2",
                DateAdded = DateTime.Now
            },
            new Make
            {
                MakeId = 3,
                MakeName = "Honda",
                UserEmail = "962@email.com",
                UserID = "3",
                DateAdded = DateTime.Now
            },
        };

        public int Create(Vehicle vehicle)
        {
            vehicle.VehicleId = vehicles.Max(o => o.VehicleId) + 1;
            vehicles.Add(vehicle);
            return vehicle.VehicleId;
        }

        public void Delete(int id)
        {
            var toDelete = vehicles.FirstOrDefault(o => o.VehicleId == id);
            vehicles.Remove(toDelete);
        }
        public void AddMake(Make make)
        {
            make.MakeId = makes.Max(o => o.MakeId) + 1;
            makes.Add(make);
        }
        public void AddModel(Model model)
        {
            model.ModelId = models.Max(o => o.ModelId) + 1;
            models.Add(model);
        }
        public List<Vehicle> GetAll()
        {
            return vehicles;
        }
        public List<Make> GetAllMakes()
        {
            return makes;
        }
        public List<Model> GetAllModels()
        {
            return models;
        }
        public List<Vehicle> GetAllFeatured()
        {
            return vehicles.FindAll(o => o.Featured == true);
        }
        public Vehicle GetById(int id)
        {
            return vehicles.FirstOrDefault(o => o.VehicleId == id);
        }

        public List<Vehicle> FindNew()
        {
            return vehicles.FindAll(o => o.Condition == Condition.New);
        }
        public List<Vehicle> FindUsed()
        {
            return vehicles.FindAll(o => o.Condition == Condition.Used);
        }
        public void Update(Vehicle vehicle)
        {
            var oldVehicle = vehicles.FirstOrDefault(m => m.VehicleId == vehicle.VehicleId);
            if (oldVehicle != null)
            {
                var index = vehicles.IndexOf(oldVehicle);
                vehicles[index] = vehicle;
            }
            else
            {
                vehicles.Add(vehicle);
            }
        }
        public List<Vehicle> GetNewVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            var newVehicleSearch = FindNew();
            if (minYear.HasValue)
            {
                newVehicleSearch = newVehicleSearch.FindAll(o => o.Year > minYear.Value);
            }
            if (maxYear.HasValue)
            {
                newVehicleSearch = newVehicleSearch.FindAll(o => o.Year < maxYear.Value);
            }
            if (minPrice.HasValue)
            {
                newVehicleSearch = newVehicleSearch.FindAll(o => o.SalesPrice > minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                newVehicleSearch = newVehicleSearch.FindAll(o => o.SalesPrice < maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                newVehicleSearch = newVehicleSearch.FindAll(o => o.Year.ToString().Contains(searchString)
                || o.Make.MakeName.ToString().Contains(searchString)
                || o.Model.ModelName.ToString().Contains(searchString));
            }
            else
            {
                newVehicleSearch.OrderBy(o => o.MSRP);

            }
            return newVehicleSearch.Take(20).ToList();
        }
        public List<Vehicle> GetUsedVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            var usedVehicleSearch = FindUsed();
            if (minYear.HasValue)
            {
                usedVehicleSearch = usedVehicleSearch.FindAll(o => o.Year > minYear.Value);
            }
            if (maxYear.HasValue)
            {
                usedVehicleSearch = usedVehicleSearch.FindAll(o => o.Year < maxYear.Value);
            }
            if (minPrice.HasValue)
            {
                usedVehicleSearch = usedVehicleSearch.FindAll(o => o.SalesPrice > minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                usedVehicleSearch = usedVehicleSearch.FindAll(o => o.SalesPrice < maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                usedVehicleSearch = usedVehicleSearch.FindAll(o => o.Year.ToString().Contains(searchString)
                || o.Make.MakeName.ToString().Contains(searchString)
                || o.Model.ModelName.ToString().Contains(searchString));
            }
            else
            {
                usedVehicleSearch.OrderBy(o => o.MSRP);

            }
            return usedVehicleSearch.Take(20).ToList();
        }
        public List<Vehicle> GetSearchedVehicles(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            var vehicleSearch = GetAll();
            if (minYear.HasValue)
            {
                vehicleSearch = vehicleSearch.FindAll(o => o.Year > minYear.Value);
            }
            if (maxYear.HasValue)
            {
                vehicleSearch = vehicleSearch.FindAll(o => o.Year < maxYear.Value);
            }
            if (minPrice.HasValue)
            {
                vehicleSearch = vehicleSearch.FindAll(o => o.SalesPrice > minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                vehicleSearch = vehicleSearch.FindAll(o => o.SalesPrice < maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleSearch = vehicleSearch.FindAll(o => o.Year.ToString().Contains(searchString)
                || o.Make.MakeName.ToString().Contains(searchString)
                || o.Model.ModelName.ToString().Contains(searchString));
            }
            else
            {
                vehicleSearch.OrderBy(o => o.MSRP);

            }
            return vehicleSearch.Take(20).ToList();
        }
    }
}
