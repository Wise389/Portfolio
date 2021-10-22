using CarDealership.DAL.Interface;
using System;
using CarDealership.DAL.Repository;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Factory
{
    public class SalesRepositoryFactory
    {
        public static ISalesRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "InMemory":
                    return new SalesInMemoryRepository();
                case "PROD":
                    return new SalesRepositoryPROD();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
