using CarDealership.Models;
using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DAL.Interface
{
    public interface IVehicleRepository
    {
        Vehicle GetById(int id);
        List<Vehicle> GetAll();
        List<Vehicle> GetAllFeatured();
        List<Vehicle> FindNew();
        List<Vehicle> FindUsed();
        List<Vehicle> GetNewVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString);
        List<Vehicle> GetUsedVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString);
        List<Vehicle> GetSearchedVehicles(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString);
        int Create(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int id);
        void AddMake(Make make);
        void AddModel(Model model);
        List<Make> GetAllMakes();
        List<Model> GetAllModels();
    }
}
