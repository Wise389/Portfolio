using CarDealership.DAL.Repository;
using CarDealership.Test;
using System;
﻿using CarDealership.DAL.Interface;
using CarDealership.Models;
using System.Collections.Generic;
using CarDealership.DAL.Factory;
using System.Xml.Serialization;
using CarsDealership.DAL.Interface;
using CarsDealership.DAL.Factory;
using System.Linq;
using CarsDealership.Models;

namespace CarDealership.BLL
{
    public class OperationManager
    {
        private IReportsRepository ReportRepository { get; }
        private IVehicleRepository VehicleRepository { get; }

        private ISalesRepository SalesRepository { get; }

        private ICustomerRepository CustomerRepository { get; }

        private ISpecialsRepository SpecialsRepository { get; }
        private IContactRepository ContactRepository { get; }
        private IUserRepository UserRepository { get; }
        public void RemoveDuplicates(string userId, string roleId)
        {
            UserRepository.RemoveDuplicates(userId, roleId);
        }
        public void UpdateUserName(string userId, string userName)
        {
            UserRepository.UpdateUserName(userId, userName);
        }
        public void CreateSale(Sale sale)
        {
            SalesRepository.Create(sale);
        }
        public List<User> GetAllUsers()
        {
            return UserRepository.GetAllUsers();
        }
        public User GetUserById(string id)
        {
            return UserRepository.GetUserById(id);
        }
        public List<InventoryReport> GetNew()
        {
            return ReportRepository.GetNew();
        }
        public List<InventoryReport> GetUsed()
        {
            return ReportRepository.GetUsed();
        }
        public List<Vehicle> GetNewVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            return VehicleRepository.GetNewVehicleSearch(minPrice, maxPrice, minYear, maxYear, searchString);
        }
        public List<Vehicle> GetUsedVehicleSearch(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            return VehicleRepository.GetUsedVehicleSearch(minPrice, maxPrice, minYear, maxYear, searchString);
        }
        public List<Sale> GetSearchedSales(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            return SalesRepository.GetSearchedSales(minPrice, maxPrice, minYear, maxYear, searchString);
        }
        public List<Vehicle> GetSearchedVehicles(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string searchString)
        {
            return VehicleRepository.GetSearchedVehicles(minPrice, maxPrice, minYear, maxYear, searchString);
        }
        public List<SalesReport> GetSalesReports(string User, DateTime? fromDate, DateTime? toDate)
        {
            return ReportRepository.GetSalesReports(User, fromDate,toDate);
        }
        public Sale GetSaleById(int id)
        {
            return SalesRepository.GetSaleById(id);
        }
        public List<Sale> GetAllSales()
        {
            return SalesRepository.GetAllSales();
        }
        public List<Vehicle> GetAllVehicles()
        {
            return VehicleRepository.GetAll();
        }
        public List<Vehicle> GetAllFeatured()
        {
            return VehicleRepository.GetAllFeatured();
        }
        public List<Vehicle> FindNew()
        {
            return VehicleRepository.FindNew();
        }
        public List<Vehicle> FindUsed()
        {
            return VehicleRepository.FindUsed();
        }
        public Vehicle GetVehicleByID(int id)
        {
            return VehicleRepository.GetById(id);
        }
        public void DeleteVehicle(int id)
        {
            VehicleRepository.Delete(id);
        }
        public List<Special> GetAllSpecials()
        {
            return SpecialsRepository.GetAll();
        }
        public void AddSpecial(Special special)
        {
            SpecialsRepository.Create(special);
        }
        public void DeleteSpecial(int id)
        {
            SpecialsRepository.Delete(id);
        }
        public Special GetById(int id)
        {
            return SpecialsRepository.GetById(id);
        }
        public List<Model> GetAllModels()
        {
            return VehicleRepository.GetAllModels();
        }
        public int AddVehicle(Vehicle vehicle)
        {
            return VehicleRepository.Create(vehicle);
        }
        public void EditVehicle(Vehicle vehicle)
        {
            VehicleRepository.Update(vehicle);
        }
        public List<Make> GetAllMakes()
        {
            return VehicleRepository.GetAllMakes();
        }
        public void AddMake(Make make)
        {
            VehicleRepository.AddMake(make);
        }
        public void AddModel(Model model)
        {
            VehicleRepository.AddModel(model);
        }
        public void AddContact(Contact contact)
        {
            CustomerRepository.AddContact(contact);
        }
        public OperationManager()
        {
            VehicleRepository = VehicleRepositoryFactory.Create();

            SalesRepository = SalesRepositoryFactory.Create();

            CustomerRepository = CustomerRepositoryFactory.Create();

            SpecialsRepository = SpecialsRepositoryFactory.Create();

            ReportRepository = ReportRepositoryFactory.Create();

            UserRepository = UserRepositoryFactory.Create();
        }
    
    }
}
