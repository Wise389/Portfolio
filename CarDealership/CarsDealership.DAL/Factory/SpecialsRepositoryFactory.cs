using CarsDealership.DAL.Interface;
using CarsDealership.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDealership.DAL.Factory
{
    public class SpecialsRepositoryFactory
    {
        public static ISpecialsRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "InMemory":
                    return new SpecialsInMemoryRepository();
                case "PROD":
                    return new SpecialsRepositoryPROD();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
