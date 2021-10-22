using CarDealership.DAL.Factory;
using CarDealership.DAL.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL
{
    public class OperationManagerFactory
    {
        public class OperationManager
        {

            private IVehicleRepository VehicleTestRepository { get; }

            private ISalesRepository SalesRepository { get; }

            private ICustomerRepository CustomerRepository { get; }

            private IUserRepository UserRepository { get; }


            public List<Sale> GetAllSales()
            {
                return SalesRepository.GetAll();
            }
            public OperationManager()
            {
                VehicleTestRepository = VehicleRepositoryFactory.Create();

                SalesRepository = DAL.Factory.SalesRepositoryFactory.Create();

                CustomerRepository = DAL.Factory.CustomerRepositoryFactory.Create(); ;

                UserRepository = DAL.Factory.UserRepositoryFactory.Create();

            }
        }
    }
}
