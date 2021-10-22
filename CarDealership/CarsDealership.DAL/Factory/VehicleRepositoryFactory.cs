using CarDealership.DAL.Interface;
using CarDealership.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CarDealership.DAL.Factory
{
    public class VehicleRepositoryFactory
    {
        public static IVehicleRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "InMemory":
                    return new VehicleInMemoryRepository();
                case "PROD":
                    return new VehicleRepositoryPROD();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}