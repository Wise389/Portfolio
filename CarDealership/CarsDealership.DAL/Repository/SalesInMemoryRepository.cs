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
    public class SalesInMemoryRepository : ISalesRepository
    {   
        private static List<Sale> sales = new List<Sale>
        {
            new Sale
            {
                SalesId = 1, PurchasePrice = 12000, SalesType=SalesType.Bank_Finance, 
                Customer = new Customer
                {
                    CustomerId=1, Name="Gary", Phone="2223334444", Email="GDawg@email.com", Street1="303 6th st.", City="Canton", State=State.OH, Zipcode=44720
                }, 
                Vehicle = new Vehicle
                {
                    VehicleId = 1, 
                    Make = new Make
                    {
                        MakeId = 1, MakeName = "Toyota", DateAdded = DateTime.Now, UserEmail = "932@email.com", UserID = "1",
                        
                    },
                    Model = new Model
                    {
                        ModelId = 1, ModelName = "Camery"
                    },
                    Condition = Condition.New, BodyStyle = BodyStyle.Car, Year = 2002, Transmission = Transmission.Automatic, Color = Color.Black, Interior = Interior.Black, Mileage = 10000, VIN = "10DJF023KD",
                    MSRP = 13000, SalesPrice = 12000, Description = "Is a Car", Featured = true, ImgUrl = "ekow"
                },
                SalesDate = DateTime.Now
            },
            new Sale
            {
                SalesId = 2, PurchasePrice = 13000, SalesType=SalesType.Bank_Finance, Customer = new Customer
                {
                    CustomerId=2, Name="Tony", Phone="2223334444", Email="Tawg@email.com", Street1="666 6th st.", City="Dayton", State=State.OH, Zipcode=44720
                }, Vehicle = new Vehicle
                {
                    VehicleId = 2, Make = new Make
                    {
                        MakeId = 1, MakeName = "Dodge", DateAdded = DateTime.Now, UserEmail = "732@email.com",
                    UserID = "2",
                       
                    },
                    Model = new Model
                    {
                        ModelId = 3, ModelName = "Ram"
                    },
                    Condition = Condition.Used, BodyStyle = BodyStyle.Truck, Year = 2020, Transmission = Transmission.Manual, Color = Color.Green, Interior = Interior.White, Mileage = 20000, VIN = "10DTF023KD",
                    MSRP = 13000, Description = "Is a Truck", Featured = true, ImgUrl = "ekow"
                },
                SalesDate = DateTime.Now
            },
            new Sale
            {
                SalesId = 3, PurchasePrice = 14000, SalesType=SalesType.Dealer_Finance, Customer = new Customer
                {
                    CustomerId=1, Name="Gary", Phone="2223334444", Email="GDawg@email.com", Street1="68 7th st.", City="Draenor", State=State.CA, Zipcode=90210
                }, Vehicle = new Vehicle
                {
                    VehicleId = 1, Make = new Make
                    {
                        MakeId = 3, MakeName = "Saturn", DateAdded = DateTime.Now, UserEmail = "962@email.com",
                    UserID = "3",
                    },
                    Model = new Model
                    {
                        ModelId = 4, ModelName = "VUE"
                    },
                    Condition = Condition.New, BodyStyle = BodyStyle.SUV, Year = 2019, Transmission = Transmission.Automatic, Color = Color.Blue, Interior = Interior.Black, Mileage = 40000, VIN = "90DJF023KD",
                    MSRP = 13000, Description = "Is a Car", Featured = true, ImgUrl = "ewok"
                },
                SalesDate = DateTime.Now
            },
        };
        public void Create(Sale sale)
        {
            sale.SalesId = sales.Max(o => o.SalesId) + 1;
            sales.Add(sale);
        }

        public void Delete(int id)
        {
            var toDelete = sales.FirstOrDefault(o => o.SalesId == id);
            sales.Remove(toDelete);
        }

        public List<Sale> GetAllSales()
        {
            return sales;
        }

        public List<Sale> GetByCustomer(Customer customer)
        {
            return sales.FindAll(o => o.Customer == customer);
        }

        public List<Sale> GetByDate(DateTime salesDate)
        {
            return sales.FindAll(o => o.SalesDate == salesDate);
        }

        public Sale GetSaleById(int id)
        {
            return sales.FirstOrDefault(o => o.SalesId == id);
        }
        public void Update(Sale sale)
        {
            var found = sales.FirstOrDefault(o => o.SalesId == sale.SalesId);
            if (found != null)
            {
                found = sale;
            }
            else
            {
                sales.Add(sale);
            }
        }
        public List<Sale> GetSearchedSales(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            List<Sale> salesSearch = GetAllSales();
            if (minYear.HasValue)
            {
                salesSearch = salesSearch.FindAll(o => o.Vehicle.Year > minYear.Value);
            }
            if (maxYear.HasValue)
            {
                salesSearch = salesSearch.FindAll(o => o.Vehicle.Year < maxYear.Value);
            }
            if (minPrice.HasValue)
            {
                salesSearch = salesSearch.FindAll(o => o.PurchasePrice > minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                salesSearch = salesSearch.FindAll(o => o.PurchasePrice < maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                salesSearch = salesSearch.FindAll(o => o.Vehicle.Year.ToString().Contains(searchString)
                || o.Vehicle.Make.MakeName.ToString().Contains(searchString)
                || o.Vehicle.Model.ModelName.ToString().Contains(searchString));
            }
            else
            {
                salesSearch.OrderBy(o => o.Vehicle.MSRP);

            }
            return salesSearch.Take(20).ToList();
        }
    }
}
