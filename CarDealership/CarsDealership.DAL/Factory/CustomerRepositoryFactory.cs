using CarDealership.DAL.Interface;
using CarDealership.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Factory
{
    public class CustomerRepositoryFactory
    {
        public static ICustomerRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "InMemory":
                    return new CustomerInMemoryRepository();
                case "PROD":
                    return new CustomerRepositoryPROD();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
