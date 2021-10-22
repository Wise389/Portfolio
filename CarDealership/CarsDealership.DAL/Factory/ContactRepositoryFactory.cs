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
    public class ContactRepositoryFactory
    {
        public static IContactRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "InMemory":
                    return new ContactInMemoryRepository();
                case "PROD":
                    return new ContactRepositoryPROD();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
