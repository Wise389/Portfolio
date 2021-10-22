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
    public class UserRepositoryFactory
    {
        public static IUserRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "InMemory":
                    return new UserInMemoryRepository();             
                case "PROD":
                    return new UserRepositoryPROD();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
