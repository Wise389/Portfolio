using CarDealership.Models;
using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Interface
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        void Create(Customer customer);
        void Delete(int id);
        void AddContact(Contact contact);

    }
}
