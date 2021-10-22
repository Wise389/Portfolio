using CarDealership.DAL.Interface;
using CarDealership.Models;
using CarDealership.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DAL.Repository
{
    public class CustomerInMemoryRepository : ICustomerRepository
    {
        private static List<Contact> contacts = new List<Contact>();
        private static List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                CustomerId=1, 
                Name="Gary", 
                Phone="330234032", 
                Email="GDawg@email.com", 
                Street1="303 6th st.", 
                City="Canton", 
                State=State.OH, 
                Zipcode=44720
            },
            new Customer
            {
                CustomerId=2, 
                Name="Tony", 
                Phone="330337732", 
                Email="TDawg@email.com", 
                Street1="413 6th st.", 
                City="Cleveland", 
                State=State.OH, 
                Zipcode=44708
            },
            new Customer
            {
                CustomerId=3, 
                Name="Bary", 
                Phone="330239999", 
                Email="BDawg@email.com", 
                Street1="303 9th st.", 
                City="Cleveland Heights",
                State=State.OH, 
                Zipcode=44720
            },
            new Customer
            {
                CustomerId=4, 
                Name="Gary", 
                Phone="330234032", 
                Email="Doctor@email.com", 
                Street1="666 12th st.", 
                City="Beverly Hills", 
                State=State.CA, 
                Zipcode=90210
            },
            new Customer
            {
                CustomerId=5, 
                Name="Sherlock Holmes", 
                Phone="330664032", 
                Email="GDawg@email.com", 
                Street1="221B Baker st.", 
                City="London", 
                State=State.TX, 
                Zipcode=26756
            },
        };

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void Create(Customer customer)
        {
            customer.CustomerId = customers.Max(o => o.CustomerId) + 1;
            customers.Add(customer);
        }

        public void Delete(int id)
        {
            var toDelete = customers.FirstOrDefault(o => o.CustomerId == id);
            customers.Remove(toDelete);
        }
        public Customer GetById(int id)
        {
            return customers.FirstOrDefault(o => o.CustomerId == id);
        }
        public void Update(Customer customer)
        {
            var found = customers.FirstOrDefault(m => m.CustomerId == customer.CustomerId);
            if (found != null)
            {
                found = customer;
            }
            else
            {
                customers.Add(customer);
            }
        }
    }
}
